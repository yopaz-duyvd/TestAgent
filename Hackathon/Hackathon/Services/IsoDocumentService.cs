namespace Hackathon.Services;

using Hackathon.Models;
using Hackathon.Models.Dtos;
using Hackathon.UnitOfWork;
using System;
using System.Linq;
using System.Collections.Generic;

public class IsoDocumentService(IUnitOfWork unitOfWork, IFileService fileService) : IIsoDocumentService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IFileService _fileService = fileService;
    private const long MaxRequestSize = 1L * 1024 * 1024 * 1024; // 1GB

    public async Task<IsoDocument> CreateAsync(IsoDocumentRequest request, long uploaderId)
    {
        var count = await _unitOfWork.IsoDocuments.CountByYearAsync(request.Year);
        var version = $"ISO_{request.Year}_v{count + 1}";
        var document = new IsoDocument
        {
            Year = request.Year,
            Notes = request.Notes,
            Version = version,
            UploaderId = uploaderId
        };
        await _unitOfWork.IsoDocuments.AddAsync(document);
        await _unitOfWork.SaveChangesAsync();
        return document;
    }

    public async Task<IEnumerable<IsoDocument>> GetAllAsync() =>
        await _unitOfWork.IsoDocuments.GetAllAsync();

    public async Task<IsoDocument?> GetByIdAsync(long id) =>
        await _unitOfWork.IsoDocuments.GetByIdAsync(id);

    public async Task<bool> UpdateAsync(long id, IsoDocumentRequest request)
    {
        var document = await _unitOfWork.IsoDocuments.GetByIdAsync(id);
        if (document == null)
        {
            return false;
        }
        document.Year = request.Year;
        document.Notes = request.Notes;
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var document = await _unitOfWork.IsoDocuments.GetByIdAsync(id);
        if (document == null)
        {
            return false;
        }
        _unitOfWork.IsoDocuments.Remove(document);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> EnableAsync(long id)
    {
        var document = await _unitOfWork.IsoDocuments.GetByIdAsync(id);
        if (document == null)
        {
            return false;
        }
        var all = await _unitOfWork.IsoDocuments.GetAllAsync();
        foreach (var doc in all)
        {
            doc.IsActive = doc.Id == id;
        }
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<IsoDocument> UploadAsync(long documentId, UploadIsoDocumentRequest request, long uploaderId)
    {
        if (request.Files.Sum(f => f.Length) > MaxRequestSize)
        {
            throw new InvalidOperationException("Request size cannot exceed 1GB.");
        }

        foreach (var file in request.Files)
        {
            if (file.ContentType.StartsWith("video/", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Video files are not allowed.");
            }
        }

        var document = await _unitOfWork.IsoDocuments.GetByIdAsync(documentId)
            ?? throw new InvalidOperationException("ISO document not found.");

        document.UploaderId ??= uploaderId;

        foreach (var file in request.Files)
        {
            var path = await _fileService.UploadFileAsync(file);
            document.Files.Add(new IsoFile
            {
                FilePath = path,
                FileType = file.ContentType
            });
        }

        await _unitOfWork.SaveChangesAsync();
        return document;
    }

    public async Task<IEnumerable<IsoDocument>> GetByYearAsync(int year) =>
        await _unitOfWork.IsoDocuments.GetByYearAsync(year);
}


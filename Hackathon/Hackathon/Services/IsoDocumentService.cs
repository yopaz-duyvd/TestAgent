namespace Hackathon.Services;

using Hackathon.Models;
using Hackathon.Models.Dtos;
using Hackathon.UnitOfWork;
using System;
using System.Linq;

public class IsoDocumentService(IUnitOfWork unitOfWork, IFileService fileService) : IIsoDocumentService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IFileService _fileService = fileService;
    private const long MaxRequestSize = 1L * 1024 * 1024 * 1024; // 1GB

    public async Task<IsoDocument> UploadAsync(UploadIsoDocumentRequest request, long uploadedBy)
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

        var count = await _unitOfWork.IsoDocuments.CountByYearAsync(request.Year);
        var version = $"ISO_{request.Year}_v{count + 1}";

        var document = new IsoDocument
        {
            Year = request.Year,
            Notes = request.Notes,
            Version = version,
            UploadedBy = uploadedBy
        };

        foreach (var file in request.Files)
        {
            var path = await _fileService.UploadFileAsync(file);
            document.Files.Add(new IsoFile
            {
                FilePath = path,
                FileType = file.ContentType
            });
        }

        await _unitOfWork.IsoDocuments.AddAsync(document);
        await _unitOfWork.SaveChangesAsync();

        return document;
    }
}

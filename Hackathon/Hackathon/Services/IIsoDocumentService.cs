namespace Hackathon.Services;

using Hackathon.Models;
using Hackathon.Models.Dtos;

public interface IIsoDocumentService
{
    Task<IsoDocument> CreateAsync(IsoDocumentRequest request, long uploaderId);
    Task<IEnumerable<IsoDocument>> GetAllAsync();
    Task<IsoDocument?> GetByIdAsync(long id);
    Task<bool> UpdateAsync(long id, IsoDocumentRequest request);
    Task<bool> DeleteAsync(long id);
    Task<bool> EnableAsync(long id);
    Task<bool> ResetScanAsync(long id);
    Task<IsoDocument> UploadAsync(long documentId, UploadIsoDocumentRequest request, long uploaderId);
    Task<IEnumerable<IsoDocument>> GetByYearAsync(int year);
    Task<IEnumerable<IsoFile>?> GetFilesAsync(long documentId);
}

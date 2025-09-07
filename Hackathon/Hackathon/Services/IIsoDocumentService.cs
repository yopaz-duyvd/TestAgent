namespace Hackathon.Services;

using Hackathon.Models;
using Hackathon.Models.Dtos;

public interface IIsoDocumentService
{
    Task<IsoDocument> UploadAsync(UploadIsoDocumentRequest request, long uploaderId);
    Task<IEnumerable<IsoDocument>> GetByYearAsync(int year);
}

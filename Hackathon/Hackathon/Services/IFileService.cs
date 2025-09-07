namespace Hackathon.Services;

using Microsoft.AspNetCore.Http;

public interface IFileService
{
    Task<string> UploadFileAsync(IFormFile file);
    Task DeleteFileAsync(string fileUrl);
    Task<string> GetPresignedUrlAsync(string fileUrl, int expiryInSeconds);
}

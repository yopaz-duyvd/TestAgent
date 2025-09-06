namespace Hackathon.Services;

using Microsoft.AspNetCore.Http;
using Minio;
using Minio.DataModel.Args;
using System.IO;

public class FileService(IConfiguration configuration) : IFileService
{
    private readonly MinioClient _client = new MinioClient()
        .WithEndpoint(configuration["Minio:Endpoint"]!)
        .WithCredentials(configuration["Minio:AccessKey"], configuration["Minio:SecretKey"])
        .WithSSL(bool.Parse(configuration["Minio:UseSSL"] ?? "false"))
        .Build();

    private readonly string _bucketName = configuration["Minio:BucketName"]!;

    public async Task<string> UploadFileAsync(IFormFile file)
    {
        await EnsureBucketExistsAsync();
        var objectName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        using var stream = file.OpenReadStream();
        await _client.PutObjectAsync(new PutObjectArgs()
            .WithBucket(_bucketName)
            .WithObject(objectName)
            .WithStreamData(stream)
            .WithObjectSize(stream.Length)
            .WithContentType(file.ContentType));
        return $"{_bucketName}/{objectName}";
    }

    public async Task DeleteFileAsync(string objectName)
    {
        await _client.RemoveObjectAsync(new RemoveObjectArgs()
            .WithBucket(_bucketName)
            .WithObject(objectName));
    }

    private async Task EnsureBucketExistsAsync()
    {
        var bucketExists = await _client.BucketExistsAsync(new BucketExistsArgs().WithBucket(_bucketName));
        if (!bucketExists)
        {
            await _client.MakeBucketAsync(new MakeBucketArgs().WithBucket(_bucketName));
        }
    }
}


﻿using Azure.Storage.Blobs;
using NichoShop.Application.Interfaces;
using NichoShop.Domain.Enums;
using NichoShop.Application.Extensions;
using NichoShop.Common.Interface;
using Azure.Storage.Blobs.Models;

namespace NichoShop.Application.Services;

public class AzureBlobStorageService : IStorageService
{
    private readonly BlobServiceClient _blobServiceClient;
    private readonly IUserContext _userContext;

    public AzureBlobStorageService(IUserContext userContext, IConfiguration _configuration)
    {
        string connectionString = _configuration.GetSection("AzureBlobStorage:Connectionstring").Value ?? throw new ArgumentNullException();
        _blobServiceClient = new BlobServiceClient(connectionString);
        _userContext = userContext;
    }

    private async Task<BlobContainerClient> GetContainerClient(string containerName)
    {
        BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        await containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);
        return containerClient;
    }

    public async Task DeleteFile(Guid fileId, StorageType type)
    {
        var containerClient = await GetContainerClient(type.GetDisplayName());
        var blobClient = containerClient.GetBlobClient(fileId.ToString());

        if (await blobClient.ExistsAsync())
        {
            await blobClient.DeleteAsync(); // Deletes the blob
        }
    }

    public Task<byte[]> DownloadFile(Guid fileId)
    {
        throw new NotImplementedException();
    }

    public async Task<string> GetFileUrl(Guid fileId, StorageType type)
    {
        var containerClient = await GetContainerClient(type.GetDisplayName());
        var blobClient = containerClient.GetBlobClient(fileId.ToString());

        if (!await blobClient.ExistsAsync())
            throw new FileNotFoundException();

        return blobClient.Uri.ToString();
    }

    public async Task<Guid> UploadFromFileAsync(IFormFile file, StorageType type)
    {
        if (file == null || file.Length == 0)
        {
            throw new Exception("No file uploaded.");
        }

        using var stream = file.OpenReadStream();
        return await UploadFileAsync(stream, file.ContentType, type);
    }

    private async Task<Guid> UploadFileAsync(Stream stream, string contentType, StorageType type)
    {
        var containerClient = await GetContainerClient(type.GetDisplayName());
        var fileId = type switch
        {
            StorageType.Avatar => _userContext.UserId,
            StorageType.ProductImages => Guid.NewGuid(),
            StorageType.CategoryImages => Guid.NewGuid(),
            _ => throw new NotImplementedException()
        };
        var blobClient = containerClient.GetBlobClient(fileId.ToString());

        var uploadOptions = new Azure.Storage.Blobs.Models.BlobUploadOptions
        {
            HttpHeaders = new Azure.Storage.Blobs.Models.BlobHttpHeaders
            {
                ContentType = contentType
            }
        };

        await blobClient.UploadAsync(stream, uploadOptions);

        return fileId;
    }

    public async Task<Guid> UploadFromByteDataAsync(byte[] data, StorageType type, string contentType = "application/octet-stream")
    {
        using var stream = new MemoryStream(data);
        return await UploadFileAsync(stream, contentType, type);
    }
}

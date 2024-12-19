using Azure.Storage.Blobs;
using NichoShop.Application.Interfaces;
using NichoShop.Domain.Enums;
using NichoShop.Application.Extensions;
using NichoShop.Common.Interface;

namespace NichoShop.Application.Services;

public class FileService : IFileService
{
    private readonly BlobServiceClient _blobServiceClient;
    private readonly IUserContext _userContext;
    public FileService(IUserContext userContext)
    {
        string connectionString = "";
        _blobServiceClient = new BlobServiceClient(connectionString);
        this._userContext = userContext;
    }

    private async Task<BlobContainerClient> GetContainerClient(string containerName)
    {
        BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        await containerClient.CreateIfNotExistsAsync();
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
        //var blobProperties = await blobClient.GetPropertiesAsync();

        //var sasBuilder = new BlobSasBuilder
        //{
        //    BlobContainerName = containerClient.Name,
        //    BlobName = fileId.ToString(),
        //    Resource = "b", // Blob
        //    ExpiresOn = DateTimeOffset.UtcNow.AddHours(1) // Valid for 1 hour
        //};

        //sasBuilder.SetPermissions(Azure.Storage.Sas.BlobContainerSasPermissions.Read);
        //sasBuilder.ContentType = "image";
        //Uri sasUri = blobClient.GenerateSasUri(sasBuilder);

        //return sasUri.ToString();
    }

    public async Task<Guid> UploadFile(IFormFile file, StorageType type)
    {
        if (file == null || file.Length == 0)
        {
            throw new Exception("No file uploaded.");
        }

        var containerClient = await GetContainerClient(type.GetDisplayName());
        var fileId =  type switch
        {
            StorageType.Avatar => _userContext.UserId,
            StorageType.ProductImages => Guid.NewGuid(),
            _ => throw new NotImplementedException()
        };
        var blobClient = containerClient.GetBlobClient(fileId.ToString());

        var uploadOptions = new Azure.Storage.Blobs.Models.BlobUploadOptions
        {
            HttpHeaders = new Azure.Storage.Blobs.Models.BlobHttpHeaders
            {
                ContentType = file.ContentType
            }
        };

        using (var stream = file.OpenReadStream())
        {
            await blobClient.UploadAsync(stream, uploadOptions); 
        }
        return fileId;
    }
}

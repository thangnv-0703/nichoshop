using NichoShop.Domain.Enums;

namespace NichoShop.Application.Interfaces;

public interface IStorageService
{
    Task<Guid> UploadFromFileAsync(IFormFile file, StorageType type);
    Task<Guid> UploadFromByteDataAsync(byte[] data, StorageType type, string contentType = "application/octet-stream");
    Task<byte[]> DownloadFile(Guid fileId);
    Task DeleteFile(Guid fileId, StorageType type);
    Task<string> GetFileUrl(Guid fileId, StorageType type);
}

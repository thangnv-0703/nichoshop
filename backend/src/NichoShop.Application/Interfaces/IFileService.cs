using NichoShop.Domain.Enums;

namespace NichoShop.Application.Interfaces;

public interface IFileService
{
    Task<Guid> UploadFile(IFormFile file, StorageType type);
    Task<byte[]> DownloadFile(Guid fileId);
    Task DeleteFile(Guid fileId, StorageType type);
    Task<string> GetFileUrl(Guid fileId, StorageType type);
}

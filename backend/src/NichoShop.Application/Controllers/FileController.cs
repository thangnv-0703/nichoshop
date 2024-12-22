using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NichoShop.Application.Interfaces;
using NichoShop.Domain.Enums;
using System.Net;

namespace NichoShop.Application.Controllers;

[Route("api/v1/files")]
[ApiController]
public class FileControllerr(IFileService fileService) : Controller
{
    private readonly IFileService _fileService = fileService;

    [HttpGet("preview/{type}/{fileId}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetFileUrl(Guid fileId, StorageType type)
    {
        var result = await _fileService.GetFileUrl(fileId, type);
        return Ok(result);
    }

    [Authorize]
    [HttpPost("upload")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Upload([FromForm] IFormFile file, [FromForm] StorageType type)
    {
        var result = await _fileService.UploadFile(file, type);
        return Ok(result);
    }
}

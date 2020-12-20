using System.Threading.Tasks;
using OpenBook.Models;
using OpenBook.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace OpenBook.Controllers
{
    [Route("api/[controller]")]
    public class BlobsController : Controller
    {
        private readonly IBlobService _blobService;

        public BlobsController(IBlobService blobService)
        {
            _blobService = blobService;
        }

        [HttpGet("{blobName}")]
        public async Task<IActionResult> GetBlob(string blobName)
        {
            var data = await _blobService.GetBlobAsync(blobName);
            return File(data.Content, data.ContentType);
        }

        [HttpGet("list")]
        public async Task<IActionResult> ListBlobs()
        {
            return Ok(await _blobService.ListBlobsAsync());
        }

        [HttpPost("uploadfile")]
        public async Task<IActionResult> UploadFile([FromBody] UploadFileRequest request)
        {
            await _blobService.UploadContentBlobAsync(request.FilePath, request.FileName);
            return Ok();
        }

        [HttpPost("uploadcontent")]
        public async Task<IActionResult> UploadContent([FromBody] UploadContentRequest request)
        {
            await _blobService.UploadContentBlobAsync(request.Content, request.FileName);
            return Ok();
        }

        [HttpDelete("{blobName}")]
        public async Task<IActionResult> DeleteFile(string blobName)
        {
            await _blobService.DeleteBlobAsync(blobName);
            return Ok();
        }
    }
}

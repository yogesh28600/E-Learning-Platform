using MediaService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MediaService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly BlobService _blobService;

        public MediaController(BlobService blobService)
        {
            _blobService = blobService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (!file.ContentType.StartsWith("image/") && !file.ContentType.StartsWith("video/"))
            {
                return BadRequest("Only image and video files are allowed.");
            }
            if (file.ContentType.StartsWith("image/") && file.ContentType != "image/png")
            {
                return BadRequest("Only png format is supported.");
            }
            string uri = "";
            using (var stream = file.OpenReadStream())
            {
                uri = await _blobService.UploadBlobAsync(file.FileName, stream,file.ContentType);
            }

            return Ok(uri);
        }

        //[HttpGet("download/{filename}")]
        //public async Task<IActionResult> Download(string filename)
        //{
        //    var stream = await _blobService.DownloadBlobAsync(filename);
        //    return File(stream, "application/octet-stream", filename);
        //}

        //[HttpDelete("delete/{url}")]
        //public async Task<IActionResult> Delete(string url)
        //{
        //    string decodedUri = WebUtility.UrlDecode(url);
        //    await _blobService.DeleteBlobAsync(decodedUri);
        //    return Ok("File deleted successfully");
        //}
    }
}

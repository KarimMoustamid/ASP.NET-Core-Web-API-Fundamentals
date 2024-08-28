namespace CityInfo.API.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.StaticFiles;

    [Route("api/files")]
    [ApiController]
    public class Files : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public Files(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider;
        }

        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            var filePath = "assets/fileTest.pdf";

            if (!System.IO.File.Exists(filePath))
            {
                return this.NotFound();
            }

            // Attempt to retrieve the MIME type of the file. If not found, default to "application/octet-stream".
            if (!_fileExtensionContentTypeProvider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = System.IO.File.ReadAllBytes(filePath);
            return this.File(bytes, contentType, Path.GetFileName(filePath));
        }
    }
}
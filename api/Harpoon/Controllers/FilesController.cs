using Microsoft.AspNetCore.Mvc;
using System.Linq;

using O8Query.Data;

namespace Harpoon.Controllers
{
    [Route("api/[controller]")]
    public class FilesController : ControllerBase
    {
        private readonly BlobQuery _bq;

        public FilesController(BlobQuery bq)
        {
            _bq = bq;
        }

        // 
        // GET: /Files/
        [HttpGet]
        public IActionResult Get([FromQuery]long no)
        {
            var file = _bq.Files.Where(f => f.No == no).FirstOrDefault();

            return file == null ? NotFound() : File(file.Content, file.ContentType);
        }
    }
}
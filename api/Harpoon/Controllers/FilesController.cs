using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using O8Query.Models;
using O8Query.Data;

namespace Harpoon.Controllers
{
    [Route("api/[controller]")]
    public class FilesController : ControllerBase
    {
        private readonly StocksQuery _sq;

        public FilesController(StocksQuery sq)
        {
            _sq = sq;
        }

        // 
        // GET: /Files/
        [HttpGet]
        public IActionResult Get([FromQuery]long no)
        {
            var file = _sq.Files.Where(f => f.No == no).FirstOrDefault();

            return file == null ? NotFound() : File(file.Content, file.ContentType);
        }
    }
}
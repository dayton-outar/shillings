using Microsoft.AspNetCore.Mvc;

namespace Harpoon.Controllers
{
    [Route("api/[controller]")]
    public class FilesController : ControllerBase
    {
        // 
        // GET: /Files/
        [HttpGet]
        public string Get()
        {
            return "This is my default action...";
        }
    }
}


using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using O8Query.Data;
using O8Query.Models;

namespace Harpoon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StocksController : ControllerBase
    {
        private readonly StocksQuery _sqContext;

        public StocksController(StocksQuery sqContext)
        {
            _sqContext = sqContext;
        }

        public IEnumerable<StockTrading> Get()
        {
            return _sqContext.StockTradings.Where(e => e.Date.CompareTo(new System.DateTime( 2021, 4, 30 ) ) == 0 ).ToList();
        }
    }
}
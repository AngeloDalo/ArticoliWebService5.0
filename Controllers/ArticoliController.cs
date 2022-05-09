using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticoliWebService.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArticoliWebService.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/articoli")]
    public class ArticoliController : Controller
    {
        private IArticoliRepository articolirepository;

        public ArticoliController(IArticoliRepository articolirepository)
        {
            this.articolirepository = articolirepository;
        }

        [HttpGet("cerca/descrizione/{filter}")]
        [ProducesResponseType(400)]
        public IActionResult GetArticoliByDesc(string filter)
        {
            var articoli = this.articolirepository.SelArticoliByDescrizione(filter);

            return Ok(articoli);
        }

    }
}
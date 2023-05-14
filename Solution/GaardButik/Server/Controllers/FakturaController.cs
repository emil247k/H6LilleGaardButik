using GaardButik.Server.Handler;
using GaardButik.Shared.Command;
using Microsoft.AspNetCore.Mvc;

namespace GaardButik.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FakturaController : ControllerBase
    {
        private IFakturaCreateCommandHandler fakturaCreateCommandHandler;

        public FakturaController(IFakturaCreateCommandHandler fakturaCreateCommandHandler)
        {
            this.fakturaCreateCommandHandler = fakturaCreateCommandHandler;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FakturaCreateCommand fakturaCreateCommand)
        {
            var filepath = await fakturaCreateCommandHandler.Handle(fakturaCreateCommand);
            var faktura = System.IO.File.ReadAllBytes(filepath);
           
            return Ok(File(faktura, "application/msword", "Faktura.docx"));
        }
    }
}

using Kodius.AdminProizvodi;
using Kodius.Baza;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kodius.AdminStock;


namespace Kodius.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class AdminsController : Controller
    {
        private ApplicationDBContext _context;

        public AdminsController(ApplicationDBContext context)
        {
            _context = context;
        }


        [HttpGet("products")]
        public IActionResult GetProizvodi() => Ok(new UzmiProizvodeAdmin(_context).GetProizvodi());

        [HttpGet("products/{id}")]
        public IActionResult GetProizvod(int id) => Ok(new UzmiProizvodAdmin(_context).GetProizvod(id));

        [HttpPost("products")]
        public async Task<IActionResult> KreirajProizvod([FromBody] ModeliView.Proizvodi pv)
        {
            KreirajProizvod kp = new KreirajProizvod(_context);
            return Ok(await kp.Save(pv));
        }

        [HttpDelete("products/{id}")]
        public async Task<IActionResult> ObrisiProizvod(int id) => Ok(await new ObrisiProizvod(_context).Delete(id));

        [HttpPut("products")]
        public async Task<IActionResult> AzurirajProizvod([FromBody] ModeliView.Proizvodi pv) => Ok(await new AzurirajProizvod(_context).Update(pv));


        //Admin Stock

        [HttpGet("stocks")]
        public IActionResult GetStocks() => Ok(new GetStocks(_context).GetStock());

        [HttpPost("stocks")]
        public async Task<IActionResult> KreirajStock([FromBody] StockCreate.Request pv)
        {
            return Ok(await new StockCreate(_context).CreateSt(pv));
        }

        [HttpDelete("stocks/{id}")]
        public async Task<IActionResult> ObrisiStock(int id) => Ok(await new StockDelete(_context).Delete(id));

        [HttpPut("stocks")]
        public async Task<IActionResult> AzurirajStock([FromBody] StockUpdate.Request pv) => Ok(await new StockUpdate(_context).Update(pv));


        //Admin Orders

    }
}

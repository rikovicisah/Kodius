using Kodius.Baza;
using Kodius.Modeli;

namespace Kodius.AdminStock
{
    public class StockCreate
    {
        private ApplicationDBContext _context;

        public StockCreate(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Response> CreateSt(Request request)
        {
            Stock stock = new Stock();
            stock.kolicina = request.kolicina;
            stock.proizvodId = request.proizvodId;
            

            _context.Zaliha.Add(stock);
            await _context.SaveChangesAsync();

            return new Response
            {
                id = request.id,
                proizvodId = request.proizvodId,
                kolicina = request.kolicina,
            };
        }

        public class Request
        {
            public int id { get; set; }
            public int kolicina { get; set; }
            public int proizvodId { get; set; }
        }

        public class Response
        {
            public int id { get; set; }
            public int kolicina { get; set; }
            public int proizvodId { get; set; }
        }
    }
}

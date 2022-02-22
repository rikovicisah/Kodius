using Kodius.Baza;
using Kodius.Modeli;

namespace Kodius.AdminStock
{
    public class StockUpdate
    {
        private ApplicationDBContext _context;

        public StockUpdate(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Response> Update(Request requests)
        {
            var stocks = new List<Stock>();

            foreach(var stock in requests.Stock)
            {
                stocks.Add(new Stock{
                    Id = stock.id,
                    kolicina = stock.kolicina,
                    proizvodId = stock.proizvodId,
                });

            }

            _context.Zaliha.UpdateRange(stocks);
            await _context.SaveChangesAsync();

            return new Response
            {
                Stock = requests.Stock,
            };
        }


        public class StockViewModel
        {
            public int id { get; set; }
            public int kolicina { get; set; }
            public int proizvodId { get; set; }
        }

        public class Request
        {
            public IEnumerable<StockViewModel> Stock { get; set; }
        }

        public class Response
        {
            public IEnumerable<StockViewModel> Stock { get; set; }
        }
    }
}

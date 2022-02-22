using Kodius.Baza;
using Microsoft.EntityFrameworkCore;

namespace Kodius.AdminStock
{
    public class GetStocks
    {
        private ApplicationDBContext _context;

        public GetStocks(ApplicationDBContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductViewModel> GetStock()
        {
            var stock = _context.Proizvodi
                .Include(x => x.Stocks)
                .Select(x => new ProductViewModel {
                    Id = x.Id,
                    Stock = x.Stocks.Select(a => new StockViewModel
                    {
                        id = a.Id,
                        kolicina = a.kolicina,
                        productName = a.Proizvod.ProductName,
                    })
                })
                .ToList();



            return stock;
        }




        public class StockViewModel
        {
            public int id { get; set; }
            public int kolicina { get; set; }
            public string productName { get; set; }
        }

        public class ProductViewModel
        {
            public int Id { get; set; }
            public IEnumerable<StockViewModel> Stock { get; set; }
        }

    }
}

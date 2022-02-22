using Kodius.Baza;
using Kodius.Modeli;
using Microsoft.EntityFrameworkCore;

namespace Kodius.Proizvodi
{
    public class UzmiProizvod
    {
        private ApplicationDBContext _context;

        public UzmiProizvod(ApplicationDBContext context)
        {
            _context = context;
        }

        public ModeliView.Proizvodi GetProizvod(string name) {
            return _context.Proizvodi.Include(x => x.Stocks)
            .Where(x => x.ProductName == name)
                .Select(x => new ModeliView.Proizvodi
                {
                    ProductName = x.ProductName,
                    ProductPrice=x.ProductPrice,
                }).FirstOrDefault();
        }

        public class StockViewModel
        {
            public int Id { get; set; }
            public String? ProductName { get; set; }
            public decimal ProductPrice { get; set; }
            public bool IsInStock { get; set; }
        }


    }
}

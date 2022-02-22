using Kodius.Baza;
using Kodius.ModeliView;

namespace Kodius.AdminProizvodi
{
    public class UzmiProizvodAdmin
    {
        private ApplicationDBContext _context;

        public UzmiProizvodAdmin(ApplicationDBContext context)
        {
            _context = context;
        }

        public ProizvodiViewModel GetProizvod(int id)
        {
            return _context.Proizvodi.Where(x => x.Id == id)
                    .Select(x => new ProizvodiViewModel
                    {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    ProductPrice = x.ProductPrice
                    }).FirstOrDefault();
        }

        public class ProizvodiViewModel
        {
            public String? ProductName { get; set; }
            public decimal ProductPrice { get; set; }
            public int Id { get; internal set; }
        }

    }
}

using Kodius.Baza;
using Kodius.Modeli;
using Kodius.ModeliView;

namespace Kodius.AdminProizvodi
{
    public class KreirajProizvod
    {
        private ApplicationDBContext _context;

        public KreirajProizvod(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Response> Save(ModeliView.Proizvodi pv)
        {
            _context.Proizvodi.Add(new Proizvod
            {
                ProductName = pv.ProductName,
                ProductPrice = pv.ProductPrice
            });

            await _context.SaveChangesAsync();
            return new Response { 
                productName = pv.ProductName,
                productPrice = pv.ProductPrice,
                Id = pv.Id
            };
        }

        public class Response
        {
            public int Id { get; set; }
            public string productName { get; set; }
            public decimal productPrice { get; set; }
        }

    }
}

using Kodius.Baza;
using Kodius.Modeli;
using Kodius.ModeliView;
using Kodius.Modeli;

namespace Kodius.AdminProizvodi
{
    public class AzurirajProizvod
    {
        private ApplicationDBContext _context;

        public AzurirajProizvod(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Response> Update(ModeliView.Proizvodi pv)
        {
             
            var proizvod = _context.Proizvodi.FirstOrDefault(x => x.Id == pv.Id);
            if (proizvod != null)
            {
                proizvod.Id = pv.Id;
                proizvod.ProductName = pv.ProductName;  
                proizvod.ProductPrice = pv.ProductPrice;
            }
            await _context.SaveChangesAsync();
            return new Response
            {
                Id = pv.Id,
                productName = pv.ProductName,
                productPrice = pv.ProductPrice,
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

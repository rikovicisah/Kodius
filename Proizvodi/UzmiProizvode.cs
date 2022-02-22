using Kodius.Baza;
using Kodius.Modeli;
using Kodius.ModeliView;
using System.Linq;

namespace Kodius.Proizvodi
{
    public class UzmiProizvode
    {
        private ApplicationDBContext _context;

        public UzmiProizvode(ApplicationDBContext context)
        {
            _context = context;
        }

        public IEnumerable<ModeliView.Proizvodi> GetProizvodi()
        {
            List<Proizvod> proizvod = _context.Proizvodi.ToList<Proizvod>();
            IEnumerable<ModeliView.Proizvodi> proizvodv = new List<ModeliView.Proizvodi>();

            proizvodv = proizvod.Select(a => new ModeliView.Proizvodi() 
            { ProductName = a.ProductName, ProductPrice = a.ProductPrice });

            return proizvodv;
        }
    }

}

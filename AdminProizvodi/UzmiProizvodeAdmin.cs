using Kodius.Baza;
using Kodius.Modeli;
using Kodius.ModeliView;
using System.Linq;

namespace Kodius.AdminProizvodi
{
    public class UzmiProizvodeAdmin
    {
        private ApplicationDBContext _context;

        public UzmiProizvodeAdmin(ApplicationDBContext context)
        {
            _context = context;
        }

        public IEnumerable<ModeliView.Proizvodi> GetProizvodi()
        {
            List<Proizvod> proizvod = _context.Proizvodi.ToList<Proizvod>();
            IEnumerable<ModeliView.Proizvodi> proizvodv = new List<ModeliView.Proizvodi>();

            proizvodv = proizvod.Select(a => new ModeliView.Proizvodi() 
            { Id = a.Id, ProductName = a.ProductName, ProductPrice = a.ProductPrice });

            return proizvodv;
        }


    }

}

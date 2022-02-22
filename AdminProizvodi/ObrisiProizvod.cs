using Kodius.Baza;
using Kodius.ModeliView;

namespace Kodius.AdminProizvodi
{
    public class ObrisiProizvod
    {
        private ApplicationDBContext _context;

        public ObrisiProizvod(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            var proizvod = _context.Proizvodi.FirstOrDefault(x => x.Id == id);
            _context.Proizvodi.Remove(proizvod);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

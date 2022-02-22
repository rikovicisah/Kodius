using Kodius.Baza;

namespace Kodius.AdminStock
{
    public class StockDelete
    {
        private ApplicationDBContext _context;

        public StockDelete(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            var stock = _context.Zaliha.FirstOrDefault(x => x.Id == id);

            if (stock != null)
                _context.Zaliha.Remove(stock);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}

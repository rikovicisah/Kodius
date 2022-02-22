using Kodius.Baza;
using Kodius.ModeliView;
using Kodius.Proizvodi;
using Kodius.AdminProizvodi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json.Serialization;
using Kodius.Modeli;

namespace Kodius.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private ApplicationDBContext _context;

        [BindProperty]
        public ModeliView.Proizvodi Proizvodv { get; set; }
        public IEnumerable<ModeliView.Proizvodi> SviProizvodi { get; set; }

        public IndexModel(ApplicationDBContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }


        public void OnGet()
        {
            SviProizvodi = new UzmiProizvode(_context).GetProizvodi();
        }

        public async Task<IActionResult> OnPost()
        {

            KreirajProizvod kreirajProizvod = new KreirajProizvod(_context);
            await kreirajProizvod.Save(Proizvodv);

            return RedirectToPage("Index");
        }
    }
}
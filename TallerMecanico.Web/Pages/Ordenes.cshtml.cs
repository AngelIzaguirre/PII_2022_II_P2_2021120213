
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Packt.Shared;

namespace TallerMecanico.Web.Pages
{
    public class OrdenesModel : PageModel
    {
        private TallerMecanicoContext db;
        public OrdenesModel(TallerMecanicoContext injectedContext)
        {
            db = injectedContext;
        }
        public IEnumerable<Orden>? Orden { get; set; }

        public void OnGet()
        {
            ViewData["Title"] = "QIZA - Ordenes";
            Orden = db.Ordenes
                .OrderBy(c => c.OrdenId).ThenBy(c => c.ClienteId);
        }
        [BindProperty]
        public Orden? orden { get; set; }
        public IActionResult OnPost()
        {
            if ((orden is not null) && ModelState.IsValid)
            {
                db.Ordenes.Add(orden);
                db.SaveChanges();
                return RedirectToPage("/Ordenes");
            }
            else
            {
                return Page();
            }
        }
    }
}

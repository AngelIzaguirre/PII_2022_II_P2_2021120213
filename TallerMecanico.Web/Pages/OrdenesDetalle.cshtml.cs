
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Packt.Shared;

namespace TallerMecanico.Web.Pages
{
    public class OrdenesDetalleModel : PageModel
    {
        private TallerMecanicoContext db;
        public OrdenesDetalleModel(TallerMecanicoContext injectedContext)
        {
            db = injectedContext;
        }
        public IEnumerable<OrdenDetalle>? OrdenDetalle { get; set; }

        public void OnGet()
        {
            ViewData["Title"] = "QIZA - OrdenesDetalle";
            OrdenDetalle = db.OrdenDetalles
                .OrderBy(c => c.OrdenId).ThenBy(c => c.OrdenDetalleId);
        }
        [BindProperty]
        public OrdenDetalle? ordenDetalle { get; set; }
        public IActionResult OnPost()
        {
            if ((ordenDetalle is not null) && ModelState.IsValid)
            {
                db.OrdenDetalles.Add(ordenDetalle);
                db.SaveChanges();
                return RedirectToPage("/OrdenesDetalle");
            }
            else
            {
                return Page();
            }
        }
    }
}

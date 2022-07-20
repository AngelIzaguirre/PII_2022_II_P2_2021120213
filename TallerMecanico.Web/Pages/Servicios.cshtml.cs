using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Packt.Shared;

namespace TallerMecanico.Web.Pages
{
    public class ServiciosModel : PageModel
    {
        private TallerMecanicoContext db;
        public ServiciosModel(TallerMecanicoContext injectedContext)
        {
            db = injectedContext;
        }
        public IEnumerable<Servicio>? Servicios { get; set; }

        public void OnGet()
        {
            ViewData["Title"] = "QIZA - Servicios";
            Servicios = db.Servicios
                .OrderBy(c => c.ServicioId).ThenBy(c => c.Garantia);
        }
        [BindProperty]
        public Servicio? servicio { get; set; }
        public IActionResult OnPost()
        {
            if ((servicio is not null) && ModelState.IsValid)
            {
                db.Servicios.Add(servicio);
                db.SaveChanges();
                return RedirectToPage("/Servicios");
            }
            else
            {
                return Page();
            }
        }
    }
}
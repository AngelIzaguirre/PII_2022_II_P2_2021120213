
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Packt.Shared;

namespace TallerMecanico.Web.Pages
{
    public class ClientesModel : PageModel
    {
        private TallerMecanicoContext db;
        public ClientesModel(TallerMecanicoContext injectedContext)
        {
            db = injectedContext;
        }
        public IEnumerable<Cliente>? Cliente { get; set; }

        public void OnGet()
        {
            ViewData["Title"] = "QIZA - Proveedores";
            Cliente = db.Clientes
                .OrderBy(c => c.ClienteId).ThenBy(c => c.Nombre);
        }
        [BindProperty]
        public Cliente? cliente { get; set; }
        public IActionResult OnPost()
        {
            if ((cliente is not null)&& ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToPage("/Clientes");
            }
            else
            {
                return Page();
            }
        }
    }
}

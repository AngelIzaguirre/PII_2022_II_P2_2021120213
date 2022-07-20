using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Packt.Shared;

namespace TallerMecanico.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Packt.Shared.TallerMecanicoContext _context;

        public IndexModel(Packt.Shared.TallerMecanicoContext context)
        {
            _context = context;
        }

        public IList<Servicio> Servicio { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Servicios != null)
            {
                Servicio = await _context.Servicios.ToListAsync();
            }
        }
    }
}

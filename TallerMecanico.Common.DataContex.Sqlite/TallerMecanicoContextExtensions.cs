using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.Shared
{
    public static class TallerMecanicoContextExtensions
    {
        public static IServiceCollection AddTallerMecanicoContext(this IServiceCollection servicies,
           string relativePath = "..\\TallerMecanico.Common.DataContex.Sqlite\\bin\\Debug\\net6.0")
        {
            string databasePath = Path.Combine(relativePath, "TallerMecanico.db");
            servicies.AddDbContext<TallerMecanicoContext>(options => options.UseSqlite($"Data Source={databasePath}"));

            return servicies;            
        }
    }
}

using Packt.Shared;

namespace TallerMecanico.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddTallerMecanicoContext();
            
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseEndpoints(enpoints =>
            {
                enpoints.MapRazorPages();
                enpoints.MapGet("/",()=>"");

            });
        }
        
    }
}

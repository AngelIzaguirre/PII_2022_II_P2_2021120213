using TallerMecanico.Web;

Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
    }).Build().Run();
Console.WriteLine("Este se ejecuta despues de que se detiene el servidor");
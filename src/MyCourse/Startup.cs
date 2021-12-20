using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MyCourse
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            //  Tramite il metodo Configure possiamo definire quali Middlewer definiranno la nostra serie in ambiente Development e in ambiente 
            // Production.
        {
            //if (env.IsDevelopment()) 
            if (env.IsEnvironment("Development"))
                //All'interno del metodo Configure, se "ASPNETCORE_ENVIRONMENT" nel file lunchSettings.json
                //è Development allora vale il Middleware DeveloperExceptionPage che ha la responsabilità di fornire una pagina con indicato
                //in modo dettagliato il motivo dell'errore.
            {
                app.UseDeveloperExceptionPage();
            }

            //Questo è il Middleware (app.UseStaticFiles();) che consente all'applicazione di leggere file statici nella cartella wwwroot.
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //l'oggetto Httpcontext è quell'oggetto che il Web Server Kestrel, integrato in un  progetto dotnet
                //(che quindi non richiede l'utilizzo del web server esterno IIS), passa al codice dell'applicazione.
                //In questo caso l'oggetto context che ci viene passato come argomento è di tipo Httpcontext.
                //In questo caso abbiamo l'oggetto context che attraverso la sua proprietà Response e il suo metodo WriteAsync
                //ci permette di scrivere sulla Response "Hello {name}!"
                 
                endpoints.MapGet("/", async context =>
                {
                    //una volta lanciato in localhost digitare di seguito nella url ?nome=Linda e viene scritto Hello Linda!
                    string nome = context.Request.Query["nome"];
                    await context.Response.WriteAsync($"Hello {nome}!");
                });
            });
        }
    }
}

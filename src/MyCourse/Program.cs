using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MyCourse
{
    //La classe Program contiene il punto di ingresso della nostra applicazione.
    //Questa classe mette in condizione l'applicazione di ricevere richieste web dagli utenti.

    public class Program 
    {   
        //Il metodo Main, che è il primo che viene invocato dall'applicazione, serve a preparare il WebHost.
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        //Il WebHost è uno spazio che contiene tutti i componenti essenziali che servono all'applicazione per relazionarsi con il mondo esterno.
        //Tra i compnenti più importanti ci sono: Kestrel il web server, Logging (che ha lo scopo di produrre messaggi diagnostici
        //nella console, Configurazione (serve ad inviare parametri di funzionamento all'applicazione). Tutti questi componenti sono
        //personalizzabili ma per ora li lasciamo di default come scritto nel commento di riga 27.
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) //Questo crea un Web Host di default che a noi va bene, non lo personalizzaimo per ora.
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

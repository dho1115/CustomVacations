﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CustomVacations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if((args.Length > 0) && (args[0].ToLowerInvariant() == "scrape"))
            {
                Services.datascraperservice.scrape();
            }

            else 
            {
                BuildWebHost(args).Run();
            }

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}

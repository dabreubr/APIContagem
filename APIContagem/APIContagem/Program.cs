using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace APIContagem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dsa1 = new DSACryptoServiceProvider(); // Noncompliant - default key size is 1024
            var simpleDES = new DESCryptoServiceProvider(); // Noncompliant: DES works with 56-bit keys allow attacks via exhaustive search
            var tripleDES = new TripleDESCryptoServiceProvider();
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(1024); // Noncompliant

            CreateHostBuilder(args).Build().Run();

            Console.WriteLine("so far, so good..."); // Noncompliant
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

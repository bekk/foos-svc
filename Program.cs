using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace foos_svc
{
    public class Program
    {

        

        public static void Main(string[] args)
        {


            var playersRepository = new PlayersRepository(new SqlConnection("Server=localhost,1433;User=sa;Password=M1nj0bB9;Database=foos-db;"));
            Players player1 = new Players
            {
                Name = "Plaaaayaaa Nr1 32132312321 dsfafsdfdfdsfdsfds"
            };
            Players player2 = new Players
            {
                Name = "Spiller Nr2 23132121321 dasdsaddsasadsa ddd"
            };

            playersRepository.Add(player1);
            playersRepository.Add(player2);
            IEnumerable<Players> players = playersRepository.GetAll();

            foreach (var pl in players)
            {
                Console.WriteLine(pl.Name);
            }
            Console.ReadLine();

            CreateWebHostBuilder(args).Build().Run();


        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

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

            

            /*
            var playersRepository = new PlayersRepository(new SqlConnection("Server=localhost,1433;User=sa;Password=M1nj0bB9;Database=foos-db;"));
            Players player1 = new Players
            {
                Name = "Numero Unos",
                EmployeeId = 1

            };
            Players player2 = new Players
            {
                Name = "Numero doss",
                EmployeeId = 2
            };

            playersRepository.Add(player1);
            playersRepository.Add(player2);
            IEnumerable<Players> players = playersRepository.GetAll();

            foreach (var pl in players)
            {
                Console.WriteLine(pl.Name);
            }
            Console.ReadLine();
            
    */

            var matchesRepository = new MatchesRespository(new SqlConnection("Server=localhost,1433;User=sa;Password=M1nj0bB9;Database=foos-db;"));
            Matches match1a = new Matches
            {
                MatchId = 1,
                Name = "Numero Unos",
                IsWhite = true
            };
            Matches match1b = new Matches
            {
                MatchId = 1,
                Name = "Numero doss",
                IsWhite = false
            };

            matchesRepository.Add(match1a);
            matchesRepository.Add(match1b);
            IEnumerable<Matches> matches = matchesRepository.GetMatches();

            foreach (var m in matches)
            {
                Console.WriteLine(m.Name);
            }
            Console.ReadLine();



            CreateWebHostBuilder(args).Build().Run();



        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

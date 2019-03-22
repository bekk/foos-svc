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
            {
               "WhiteTeam" : {
               "Players" : 
                {
                "Name" : "Nr En!",
                "Name" : "Nr To"
                }
               "Score" : "10"
            },

               "BlueTeam" : {
                "Players" : 
                {
                "Name" : "Nr Tre",
                "Name" : "Nr Fire"
                }
               "Score" : "2"

            }
            
            }


        
            var playersRepository = new PlayersRepository(new SqlConnection("Server=localhost,1433;User=sa;Password=M1nj0bB9;Database=foos-db;"));
            Players player1 = new Players
            {
                Name = "Nr En",
                EmployeeId = 1

            };
            Players player2 = new Players
            {
                Name = "Nr To",
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
                

            var matchesRepository = new MatchesRespository(new SqlConnection("Server=localhost,1433;User=sa;Password=M1nj0bB9;Database=foos-db;"));
            Matches match1 = new Matches
            {
                MatchId = 1
            };

            matchesRepository.Add(match1);
            IEnumerable<Matches> matches = matchesRepository.GetMatches();

            foreach (var m in matches)
            {
                Console.WriteLine(m.MatchId);
            }
            Console.ReadLine();
            

            var teamsRepository = new TeamsRepository(new SqlConnection("Server=localhost,1433;User=sa;Password=M1nj0bB9;Database=foos-db;"));
            Teams team1 = new Teams
            {
                MatchId = 1,
                Name = "Nr En",
                IsWhite = true
            };
            Teams team2 = new Teams
            {
                MatchId = 1,
                Name = "Nr To",
                IsWhite = false
            };

            teamsRepository.Add(team1);
            teamsRepository.Add(team2);
            IEnumerable<Teams> teams = teamsRepository.GetTeams();
           

            var scoresRepository = new ScoresRepository(new SqlConnection("Server=localhost,1433;User=sa;Password=M1nj0bB9;Database=foos-db;"));
            Scores score1 = new Scores
            {
                MatchId = 1,
                IsWhite = true,
                Score = 5
            };
            Scores score2 = new Scores
            {
                MatchId = 1,
                IsWhite = false,
                Score = 10
            };
            scoresRepository.Add(score1);
            scoresRepository.Add(score2);
            IEnumerable<Scores> scores = scoresRepository.GetScores();
             */

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

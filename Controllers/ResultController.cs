using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace foos_svc
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private ScoresRepository _scoresRepository;
        private MatchesRespository _matchesRespository;
        private TeamsRepository _teamsRepository;
        
        public ResultController(ScoresRepository scoresRepository, MatchesRespository matchesRespository, TeamsRepository teamsRepository)
        {
            _scoresRepository = scoresRepository;
            _matchesRespository = matchesRespository;
            _teamsRepository = teamsRepository;
        }

        [HttpPost]
        public ActionResult<IEnumerable<string>> Post(ResultWriteModel resultWriteModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // MatchId
            var matchId = _matchesRespository.Add();


            // Teams
            IEnumerable<Teams> blueTeamMembers = resultWriteModel.BlueTeam.Players.Select(player => new Teams()
            {
                MatchId = matchId,
                Name = player,
                IsWhite = false
            });

            IEnumerable<Teams> whiteTeamMembers = resultWriteModel.WhiteTeam.Players.Select(player => new Teams()
            {
                MatchId = matchId,
                Name = player,
                IsWhite = true
            });

            IEnumerable<Teams> allTeamMembers = blueTeamMembers.Concat(whiteTeamMembers);
            var resultTeams = _teamsRepository.Add(allTeamMembers);


            // Scores
            Scores whiteScores = new Scores()
            {
                IsWhite = true,
                MatchId = matchId,
                Score = resultWriteModel.WhiteTeam.Score
            };

            Scores blueScores = new Scores()
            {
                IsWhite = false,
                MatchId = matchId,
                Score = resultWriteModel.BlueTeam.Score
            };

            IEnumerable<Scores> allScores = new List<Scores>()
            {
                whiteScores,
                blueScores
            };

            var resultScores =  _scoresRepository.Add(allScores);

            // Compile results
            int whiteScore = resultScores.Where(x => x.IsWhite == true).Select(x => x.Score).First();
            int blueScore = resultScores.Where(x => x.IsWhite == false).Select(x => x.Score).First();

            var whitePlayers = resultTeams.Where(x => x.IsWhite == true).Select(x => x.Name);
            var bluePlayers = resultTeams.Where(x => x.IsWhite == false).Select(x => x.Name);

            var resultWhiteTeam = new TeamWriteModel()
            {
                Players = whitePlayers,
                Score = whiteScore
            };

            var resultBlueTeam = new TeamWriteModel()
            {
                Players = bluePlayers,
                Score = blueScore
            };


            var resultAll = new CompleteResultWriteModel()
            {
                WhiteTeam = resultWhiteTeam,
                BlueTeam = resultBlueTeam,
                MatchId = matchId
            };

            return Ok(resultAll);


        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace foos_svc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {

        private ScoresRepository _scoresRepository;
        public ScoresController(ScoresRepository scoresRepository)
        {
            _scoresRepository = scoresRepository;
        }

        // GET: api/Match
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            IEnumerable<Scores> scores = _scoresRepository.GetScores();
            return Ok(scores);
        }

        // POST: api/Match
        [HttpPost]
        public ActionResult<IEnumerable<string>> Post(Scores score)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var scoreR = _scoresRepository.Add(score);
            return Ok(scoreR);
        }

    }
}

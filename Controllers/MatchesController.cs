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
    public class MatchesController : ControllerBase
    {
        private MatchesRespository _matchesRepository;
        public MatchesController(MatchesRespository matchesRepository)
        {
            _matchesRepository = matchesRepository;
        }


        // GET: api/Match
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            IEnumerable<Matches> matches = _matchesRepository.GetMatches();
            return Ok(matches);
        }


        // POST: api/Match
        [HttpPost]
        public ActionResult<int> Post()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var matchId = _matchesRepository.Add();
            return Ok(matchId);
        }
    }
}

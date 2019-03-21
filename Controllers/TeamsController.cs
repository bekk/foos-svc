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
    public class TeamsController : ControllerBase
    {


        private TeamsRepository _teamsRepository;
        public TeamsController(TeamsRepository teamsRepository)
        {
            _teamsRepository = teamsRepository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            IEnumerable<Teams> teams = _teamsRepository.GetTeams();
            return Ok(teams);
        }


        // POST api/values
        [HttpPost]
        public ActionResult<IEnumerable<string>> Post(Teams team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (true == _teamsRepository.Add(team))
            {
                return Ok(team);
            }
            return BadRequest();

        }
    }
}
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
    public class PlayersController : ControllerBase
    {
        private PlayersRepository _playersRepository;
        public PlayersController(PlayersRepository playersRepository)
        {
           _playersRepository = playersRepository;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            IEnumerable<Players> players = _playersRepository.GetAll();
            return Ok(players);
        }


        // POST api/values
        [HttpPost]
            public ActionResult<IEnumerable<string>> Post(Players player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (true == _playersRepository.Add(player))
            {
                return Ok(player);
            }
            return BadRequest();

        }
    
    }
}

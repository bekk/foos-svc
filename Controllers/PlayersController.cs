using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data.SqlClient;


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

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<IEnumerable<string>> Put(int id, Players player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            player.EmployeeId = id;
            var result = _playersRepository.Update(player);

            if (result == true)
            {
                return Ok(player);
            }
            return NotFound();

        }

    }
}

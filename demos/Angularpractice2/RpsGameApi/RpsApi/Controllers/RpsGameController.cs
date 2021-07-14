using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelsLibrary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RpsGameApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RpsGameController : ControllerBase
	{
		private readonly ILogger<RpsGameController> _logger;

		private readonly IRpsGame _rpsGame;
		//create a constructor into which i'll inject the business layer.
		public RpsGameController(IRpsGame rpsGame, ILogger<RpsGameController> logger)
		{
			this._rpsGame = rpsGame;
			this._logger = logger;
		}
		// GET: api/<RpsGame>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "Mark", "Moore" };
		}

		// GET api/<RpsGame>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<RpsGame>
		[HttpPost]
		public string Post([FromBody] string value)
		{
			return value;
		}

		// PUT api/<RpsGame>/5
		[HttpPut("{id}")]
		public string Put(int id, [FromBody] string value)
		{
			return value;
		}

		// DELETE api/<RpsGame>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			//you would call the business layer and pass the id to delete that id.
		}

		[HttpGet("PlayerList")]
		public async Task<IEnumerable<PlayerDerivedClass>> PlayerList()
		{
			List<PlayerDerivedClass> playerList = await _rpsGame.PlayerListAsync();
			return playerList;
		}

		[HttpPost("CreateNewPlayer")]
		public async Task<ActionResult> CreateNewPlayer(PlayerDerivedClass p)
		{
			//check that the model binding worked.
			if (!ModelState.IsValid)
			{
				RedirectToAction("Create");
			}

			// injecting the interface allows you to Mock the implementation in the testing suite.
			PlayerDerivedClass newPlayer = await _rpsGame.RegisterPlayerAsync(p);

			if (newPlayer != null)
			{
				//PlayerDerivedClass mockPlayer = new PlayerDerivedClass()
				//{
				//	City = "mycity",
				//	Fname = "mark",
				//	Lname = "moore",
				//	MyAge = 12,
				//	MyCountry = "usa",
				//	PersonId = 100,
				//	State = "tx",
				//	Street = "123 main"
				//};
				return Created("website.com/this/method/doesnt/exist/yet", newPlayer);
			}
			else
			{
				return NotFound($"This add a player action was not successful.");
			}
		}
	}//EoC
}//EoN

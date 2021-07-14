using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelsLibrary;
using RepositoryLayer;
using Xunit;
//you can give the page an alias to differentiate between ambiguously named duos.
using BRpsGame = BusinessLayer.RpsGame;

namespace RpsGame.Tests
{

	public class UnitTest1
	{
		//create the in-memory Db //  installed EF Core
		DbContextOptions<RpsGameDb> options = new DbContextOptionsBuilder<RpsGameDb>()
	.UseInMemoryDatabase(databaseName: "TestingDb")
	.Options;

		[Fact]
		public async Task RegisterPlayerInsertsPlayerCorrectly()
		{
			// arrange
			//createa a player to inset into the inmemory db.
			PlayerDerivedClass pdc = new PlayerDerivedClass()
			{
				City = "city",
				Fname = "Fname",
				Lname = "Lname",
				MyAge = 1,
				MyCountry = "Canada",
				State = "Oklahoma",
				Street = "321 niam"
			};
			PlayerDerivedClass pdc12;
			PlayerDerivedClass pdc1;

			using (var context = new RpsGameDb(options))
			{
				context.Database.EnsureDeleted();// delete any Db fro a previous test
				context.Database.EnsureCreated();// create anew the Db... you will need ot seed it again.
				context.Players.Add(pdc);
				context.SaveChanges();
				pdc1 = context.Players.Where(x => x.Fname == "Fname").FirstOrDefault();
			}

			// act
			// add to the In-Memory Db
			//instantiate the inmemory db
			using (var context = new RpsGameDb(options))
			{
				//verify that the db was deleted and created anew
				context.Database.EnsureDeleted();// delete any Db fro a previous test
				context.Database.EnsureCreated();// create anew the Db... you will need ot seed it again.

				//instantiate the RpsGameClass that we are going to unit test
				BRpsGame rpsGame = new BRpsGame(context);
				pdc12 = await rpsGame.RegisterPlayerAsync(pdc);

				context.SaveChanges();
				//}

				//assert
				// verify the the result was as expected
				//using (var context = new RpsGameDb(options))
				//{
				int amt = await context.Players.CountAsync();
				pdc.PersonId = 1;
				var p = context.Players.Where(x => x.Fname == "Fname").FirstOrDefault();
				//Assert.True(result);
				Assert.Equal(1, amt);
				Assert.NotNull(p);
				Assert.Contains(pdc1, context.Players);
				Assert.Equal(pdc1, p);

			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelsLibrary;
using RepositoryLayer;

namespace BusinessLayer
{
	public class RpsGame : IRpsGame
	{
		//SIDEBAR//
		/*EXAMPLE*/
		//parentClass pc = new ChildClass();
		//childClass cc = (childClass)pc;// type define the parent class variable as a child class.
		/* even if the chils class adds methods tohte parent implementation, 
		 * the parent variable only gives the user acces to the parent methods.
		*/


		private readonly RpsGameDb _context;
		// create constructors.
		//first register the context in startup.cs
		public RpsGame(RpsGameDb context)
		{
			this._context = context;
		}

		/// <summary>
		/// Saves a new player ot the Db. If un successful, returns false, otherwise TRUE.
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public async Task<PlayerDerivedClass> RegisterPlayerAsync(PlayerDerivedClass p)
		{
			//create a try/catch to save the player
			await _context.Players.AddAsync(p);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				Console.WriteLine($"There was a problem updating the Db => {ex.InnerException}");
				return null;
			}
			catch (DbUpdateException ex)
			{       //change this to logging
				Console.WriteLine($"There was a problem updating the Db => {ex.InnerException}");
				return null;
			}

			var x1 = await _context.Players.MaxAsync(x => x.PersonId);
			PlayerDerivedClass p1 = await _context.Players.Where(x => x.PersonId == x1).FirstOrDefaultAsync();
			if(p1 == null)
            {
				return null;
            }
            else
            {
				return p1;
            }
		}

		public async Task<List<PlayerDerivedClass>> PlayerListAsync()
		{
			List<PlayerDerivedClass> ps = null;
			try
			{
				ps = await _context.Players.ToListAsync();
			}
			catch (ArgumentNullException ex)
			{
				Console.WriteLine($"There was a problem getting the players list => {ex.Message}");
			}
			return ps;
		}
	}
}

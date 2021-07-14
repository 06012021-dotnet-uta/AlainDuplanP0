using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelsLibrary;


namespace RepositoryLayer
{
	public class RpsGameDb : DbContext
	{
		public DbSet<PlayerDerivedClass> Players { get; set; }
		public DbSet<GameModel> Games { get; set; }
		public DbSet<RoundClass> Rounds { get; set; }

		//create constructor
		public RpsGameDb() { }
		public RpsGameDb(DbContextOptions options) : base(options) { }

		// override OnConfiguring()
		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			//check if the options have already been configured in the testing suite.
			//if (!options.IsConfigured)
			//{
			//	options.UseSqlServer("Server=localhost\\SQLEXPRESS04;Database=CodeFirst_RpsGameDb;Trusted_Connection=True;");
			//}
		}


	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsLibrary;

namespace BusinessLayer
{
	public interface IRpsGame
	{
		Task<PlayerDerivedClass> RegisterPlayerAsync(PlayerDerivedClass p);
		Task<List<PlayerDerivedClass>> PlayerListAsync();
	}
}

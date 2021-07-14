using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
	public interface Interface1 : Interface2
	{
		int FirstInt();
		string FirstString(string x);
	}
}

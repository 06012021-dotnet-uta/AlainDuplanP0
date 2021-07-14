using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
	public class ClassWithTwoInterfaces : Interface1
	{
		public int FirstInt()
		{
			throw new NotImplementedException();
		}

		public string FirstString(string x)
		{
			throw new NotImplementedException();
		}

		public int SecondInt()
		{
			throw new NotImplementedException();
		}

		public string SecondString(string x)
		{
			throw new NotImplementedException();
		}
	}
}

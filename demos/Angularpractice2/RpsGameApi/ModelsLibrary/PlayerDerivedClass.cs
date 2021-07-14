using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary
{
	public class PlayerDerivedClass : PersonBaseClass
	{
		//private string _state;
		[Required(ErrorMessage = "This field is required, Jabroni-1!")]
		[MaxLength(30)]
		public string Street { get; set; }
		[Required(ErrorMessage = "This field is required, Jabroni -2!")]
		[MaxLength(30)]
		public string State { get; set; }
		[Required(ErrorMessage = "This field is required, Jabroni!-3")]
		[MaxLength(30)]
		public string City { get; set; }

		private int _myAge;

		[Required(ErrorMessage = "This field is required, Jabroni!-4")]
		[Range(0, 125)]
		public int MyAge
		{
			get
			{
				return this._myAge;
			}
			set
			{
				if (value < 125 && value > 0)
				{
				//make sure to change this to the value
					_myAge = value;
				}
			}
		}

		public PlayerDerivedClass() : base() { }

		//I must create all overload constructors in derived classes
		public PlayerDerivedClass(string fname, string lname, int age = 0) : base(fname, lname)
		{
			this.MyAge = age;
		}

		public override string GetFullAddress()
		{
			string fullAddy = $"{Fname} {Lname}\n{Street}\n{City}, {State}.";

			return fullAddy;
		}
	}
}

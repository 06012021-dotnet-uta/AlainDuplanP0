using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary
{
	public class PersonBaseClass
	{
		[Key]
		public int PersonId { get; set; }

		private string _fname;

		[Required]
		[MaxLength(20)]
		[Display(Name = "First Name")]
		public string Fname
		{
			get
			{
				return _fname;
			}
			set
			{
				if (value.Length <= 20 && value.Length >= 1)
				{
					_fname = value;
				}
			}
		}

		private string _lname;

		[Required]
		[MaxLength(20)]
		[Display(Name = "Last Name")]
		public string Lname
		{
			get
			{
				return _lname;
			}
			set
			{
				if (value.Length <= 20 && value.Length >= 1)
				{
					_lname = value;
				}
			}
		}
		private string myCountry;
		//unmodified Properties create an invisible private field that the data is stored to.

		/*this is a property. it includes the getter and setter.
		 you have to create a private variable when you modify the basic Property get and set methods.*/
		[Required(ErrorMessage = "This property is required")]
		public string MyCountry
		{
			get//this will return the private variable
			{
				return myCountry;
			}
			set // this can validate the value sent in or even the authorization of the user before setting the private value
			{
				if (value != null)
				{
					myCountry = value;
				}
				else
				{
					Console.WriteLine("there was no country submitted");
				}
			}
		}

		//default parameterless constructor performs setup in the class.
		public PersonBaseClass()
		{
			Fname = "defaultFname";
			Lname = "defaultLname";
			//MyCountry = "'tis of thee";
		}

		//this override constructor will be called with you instantiate the class instance and provide
		// the fname and lname at the same time.
		public PersonBaseClass(string fname, string lname)
		{
			this.Fname = fname;
			this.Lname = lname;
		}

		public virtual string GetFullAddress()
		{
			string fullName = $"{Fname} {Lname}.";
			return fullName;
		}
	}
}

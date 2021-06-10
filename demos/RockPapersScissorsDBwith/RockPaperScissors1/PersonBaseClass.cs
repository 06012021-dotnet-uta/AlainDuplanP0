using System;

namespace RockPaperScissors1
{
    public class PersonBaseClass
    {
        private string _fname;
        public string Fname
        {
            get
            {
                return _fname;
            }
            set
            {
                if (value.Length > 20 || value.Length < 1)
                    throw new InvalidOperationException("that name is invalid");
                _fname = value;
            }
        }
        private string _lname;
        public string Lname
        {
            get
            {
                return _lname;
            }
            set
            {
                if (value.Length > 20 || value.Length < 1)
                    throw new InvalidOperationException("that name is invalid");
                _lname = value;
            }
        }
        private string myCountry;
        //unmodified Properties create an invisible private field that the data is stored to.

        //this is a property. it includes the getter and setter.
        // you have to create a private variable when you modify the basic Property get and set methods.
        public string MyCountry
        {
            get//this will return the private variable
            {
                return myCountry;
            }
            set // this can validate the value sent in or even the authorization of the user before setting the private value
            {
                if (value != null)
                    myCountry = value;
                else
                    Console.WriteLine("um where do you live?");
            }
        }
        //default parameterless constructor performs setup in the class.
        public PersonBaseClass()
        {
            Fname = "defaultFname";
            Lname = "defaultLname";
            MyCountry = "Earth";
        }
        //this override constructor will be called with you instantiate the class instance and provide
        // the fname and lname at the same time.
        public PersonBaseClass(string fname, string lname)
        {
            this.Fname = fname;
            this.Lname = lname;
        }
        public string getFullName(){
            string fullName = $"{Fname} {Lname}";
            return fullName;
        }
        public virtual string GetFullAddress()
        {
            string fullName = $"{Fname} {Lname}";
            return fullName;
        }

    }
}
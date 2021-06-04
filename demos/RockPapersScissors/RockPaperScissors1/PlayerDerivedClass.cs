using System;

namespace RockPaperScissors1
{
    public class PlayerDerivedClass : PersonBaseClass
    {
        public string Street { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int choice { get ; set; }
        public int wins { get ; set; }

        public int gameWins  { get ; set; }

        private int myAge;
        public int MyAge
        {
            get
            {
                return this.myAge;
            }
            set
            {
                if (value > 125 || value < 0)
                    throw new InvalidOperationException("that age is invalid.");
            }
        }

        public PlayerDerivedClass() : base()
        {
            choice = 1;
            wins = 0;
            gameWins = 0;
        }

        //I must create all overload constructors in derived classes
        public PlayerDerivedClass(string fname, string lname, int age = 0) : base(fname, lname)
        {
            this.MyAge = age;
            choice = 1;
            wins = 0;
            gameWins = 0;
        }

        public override string GetFullAddress()
        {
            string fullAddy = $"{Fname} {Lname}\n{Street}\n{City}, {State}.";

            return fullAddy;
        }



    }
}
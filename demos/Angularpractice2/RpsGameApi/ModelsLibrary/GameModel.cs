using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary
{
	public class GameModel
	{

		[Key]
		public int GameModelId { get; set; }

		[Required]
		public PlayerDerivedClass Player1 { get; set; }//user

		[Required]
		public PlayerDerivedClass Player2 { get; set; }// computer

		// integer type isn't a reference type
		//[ForeignKey("Player1Choice")]
		[NotMapped]
		public List<int> Player1RoundChoices { get; set; }//all the choices that the user makes during the game

		//[ForeignKey("ComputerChoice")]
		[NotMapped]
		public List<int> Computer2RoundChoices { get; set; }//all the choices that the computer makes during the game

		public GameModel()
		{
			this.Player1RoundChoices = new List<int>();
			this.Computer2RoundChoices = new List<int>();
		}

		//public void AddRoundToPlayer1(int a, int x)
		//{
		//	if (a == 1)
		//	{
		//		Player1RoundChoices.Add(x);
		//	}
		//	else if (a == 2)
		//	{
		//		Computer2RoundChoices.Add(x);
		//	}
		//}


	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary
{
	public class RoundClass
	{
		[Key]
		public int RoundClassId { get; set; }

		// this is a FK
		//[Required]
		public GameModel Game { get; set; }

		// these represent the Choice Enum
		public int Player1Choice { get; set; }
		public int ComputerChoice { get; set; }
	}
}

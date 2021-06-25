using System;
using Xunit;
using RockPaperScissors1;

namespace RpsGame.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            //Arrange
            int x = 5;
            int y = 6;

            //Act
            int z = x + y;

            //Assert
            Assert.Equal(11, z);

            

        }

        [Fact]
        public void WelcomeMessageReturnsCorrectMessage(){
            //Arrange
            RockPaperScissors1.RpsGame game = new RockPaperScissors1.RpsGame();

            //Act
            string WelcomeMessageTest = game.WelcomeMessage();

            //Assert
            Assert.Equal("Welcome to Janken! \nWhat is your name?", WelcomeMessageTest                                                                                                                           );

        }

        [Theory]
        //[InlineData(1,2)]
        //[InlineData(2,3)]
        //[InlineData(3,1)]
        public void EvavulateRoundWinnerReturnsCorrectWinner(int a, int b){
            //Arrange
            RockPaperScissors1.RpsGame game = new RockPaperScissors1.RpsGame();

            //Act
            int result = 0;

            //Assert
            Assert.Equal(2, result);


        }
    }
}

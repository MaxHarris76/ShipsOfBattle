namespace Battleship.Test
{
    public class ExampleTest
    {
        //[Fact]
        //public void TestPlay()
        //{
        //    var ships = new[] { "3:2,3:5" };
        //    var guesses = new[] { "7:0", "3:3" };
        //    Game.Play(ships, guesses).Should().Be(0);
        //}



        //[Fact]
        //public void TestPlay2()
        //{
        //    var ships = new[] { "3:2,3:5", "2:6,2:9" };
        //    var guesses = new[] { "3:2", "3:3", "3:4", "3:5", "5:6"};
        //    Game.Play(ships, guesses).Should().Be(1);
        //}

        [Fact]
        public void TestPlay3()
        {
            var ships = new[] { "3:2,3:5", "2:6,2:7" };
            var guesses = new[] { "3:2", "3:3", "3:4", "3:5", "2:6","2:7"  };
            Game.Play(ships, guesses).Should().Be(2);
        }
    }
}
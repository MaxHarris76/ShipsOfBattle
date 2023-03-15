namespace Battleship.Test
{

    // Edge cases further down

    public class ExampleTest
    {
        // No sunken ships
        [Fact]
        public void TestPlay()
        {
            var ships = new[] { "3:2,3:5" };
            var guesses = new[] { "7:0", "3:3" };
            Game.Play(ships, guesses).Should().Be(0);
        }

        // One sunken x axis ship, one missed ship
        [Fact]
        public void TestPlay2()
        {
            var ships = new[] { "3:2,3:5", "2:6,2:9" };
            var guesses = new[] { "3:2", "3:3", "3:4", "3:5", "5:6" };
            Game.Play(ships, guesses).Should().Be(1);
        }

        // 2 sunken x-axis ships
        [Fact]
        public void TestPlay3()
        {
            var ships = new[] { "3:2,3:5", "2:6,2:7" };
            var guesses = new[] { "3:2", "3:3", "3:4", "3:5", "2:6", "2:7" };
            Game.Play(ships, guesses).Should().Be(2);
        }

        // 2 sunken x-axis ships with extra wrong guesses
        [Fact]
        public void TestPlay4()
        {
            var ships = new[] { "3:2,3:5", "2:6,2:7" };
            var guesses = new[] { "3:2", "3:3", "6:9", "3:4", "3:5", "2:6", "2:7" };
            Game.Play(ships, guesses).Should().Be(2);
        }

        // 2 sunken x-axis ships with jumbled guesses
        [Fact]
        public void TestPlay5()
        {
            var ships = new[] { "3:2,3:5", "2:6,2:7", "6:3, 6:7" };
            var guesses = new[] { "3:2", "3:3", "6:9", "3:4", "3:5", "2:6", "2:7" };
            Game.Play(ships, guesses).Should().Be(2);
        }

        // 3 sunken x axis ships
        [Fact]
        public void TestPlay6()
        {
            var ships = new[] { "3:2,3:5", "2:6,2:7", "6:3, 6:5" };
            var guesses = new[] { "6:5", "3:2", "3:3", "6:3", "3:4", "3:5", "6:4", "2:6", "2:7" };
            Game.Play(ships, guesses).Should().Be(3);
        }

        // Y- axis sunken ship
        [Fact]
        public void TestPlay7()
        {
            var ships = new[] { "3:5,3:2" };
            var guesses = new[] { "3:2", "3:3", "3:4", "3:5" };
            Game.Play(ships, guesses).Should().Be(1);
        }


        // ********** EDGE CASES **********

        // Backward sunken x-axis ship
        [Fact]
        public void TestPlay8()
        {
            var ships = new[] { "3:5,3:2" };
            var guesses = new[] { "3:2", "3:3", "3:4", "3:5" };
            Game.Play(ships, guesses).Should().Be(1);
        }


        // Mixture of forward and backward facing x-axis ships, 2 sunk ships
        [Fact]
        public void TestPlay9()
        {
            var ships = new[] { "3:5,3:2", "7:6,7:8", "1:2,1:4" };
            var guesses = new[] { "3:2", "3:3", "3:4", "3:5", "7:6", "7:7","7:8" };
            Game.Play(ships, guesses).Should().Be(2);
        }

        // Y axis ship
        [Fact]
        public void TestPlay10()
        {
            var ships = new[] { "5:9,8:9", "1:2,1:4" };
            var guesses = new[] { "5:9", "6:9", "7:9", "8:9", "7:6", "7:7", "7:8" };
            Game.Play(ships, guesses).Should().Be(1);
        }

        // Backwards Y axis ship
        [Fact]
        public void TestPlay11()
        {
            var ships = new[] { "8:9,5:9", "1:2,1:4" };
            var guesses = new[] { "5:9", "6:9", "7:9", "8:9", "7:6", "7:7", "7:8" };
            Game.Play(ships, guesses).Should().Be(1);
        }

        // Backwards Y axis and X axis ship
        [Fact]
        public void TestPlay12()
        {
            var ships = new[] { "8:9,5:9", "1:4,1:2" };
            var guesses = new[] { "5:9", "6:9", "7:9", "8:9", "7:6", "7:7", "7:8" };
            Game.Play(ships, guesses).Should().Be(1);
        }
    }
}
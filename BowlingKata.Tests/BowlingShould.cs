using BowlingKata.Src;
using NUnit.Framework;

namespace BowlingKata.Tests
{
    [TestFixture]
    public class BowlingShould
    {
        [TestCase("--|--|--|--|--|--|--|--|--|--|", 0)]
       
        public void return_zero_for_all_gutter_game(string game, int expectedScore)
        {
            var bowling = new Bowling();

            var score = bowling.CalculateScore(game);

            Assert.That(score, Is.EqualTo(expectedScore));
        }
    }
}

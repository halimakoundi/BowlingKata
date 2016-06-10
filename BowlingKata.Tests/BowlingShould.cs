using BowlingKata.Src;
using NUnit.Framework;

namespace BowlingKata.Tests
{
    [TestFixture]
    public class BowlingShould
    {
        [TestCase("11|11|11|11|11|11|11|11|11|11|", 20)]
        public void return_sum_of_rolls_for_normal_game(string game, int expectedScore)
        {
            var bowling = new Bowling();

            var score = bowling.CalculateScore(game);

            Assert.That(score, Is.EqualTo(expectedScore));
        }
    }
}

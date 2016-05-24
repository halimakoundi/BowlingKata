using BowlingKata.Src;
using NUnit.Framework;

namespace BowlingKata.Tests
{
    [TestFixture]
    public class BowlingShould  
    {
        [Test]
        public void return_zero_for_all_gutter_game()
        {
            var bowling = new Bolwing();

            var score = bowling.CalculateScore("--|--|--|--|--|--|--|--|--|--|");

            Assert.That(score, Is.EqualTo(0));
        }
    }
}

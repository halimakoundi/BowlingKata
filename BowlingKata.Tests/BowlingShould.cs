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
            var bowling = new Bowling();

            var score = bowling.CalculateScore("--|--|--|--|--|--|--|--|--|--|");

            Assert.That(score, Is.EqualTo(0));
        }

        [Test]
        public void return_one_for_one_pin_hit()
        {
            var bowling=new Bowling();

            var score = bowling.CalculateScore("1-|--|--|--|--|--|--|--|--|--|");

            Assert.That(score, Is.EqualTo(1));
        }
    }
}

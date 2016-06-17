using System.Linq;

namespace BowlingKata.Src
{
    public class Bowling
    {
        public int CalculateScore(string game)
        {
            return  new Parser().GetFrames(game).Sum(f => f.Score());
        }
    }
}
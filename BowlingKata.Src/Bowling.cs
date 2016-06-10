using System;

namespace BowlingKata.Src
{
    public class Bowling
    {
        private int _calculateScore;

        public int CalculateScore(string game)
        {
            var gameResults = game.Split(new string[] { "||" },
                StringSplitOptions.RemoveEmptyEntries)[0];
            var frames = gameResults.Split(new string[] { "|" },
                StringSplitOptions.RemoveEmptyEntries);
            foreach (var frame in frames)
            {
                int rollscore = 0;
                Int32.TryParse(frame[0].ToString(),out rollscore);
                _calculateScore += rollscore +
                    Convert.ToInt32(frame[1].ToString());
            }
            return _calculateScore;
        }
    }
}
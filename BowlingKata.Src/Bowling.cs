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
                int roll1score = 0;
                int roll2score = 0;
                Int32.TryParse(frame[0].ToString(),out roll1score);
                Int32.TryParse(frame[1].ToString(), out roll2score);

                _calculateScore += roll1score +
                    roll2score;
            }
            return _calculateScore;
        }
    }
}
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
                _calculateScore += Convert.ToInt32(frame[0].ToString()) +
                    Convert.ToInt32(frame[1].ToString());
            }
            return _calculateScore;
        }
    }
}
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
                _calculateScore += RollScore(frame, 0) +
                    RollScore(frame, 1);
            }
            return _calculateScore;
        }

        private static int RollScore(string frame, int index)
        {
            int rollScore;
            if (frame[index] == '/')
            {
                return rollScore = 10;
            }
            int.TryParse(frame[index].ToString(), out rollScore);
            return rollScore;
        }
    }
}
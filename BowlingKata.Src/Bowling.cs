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
            for (int i = 0; i < frames.Length; i++)
            {
                var frame = frames[i];
                var frameScore = RollScore(frame, 0) +
                                     RollScore(frame, 1);
                if (frameScore == 10)
                {
                    if (i < frames.Length - 1)
                    {
                        var nextFrame = frames[i + 1];
                        frameScore += RollScore(nextFrame, 0);
                    }
                    else
                    {
                        var bonusRolls = game.Split(new string[] { "||" },
                            StringSplitOptions.RemoveEmptyEntries)[1];
                        var nextFrame = bonusRolls;
                        frameScore += RollScore(nextFrame, 0);
                    }
                }
                _calculateScore += frameScore;
            }
            return _calculateScore;
        }

        private static int RollScore(string frame, int index)
        {
            int rollScore;
            if (frame[index] == '/')
            {
                return rollScore = 10 - RollScore(frame, index - 1);
            }
            int.TryParse(frame[index].ToString(), out rollScore);
            return rollScore;
        }
    }
}
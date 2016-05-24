using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingKata.Src
{
    public class Bowling
    {
        public int CalculateScore(string game)
        {
            var rolls = game.ToRolls();

            return rolls.Sum();
        }
    }

    public static class FrameExtensions
    {
        public static int RollScore(this string frame, int index)
        {
            int score;
            Int32.TryParse(frame[index].ToString(), out score);
            return score;
        }

        public static IEnumerable<int> ToRolls(this string game)
        {
            return game
                .Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries)
                .SelectMany(frame =>
                {
                    var first = frame.RollScore(0);
                    var second = frame.RollScore(1);
                    return new[] { first, second };
                });
        }
    }
}
using System;
using System.Linq;

namespace BowlingKata.Src
{
    public class Bowling
    {
        public int CalculateScore(string game)
        {
            int[] rolls = game.ToRolls();

            return TotalScore(rolls);
        }

        private static int TotalScore(int[] rolls)
        {
            int totalScore = 0;
            var firstRollOfTheTenthFrame = rolls.Length - 2;

            for (int index = 0; index < firstRollOfTheTenthFrame; index++)
            {
                var frameScore = rolls[index] + rolls[index + 1];
                if (frameScore == 10)
                {
                    totalScore += frameScore + rolls[index + 2];
                }
            }
            return totalScore;
        }
    }

    public static class ParsingExtensions
    {
        public static int ValueAt(this string frame, int index)
        {
            var roll = frame[index];
            int value;
            if (roll == '/')
            {
                value = 10 - frame.ValueAt(index - 1);
            }
            else
            {
                Int32.TryParse(roll.ToString(), out value);
            }
            return value;
        }

        public static int[] ToRolls(this string game)
        {
            return game
                .Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries)
                .SelectMany(twoRolls =>
                {
                    var first = twoRolls.ValueAt(0);
                    var second = twoRolls.ValueAt(1);
                    return new[] { first, second };
                }).ToArray();
        }
    }
}
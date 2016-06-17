using System;
using System.Linq;

namespace BowlingKata.Src
{

    public class Parser
    {
        public Frame[] GetFrames(string game)
        {
            var framesToParse = FramesToParse(game);
            var bonusRolls = GetBonusRolls(game);

            return framesToParse
                .Select((singleFrameToParse, index) => FrameFactory
                    .Create(
                        singleFrameToParse,
                    GetNormalRollsForFrame(singleFrameToParse),
                    Parser.NextRoll(index, framesToParse, bonusRolls),
                    Parser.SecondNextRollForStrike(index, framesToParse, bonusRolls)))
                .ToArray();
        }

        public static bool IsLastFrame(int index, int gameLength)
        {
            return index == gameLength - 1;
        }

        public static bool IsOneBeforeLastFrame(int index, int gameLength)
        {
            return Parser.IsLastFrame(index, gameLength - 1);
        }

        public static Roll SecondNextRollForStrike(int index, string[] framesToParse, Roll[] bonusRolls)
        {
            if (IsLastFrame(index, framesToParse.Length))
            {
                return bonusRolls[1];
            }
            var nextFrameResults = framesToParse[index + 1];
            if (IsStrike(nextFrameResults))
            {
                return IsOneBeforeLastFrame(index, framesToParse.Length)
                    ? bonusRolls[0]
                    : new Roll(framesToParse[index + 2], 0);
            }
            return new Roll(nextFrameResults, 1);
        }

        public static bool IsSpare(string singleFrameToParse)
        {
            return singleFrameToParse.Length > 1 && singleFrameToParse[1] == '/';
        }

        public static bool IsStrike(string frameResults)
        {
            return frameResults.Length == 1;
        }

        public static Roll NextRoll(int index, string[] framesToParse, Roll[] bonusRolls)
        {
            if (IsLastFrame(index, framesToParse.Length))
            {
                return bonusRolls[0];
            }
            var nextFrameResults = framesToParse[index + 1];
            return new Roll(nextFrameResults, 0);
        }

        public static Roll[] GetNormalRollsForFrame(string rollsResult)
        {
            return new[]
            {
                new Roll(rollsResult, 0),
                new Roll(rollsResult, 1),
            };
        }

        private static Roll[] GetBonusRolls(string game)
        {
            var normalAndBonusRolls = NormalAndBonusRolls(game);

            return HasBonusRolls(normalAndBonusRolls) ?
                new[]
                {
                    new Roll(normalAndBonusRolls[1], 0),
                    new Roll(normalAndBonusRolls[1], 1)
                }
                : new[]
                {
                    new Roll(string.Empty, 0),
                    new Roll(string.Empty, 0)
                };
        }

        private static bool HasBonusRolls(string[] games)
        {
            return games.Length > 1;
        }

        private static string[] NormalAndBonusRolls(string game)
        {
            return game.Split(new[] { "||" },
                StringSplitOptions.RemoveEmptyEntries);
        }

        private static string[] FramesToParse(string game)
        {
            var normalRolls = NormalAndBonusRolls(game)[0];
            return normalRolls.Split(new[] { "|" },
                StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
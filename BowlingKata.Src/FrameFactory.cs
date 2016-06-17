
namespace BowlingKata.Src
{
    public class FrameFactory
    {
        internal static Frame Create(string singleFrameToParse, int frameIndex, int gameLength, string[] framesToParse, Roll[] bonusRolls)
        {
            if (IsSpare(singleFrameToParse))
            {
                return new SpareFrame(singleFrameToParse, 
                    Parser.NextRoll(frameIndex, framesToParse, bonusRolls));
            }
            if (IsStrike(singleFrameToParse))
            {
                return new StrikeFrame(singleFrameToParse, 
                    Parser.NextRoll(frameIndex, framesToParse, bonusRolls), 
                    Parser.SecondNextRollForStrike(frameIndex, framesToParse, bonusRolls));
            }

            return new Frame(singleFrameToParse);
        }

        private static bool IsSpare(string singleFrameToParse)
        {
            return singleFrameToParse.Length > 1 && singleFrameToParse[1] == '/';
        }

        private static bool IsStrike(string singleFrameToParse)
        {
            return singleFrameToParse.Length == 1 && singleFrameToParse[0] == 'X';
        }
    }
}


namespace BowlingKata.Src
{
    public class FrameFactory
    {
        internal static Frame Create(string singleFrameToParse, int frameIndex, int gameLength, string[] framesToParse, Roll[] bonusRolls)
        {
            if (Parser.IsSpare(singleFrameToParse))
            {
                return new SpareFrame(singleFrameToParse, 
                    Parser.NextRoll(frameIndex, framesToParse, bonusRolls));
            }
            if (Parser.IsStrike(singleFrameToParse))
            {
                return new StrikeFrame(singleFrameToParse, 
                    Parser.NextRoll(frameIndex, framesToParse, bonusRolls), 
                    Parser.SecondNextRollForStrike(frameIndex, framesToParse, bonusRolls));
            }

            return new Frame(singleFrameToParse);
        }
    }
}

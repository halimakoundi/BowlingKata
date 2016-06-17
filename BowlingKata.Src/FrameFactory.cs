
namespace BowlingKata.Src
{
    public class FrameFactory
    {
        internal static Frame Create(string singleFrameToParse,
                                        int frameIndex,
                                        string[] framesToParse,
                                        Roll[] bonusRolls,
                                        Roll[] getNormalRollsForFrame)
        {
            if (Parser.IsSpare(singleFrameToParse))
            {
                return new SpareFrame(Parser.NextRoll(frameIndex, framesToParse, bonusRolls),
                                        getNormalRollsForFrame);
            }
            if (Parser.IsStrike(singleFrameToParse))
            {
                return new StrikeFrame(Parser.NextRoll(frameIndex, framesToParse, bonusRolls),
                                        Parser.SecondNextRollForStrike(frameIndex, framesToParse, bonusRolls),
                                        getNormalRollsForFrame);
            }

            return new Frame(getNormalRollsForFrame);
        }
    }
}

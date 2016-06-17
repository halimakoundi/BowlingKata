
namespace BowlingKata.Src
{
    public class FrameFactory
    {
        internal static Frame Create(string singleFrameToParse,
                                        Roll[] frameRolls,
                                        Roll nextRoll,
                                        Roll secondNextRollForStrike)
        {
            var frame = new Frame(frameRolls);

            if (Parser.IsSpare(singleFrameToParse))
            {
                frame = new SpareFrame(nextRoll,
                                        frameRolls);
            }
            if (Parser.IsStrike(singleFrameToParse))
            {
                frame = new StrikeFrame(nextRoll,
                                        secondNextRollForStrike,
                                        frameRolls);
            }

            return frame;
        }
    }
}

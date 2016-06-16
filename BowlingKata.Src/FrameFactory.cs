
namespace BowlingKata.Src
{
    public class FrameFactory
    {
        internal static Frame Parse(string frameRolls, int frameIndex, int gameLength, string[] gameResults, Roll[] bonusRolls)
        {
            if (frameRolls.Length == 1 && frameRolls[0] == 'X')
            {
                return new StrikeFrame(frameRolls, frameIndex, gameLength, gameResults, bonusRolls);
            }
            if (frameRolls.Length > 1 && frameRolls[1] == '/')
            {
                return new SpareFrame(frameRolls, frameIndex, gameLength, gameResults, bonusRolls);
            }
            return new Frame(frameRolls, frameIndex, gameLength);
        }

    }
}

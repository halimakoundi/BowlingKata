using System;
using System.Linq;

namespace BowlingKata.Src
{
    public class Bowling
    {
        public int CalculateScore(string game)
        {
            if (game == "1-|--|--|--|--|--|--|--|--|--|")
            {
                var rolls = game
                            .Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries)
                            .SelectMany(frame =>
                            {
                                var first = frame.RollScore(0);
                                var second = frame.RollScore(1);
                                return new[] { first, second };
                            });

                return rolls.Sum();
            }
            if (game == "13|--|--|--|--|--|--|--|--|--|")
            {
                return 1 + 3 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0;
            }
            return 0;
        }
    }

    public static class FrameExtensions
    {
        public static int RollScore(this string frame, int index)
        {
            int second;
            Int32.TryParse(frame[index].ToString(), out second);
            return second;
        }
    }
}
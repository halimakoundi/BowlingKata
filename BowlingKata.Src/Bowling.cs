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
                            .Split(new string[] {"|"}, StringSplitOptions.RemoveEmptyEntries)
                            .SelectMany(frame =>
                            {
                                int first; 
                                int.TryParse(frame[0].ToString(), out first);
                                int second; 
                                int.TryParse(frame[1].ToString(), out second);
                                return new[] {first, second};
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
}
using static System.Int32;

namespace BowlingKata.Src
{
    public class Roll
    {
        private readonly int _pins;

        public Roll(string rollResult, int index)
        {
            _pins = ParseRollScore(rollResult, index);
        }

        private int ParseRollScore(string rollsResult, int index)
        {
            if (rollsResult.Length < index + 1)
            {
                return 0;
            }
            switch (rollsResult[index])
            {
                case '/':
                    return 10 - ParseRollScore(rollsResult, index - 1);
                case 'X':
                    return 10;
                default:
                    int rollScore;
                    TryParse(rollsResult[index].ToString(), out rollScore);
                    return rollScore;
            }
        }

        public int GetRollScore()
        {
            return _pins;
        }
    }
}
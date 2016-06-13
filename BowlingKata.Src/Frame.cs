using static System.Int32;

namespace BowlingKata.Src
{
    internal class Frame
    {
        private readonly string _rollsResult;
        private readonly int _index;
        private readonly bool _isLastFrame;
        public int[] Rolls { get; set; }

        public Frame(string rollsResult, int index, int gameLength)
        {
            this._rollsResult = rollsResult;
            _index = index;
            _isLastFrame = index == gameLength - 1;
            PopulateRollsScore();
        }

        private void PopulateRollsScore()
        {
            this.Rolls = new int[]
            {
                GetRollScore(0),
                GetRollScore(1)
            };
        }

        private int GetRollScore(int index)
        {
            if (_rollsResult.Length < index + 1)
            {
                return 0;
            }
            switch (_rollsResult[index])
            {
                case '/':
                    return 10 - GetRollScore(index - 1);
                case 'X':
                    return 10;
                default:
                    int rollScore;
                    TryParse(_rollsResult[index].ToString(), out rollScore);
                    return rollScore;
            }
        }

        public int Score()
        {
            return this.GetRollScore(0) + this.GetRollScore(1);
        }

        public bool IsLastFrame()
        {
            return _isLastFrame;
        }

        public bool IsStrike()
        {
            return this.Score() == 10 && this.Rolls[1] == 0;
        }
    }
}
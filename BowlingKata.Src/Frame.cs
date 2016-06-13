using static System.Int32;

namespace BowlingKata.Src
{
    internal class Frame
    {
        private readonly string _rollsResult;
        private readonly int _index;
        private readonly bool _isLastFrame;
        private readonly bool _isOneBeforeLastFrame  ;
        private Roll[] Rolls { get; set; }

        public Frame(string rollsResult, int index, int gameLength)
        {
            _rollsResult = rollsResult;
            _index = index;
            _isLastFrame = index == gameLength - 1;
            _isOneBeforeLastFrame = index == gameLength - 2;
            PopulateRollsScore();
        }

        private void PopulateRollsScore()
        {
            Rolls = new Roll[]
            {
                new Roll(_rollsResult, 0), 
                new Roll(_rollsResult, 1), 
            };
        }

        public int GetRollScore(int index)
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
            return GetRollScore(0) + GetRollScore(1);
        }

        public bool IsLastFrame()
        {
            return _isLastFrame;
        }

        public bool IsStrike()
        {
            return Score() == 10 && Rolls[1].GetRollScore() == 0;
        }

        public bool IsOneBeforeLastFrame()
        {
            return _isOneBeforeLastFrame;
        }
    }
}
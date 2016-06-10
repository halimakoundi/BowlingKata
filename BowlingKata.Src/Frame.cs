using System;

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
                GetRollScore(0)
            };
        }

        private int GetRollScore(int index)
        {
            int rollScore;
            if (this._rollsResult[index] == '/')
            {
                return 10 - GetRollScore(index - 1);
            }
            Int32.TryParse(this._rollsResult[index].ToString(), out rollScore);
            return rollScore;
        }

        public int Score()
        {
            return this.GetRollScore(0) + this.GetRollScore(1);
        }

        public bool IsLastFrame()
        {
            return _isLastFrame;
        }
    }
}
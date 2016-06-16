namespace BowlingKata.Src
{
    internal class Frame
    {
        protected readonly string RollsResult;
        private readonly bool _isLastFrame;
        protected Roll[] Rolls;

        public Frame(string rollsResult, int index, int gameLength)
        {
            RollsResult = rollsResult;
            _isLastFrame = index == gameLength - 1;           
            PopulateRollsScore();
        }

        protected virtual void PopulateRollsScore()
        {
            Rolls = new Roll[]
            {
                new Roll(RollsResult, 0), 
                new Roll(RollsResult, 1), 
            };
        }

        private int GetRollScore(int index)
        {
            return Rolls[index].GetRollScore();
        }

        public virtual int Score()
        {
            return GetRollScore(0) + GetRollScore(1) ;
        }

        protected bool IsLastFrame()
        {
            return _isLastFrame;
        }

    }
}
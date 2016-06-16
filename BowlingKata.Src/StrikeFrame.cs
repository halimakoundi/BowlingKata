namespace BowlingKata.Src
{
    internal class StrikeFrame : Frame
    {
        private Roll _nextRollScore;
        private Roll _secondNextRollScore;
        private readonly bool _isOneBeforeLastFrame;

        public StrikeFrame(string rollsResult, int index, int gameLength,
            string[] gameResults, Roll[] bonusRolls)
            : base(rollsResult, index, gameLength)
        {
            _isOneBeforeLastFrame = index == gameLength - 2;
            SetNextRollScores(index, gameResults, bonusRolls);
            PopulateNextRollScore();
        }

        public override int Score()
        {
            return base.Score() + GetNextRollScore() + GetSecondNextRollScore();
        }

        private void SetNextRollScores(int index, string[] gameResults, Roll[] bonusRolls)
        {
            if (IsLastFrame())
            {
                _nextRollScore = bonusRolls[0];
                _secondNextRollScore = bonusRolls[1];
                return;
            }

            var nextFrameResults = gameResults[index + 1];
            _nextRollScore = new Roll(nextFrameResults, 0);
            _secondNextRollScore = new Roll(nextFrameResults, 1);
            var nextFrameIsStrike = nextFrameResults.Length == 1;
            if (nextFrameIsStrike)
            {
                _secondNextRollScore = _isOneBeforeLastFrame
                    ? bonusRolls[0]
                    : new Roll(gameResults[index + 2], 0);
            }
        }

        private void PopulateNextRollScore()
        {
            Rolls = new Roll[]
            {
                new Roll(RollsResult, 0),
                new Roll(RollsResult, 1),
                _nextRollScore,
                _secondNextRollScore
            };

        }

        private int GetNextRollScore()
        {
            return Rolls[2].GetRollScore();
        }

        private int GetSecondNextRollScore()
        {
            return _secondNextRollScore.GetRollScore();
        }
    }
}
namespace BowlingKata.Src
{
    internal class StrikeFrame : Frame
    {
        private Roll _nextRollScore;
        private Roll _secondNextRollScore;

        public StrikeFrame(string rollsResult, int index, int gameLength,
                            string[] gameResults, Roll[] bonusRolls)
                            : base(rollsResult, index, gameLength)
        {
            SetNextRollScores(index, gameResults, bonusRolls);
            PopulateNextRollScore();
        }

        private void SetNextRollScores(int index, string[] gameResults, Roll[] bonusRolls)
        {
            if (!IsLastFrame())
            {
                var nextFrameResults = gameResults[index + 1];
                _nextRollScore = new Roll(nextFrameResults, 0);
                var nextFrameIsStrike = nextFrameResults.Length == 1;
                _secondNextRollScore = new Roll(nextFrameResults, 1);
                if (nextFrameIsStrike)
                {
                    _secondNextRollScore = IsOneBeforeLastFrame() ?
                                           bonusRolls[0]
                                           : new Roll(gameResults[index + 2], 0);
                }
                return;
            }
            _nextRollScore = bonusRolls[0];
            _secondNextRollScore = bonusRolls[1];

        }

        protected void PopulateNextRollScore()
        {
            Rolls = new Roll[]
            {
                new Roll(RollsResult, 0),
                new Roll(RollsResult, 1),
                _nextRollScore,
                _secondNextRollScore
            };

        }

        public override int GetNextRollScore()
        {
            return Rolls[2].GetRollScore();
        }

        public override int GetSecondNextRollScore()
        {
            return _secondNextRollScore.GetRollScore();
        }
    }
}
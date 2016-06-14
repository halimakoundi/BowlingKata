namespace BowlingKata.Src
{
    internal class StrikeFrame : Frame
    {
        private readonly Roll _nextRollResults;

        public StrikeFrame(string rollsResult, int index, int gameLength, string[] gameResults, Roll[] bonusRolls) : base(rollsResult, index, gameLength)
        {
            _nextRollResults = !IsLastFrame() ?
                               new Roll(gameResults[index + 1], 0)
                               : bonusRolls[0];
            PopulateNextRollScore();
        }

        protected void PopulateNextRollScore()
        {
            Rolls = new Roll[]
            {
                new Roll(RollsResult, 0),
                new Roll(RollsResult, 1),
                _nextRollResults,
            };

        }

        public override int GetNextRollScore()
        {
            return Rolls[2].GetRollScore();
        }
    }
}
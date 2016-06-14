namespace BowlingKata.Src
{
    internal class SpareFrame : Frame
    {
        private readonly string _nextRollResults;

        public SpareFrame(string rollsResult, int index, int gameLength, string[]
            gameResults) : base(rollsResult, index, gameLength)
        {
            _nextRollResults = index < gameLength -1 ?
                                gameResults[index + 1]
                                : string.Empty;
            PopulateNextRollScore();
        }

        protected void PopulateNextRollScore()
        {
            Rolls = new Roll[]
            {
                new Roll(RollsResult, 0),
                new Roll(RollsResult, 1),
                new Roll(_nextRollResults, 0),
            };

        }
    }
}
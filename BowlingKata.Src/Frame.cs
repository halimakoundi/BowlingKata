namespace BowlingKata.Src
{
    public class Frame
    {
        protected Roll[] Rolls;

        public Frame(Roll[] frameRolls)
        {
            Rolls = frameRolls;
        }

        private int GetRollScore(int index)
        {
            return Rolls[index].GetRollScore();
        }

        public virtual int Score()
        {
            return GetRollScore(0) + GetRollScore(1) ;
        }

    }
}
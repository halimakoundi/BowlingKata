using System;
using System.Linq;

namespace BowlingKata.Src
{
    public class Bowling
    {
        private int _gameScore;
        private string _gameResults;
        private Frame[] _frames;

        public int CalculateScore(string game)
        {
            _gameResults = game.Split(new string[] { "||" },
                StringSplitOptions.RemoveEmptyEntries)[0];
            _frames = GetFrames();
            for (var i = 0; i < _frames.Length; i++)
            {
                var frame = _frames[i];
                _gameScore += frame.Score();
                _gameScore += GetAllPinsDownFrameScore(game, frame, i);
            }
            return _gameScore;
        }

        private int GetAllPinsDownFrameScore(string game, Frame frame, int i)
        {
            var extraFrameScore = 0;
            if (frame.Score() == 10)
            {
                var nextFrame = !frame.IsLastFrame()
                    ? _frames[i + 1]
                        :null;

                var nextRollScore = !frame.IsLastFrame()
                    ? nextFrame.GetRollScore(0)
                    : GetBonusRolls(game)[0].GetRollScore();

                var secondNextRollScore = !frame.IsLastFrame()
                    ? _frames[i + 1].GetRollScore(1)
                    : GetBonusRolls(game)[1].GetRollScore();

                extraFrameScore = nextRollScore;

                if (frame.IsStrike())
                {
                    if (!frame.IsLastFrame() && nextFrame.IsStrike())
                    {
                        secondNextRollScore = frame.IsOneBeforeLastFrame() ? GetBonusRolls(game)[0].GetRollScore() : _frames[i + 2].GetRollScore(0);
                    }
                    extraFrameScore += secondNextRollScore;
                }
            }
            return extraFrameScore;
        }

        private static Roll[] GetBonusRolls(string game)
        {
            var games = game.Split(new string[] { "||" },
                StringSplitOptions.RemoveEmptyEntries);
            return new Roll[] { new Roll(games[1], 0), new Roll(games[1], 1) };
        }

        private Frame[] GetFrames()
        {
            var gameResults = _gameResults.Split(new string[] { "|" },
                  StringSplitOptions.RemoveEmptyEntries);
            return gameResults
                  .Select((x, index) => new Frame(x, index, gameResults.Length)).ToArray();
        }
    }
}
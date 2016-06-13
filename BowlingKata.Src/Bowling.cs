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
            var frameScore = 0;
            if (frame.Score() == 10)
            {
                var nextFrame = !frame.IsLastFrame()
                    ? _frames[i + 1]
                    : BonusRolls(game);
                frameScore = nextFrame.GetRollScore(0);
                if (frame.IsStrike())
                {
                    if (nextFrame.IsStrike())
                    {
                        var secondNextFrame = frame.IsOneBeforeLastFrame() ? BonusRolls(game) : _frames[i + 2];
                        frameScore += secondNextFrame.GetRollScore(0);
                    }
                    else
                    {
                        frameScore += nextFrame.GetRollScore(1);
                    }
                }
            }
            return frameScore;
        }

        private static Frame BonusRolls(string game)
        {
            var games = game.Split(new string[] { "||" },
                StringSplitOptions.RemoveEmptyEntries);
            return games.Length < 2 ? null : new Frame(games[1], 0, 0);
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
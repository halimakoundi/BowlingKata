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
            for (int i = 0; i < _frames.Length; i++)
            {
                var frame = _frames[i];
                _gameScore += frame.Score();
                if (frame.Score() == 10)
                {
                    var nextFrame = !frame.IsLastFrame() ? _frames[i + 1] : BonusRolls(game);
                    _gameScore += nextFrame.Rolls[0];
                    if (frame.IsStrike())
                    {
                        if (nextFrame.IsStrike())
                        {
                            var secondNextFrame = _frames[i + 2];
                            _gameScore += secondNextFrame.Rolls[0];
                        }
                        _gameScore += nextFrame.Rolls[1];
                    }
                }
            }
            return _gameScore;
        }

        private static Frame BonusRolls(string game)
        {
            var games = game.Split(new string[] { "||" },
                StringSplitOptions.RemoveEmptyEntries);
            if (games.Length < 2)
            {
                return null;
            }
            return games[1].Select((x, index) => new Frame(x.ToString(), index, 0))
                .FirstOrDefault();
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
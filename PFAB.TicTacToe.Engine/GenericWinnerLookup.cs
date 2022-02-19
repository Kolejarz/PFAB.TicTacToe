using System.Drawing;

namespace PFAB.TicTacToe.Engine
{
    public class GenericWinnerLookup : IWinnerLookup
    {
        private readonly int _winningSequenceLength;
        private readonly IEnumerable<Point> _directions;

        public GenericWinnerLookup(int winningSequenceLength)
        {
            _winningSequenceLength = winningSequenceLength;
            _directions = new List<Point>()
            {
                new(1, 0), // RIGHT
                new(1, 1), // RIGHT-DOWN
                new(0, 1), // DOWN
                new(-1, 1) // LEFT-DOWN
            };
        }

        public char DetermineWinner(Board board)
        {
            var squares = board.GetSquares();

            for (var y = 0; y < squares.Length; y++)
            {
                var row = squares[y];
                for (var x = 0; x < row.Length; x++)
                {
                    var square = squares[y][x];

                    if (!square.IsOccupied) continue;

                    foreach (var direction in _directions)
                    {
                        for (var i = 1; i < _winningSequenceLength; i++)
                        {
                            var coordinates = new Point(x + i * direction.X, y + i * direction.Y);

                            if (coordinates.Y >= squares.Length) break;
                            if (coordinates.X < 0) break;
                            if (coordinates.X >= squares[0].Length) break;
                            if (squares[coordinates.Y][coordinates.X].Symbol != square.Symbol) break;

                            if (i == _winningSequenceLength - 1) return square.Symbol;
                        }
                    }
                }
            }

            return default;
        }
    }
}

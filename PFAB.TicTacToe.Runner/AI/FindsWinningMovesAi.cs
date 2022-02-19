using System.Drawing;
using PFAB.TicTacToe.Engine;

namespace PFAB.TicTacToe.Runner.AI
{
    internal class FindsWinningMovesAi : ICoordinatesProvider
    {
        protected readonly RandomAi RandomAi;
        private readonly int _winningSequenceLength;
        private readonly IEnumerable<Point> _directions;

        public FindsWinningMovesAi(int winningSequenceLength)
        {
            _winningSequenceLength = winningSequenceLength;
            RandomAi = new RandomAi();
            _directions = new List<Point>()
            {
                new(1, 0), // RIGHT
                new(1, 1), // RIGHT-DOWN
                new(0, 1), // DOWN
                new(-1, 1) // LEFT-DOWN
            };
        }

        public Point GetCoordinates(IBoard board, char player)
        {
            var winningMove = FindWinningMove(board, player);
            return winningMove ?? RandomAi.GetCoordinates(board, player);
        }

        protected Point? FindWinningMove(IBoard board, char player)
        {
            var squares = board.GetSquares();

            for (var y = 0; y < squares.Length; y++)
            {
                for (var x = 0; x < squares[y].Length; x++)
                {
                    foreach (var direction in _directions)
                    {
                        var sequence = new List<(Point, Square)>();
                        for (var i = 0; i < _winningSequenceLength; i++)
                        {
                            var coordinates = new Point(x + i * direction.X, y + i * direction.Y);

                            if (coordinates.Y >= squares.Length) break;
                            if (coordinates.X < 0) break;
                            if (coordinates.X >= squares[0].Length) break;

                            sequence.Add((coordinates, squares[coordinates.Y][coordinates.X]));
                        }

                        if (sequence.Count < _winningSequenceLength) continue;
                        var symbolsDifferentThanPlayer = sequence.Count(s => s.Item2.Symbol != player);
                        if (symbolsDifferentThanPlayer != 1) continue;

                        var point = sequence.SingleOrDefault(s => s.Item2.IsOccupied == false).Item1;
                        if (point != default) return point;
                    }
                }
            }

            return null;
        }
    }
}

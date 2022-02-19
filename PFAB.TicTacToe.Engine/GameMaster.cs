using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFAB.TicTacToe.Engine
{
    public class GameMaster
    {
        private readonly IWinnerLookup _winnerLookup;
        private int _counter;
        private readonly char[] _players = { 'X', 'O' };

        public GameMaster(IWinnerLookup winnerLookup)
        {
            _winnerLookup = winnerLookup;
            Board = Board.CreateEmpty(4, 4);
            CurrentPlayer = 'X';
        }

        public char CurrentPlayer { get; private set; }

        public Board Board { get; private set; }

        public void MakeMove(Point coordinates)
        {
            var currentBoard = Board.GetSquares();

            if (currentBoard[coordinates.Y][coordinates.X].IsOccupied)
            {
                throw new ArgumentException("This square is already taken");
            }

            var newBoard = new List<Square[]>();

            foreach (var row in currentBoard)
            {
                var rowCopy = new List<Square>();
                foreach (var square in row)
                {
                    rowCopy.Add(square with { IsHighlighted = false});
                }
                newBoard.Add(rowCopy.ToArray());
            }

            newBoard[coordinates.Y][coordinates.X] = new Square(true, CurrentPlayer, true);
            _counter++;
            CurrentPlayer = _players[_counter % 2];
            Board = new Board(newBoard.ToArray());
        }

        public string GameResult() 
        {
            var winner = _winnerLookup.DetermineWinner(Board);
            if (winner != default)
            {
                return winner.ToString();
            }

            if (Board.GetSquares().SelectMany(x => x).All(square => square.IsOccupied))
            {
                return "draw";
            }

            return string.Empty;
        }
    }
}

using System.Drawing;

namespace PFAB.TicTacToe.Engine;

public interface ICoordinatesProvider
{
    Point GetCoordinates(IBoard board, char player);
}

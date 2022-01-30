namespace PFAB.TicTacToe.Engine;

public class Board : IBoard
{
    private readonly Square[][] _squares;

    protected Board(int width, int height)
    {
        var rows = new List<Square[]>();
        for (var i = 0; i < height; i++)
        {
            rows.Add(Enumerable.Repeat(
                new Square(false, default), 
                width).ToArray());
        }

        _squares = rows.ToArray();
    }

    public Board(Square[][] squares)
    {
        _squares = squares;
    }

    public static Board CreateEmpty(int width, int height)
    {
        return new Board(width, height);
    }

    public Square[][] GetSquares()
    {
        return _squares;
    }
}

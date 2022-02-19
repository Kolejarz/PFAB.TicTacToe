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
        var board = new Board(width, height);
        //board._squares[0][4] = new Square(true, 'X');
        //board._squares[0][3] = new Square(true, 'X');
        //board._squares[0][2] = new Square(true, 'X');

        return board;
    }

    public Square[][] GetSquares()
    {
        return _squares;
    }
}

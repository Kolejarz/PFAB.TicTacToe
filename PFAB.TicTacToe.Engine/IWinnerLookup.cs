namespace PFAB.TicTacToe.Engine
{
    public interface IWinnerLookup
    {
        char DetermineWinner(Board board);
    }
}

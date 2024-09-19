namespace ChessProject;

public class Game
{
    private Board _board;
    private readonly Player _player1;
    private readonly Player _player2;
    

    public Game(Board board, Player player1, Player player2)
    {
        _board = board;
        _player1 = player1;
        _player2 = player2;
    }

    public bool TryDoMove(Board board, GameMove move)
    {
        if (GameJudge.VerifyMove(board.Positions, move))
        {
            // Do move
            board.Move(move);
            return true;
        }

        return false;
    }
}
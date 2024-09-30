namespace ChessProject;

public class Game
{
    private readonly Player _player1;
    private readonly Player _player2;
    private BoardState _boardState;


    public Game(BoardState boardState, Player player1, Player player2)
    {
        _boardState = boardState;
        _player1 = player1;
        _player2 = player2;
    }

    public bool TryDoMove(BoardState boardState, GameMove move)
    {

        return false;
    }
}
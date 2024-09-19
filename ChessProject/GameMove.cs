namespace ChessProject;

public readonly record struct GameMove : IApiEvent
{
    public readonly int From;
    public readonly int To;

    public GameMove(int from, int to)
    {
        From = from;
        To = to;
    }
}
namespace ChessProject.Pieces;

public readonly record struct Queen : IChessPiece
{
    private readonly bool _isWhite;

    public Queen(bool isWhite)
    {
        _isWhite = isWhite;
    }

    public bool IsWhite()
    {
        return _isWhite;
    }
}
namespace ChessProject.Pieces;

public readonly record struct Rook : IChessPiece
{
    private readonly bool _isWhite;

    public Rook(bool isWhite)
    {
        _isWhite = isWhite;
    }

    public bool IsWhite()
    {
        return _isWhite;
    }
}
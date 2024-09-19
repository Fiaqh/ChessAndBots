namespace ChessProject.Pieces;

public readonly record struct King : IChessPiece
{
    private readonly bool _isWhite;

    public King(bool isWhite)
    {
        _isWhite = isWhite;
    }

    public bool IsWhite()
    {
        return _isWhite;
    }
}
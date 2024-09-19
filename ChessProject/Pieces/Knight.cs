namespace ChessProject.Pieces;

public readonly record struct Knight : IChessPiece
{
    private readonly bool _isWhite;

    public Knight(bool isWhite)
    {
        this._isWhite = isWhite;
    }

    public bool IsWhite()
    {
        return _isWhite;
    }
}
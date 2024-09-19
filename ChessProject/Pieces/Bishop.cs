namespace ChessProject.Pieces;

public readonly record struct Bishop : IChessPiece
{
    private readonly bool _isWhite;

    public Bishop(bool isWhite)
    {
        _isWhite = isWhite;
    }

    public bool IsWhite()
    {
        return _isWhite;
    }
}
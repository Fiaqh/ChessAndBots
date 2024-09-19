namespace ChessProject.Pieces;

public readonly record struct Pawn : IChessPiece
{
    private readonly bool _isWhite;

    public Pawn(bool isWhite)
    {
        _isWhite = isWhite;
    }

    public bool IsWhite()
    {
        return _isWhite;
    }
}
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
    
    public string ImageSource () => _isWhite ? "C:/Repos/ChessAndBots/ChessProject/Pieces/LightRook.png" : "C:/Repos/ChessAndBots/ChessProject/Pieces/DarkRook.png";

}
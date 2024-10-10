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
    
    public string ImageSource () => _isWhite ? "C:/Repos/ChessAndBots/ChessProject/Pieces/LightKing.jpg" : "C:/Repos/ChessAndBots/ChessProject/Pieces/DarkKing.jpg";

}
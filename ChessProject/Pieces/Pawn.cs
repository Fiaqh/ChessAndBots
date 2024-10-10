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
    
    public string ImageSource () => _isWhite ? "C:/Repos/ChessAndBots/ChessProject/Pieces/LightPawn.jpg" : "C:/Repos/ChessAndBots/ChessProject/Pieces/DarkPawn.jpg";

}
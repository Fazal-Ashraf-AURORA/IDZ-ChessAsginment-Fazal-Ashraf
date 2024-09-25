using UnityEngine;

public class ChessBoard
{
    private ChessPiece[,] board = new ChessPiece[8, 8];

    // To check if a position is valid
    public bool IsValidPosition(Vector2Int position)
    {
        return position.x >= 0 && position.x < 8 && position.y >= 0 && position.y < 8;
    }

    public bool IsOccupied(Vector2Int position)
    {
        return board[position.x, position.y] != null;
    }

    public bool IsOccupiedByAlly(Vector2Int position, string color)
    {
        var piece = board[position.x, position.y];
        return piece != null && piece.Color == color;
    }

    public bool IsOccupiedByEnemy(Vector2Int position, string color)
    {
        var piece = board[position.x, position.y];
        return piece != null && piece.Color != color;
    }

    public ChessPiece GetPiece(Vector2Int position)
    {
        return IsValidPosition(position) ? board[position.x, position.y] : null;
    }

    public void PlacePiece(ChessPiece piece, Vector2Int position)
    {
        if (IsValidPosition(position))
        {
            board[position.x, position.y] = piece;
        }
    }
}

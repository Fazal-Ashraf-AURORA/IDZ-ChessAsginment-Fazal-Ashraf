using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPiece
{
    public Vector2Int Position { get; set; }
    public string Color { get; set; } // "White" or "Black"

    protected ChessPiece(Vector2Int position, string color)
    {
        Position = position;
        Color = color;
    }

    public abstract List<Vector2Int> GetLegalMoves(ChessBoard board);
}

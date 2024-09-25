using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    public King(Vector2Int position, string color) : base(position, color) { }

    public override List<Vector2Int> GetLegalMoves(ChessBoard board)
    {
        var legalMoves = new List<Vector2Int>();
        var directions = new List<Vector2Int>
        {
            new Vector2Int(1, 0),   // Right
            new Vector2Int(-1, 0),  // Left
            new Vector2Int(0, 1),   // Up
            new Vector2Int(0, -1),  // Down
            new Vector2Int(1, 1),   // Diagonal Up-Right
            new Vector2Int(-1, 1),  // Diagonal Up-Left
            new Vector2Int(1, -1),  // Diagonal Down-Right
            new Vector2Int(-1, -1)  // Diagonal Down-Left
        };

        foreach (var direction in directions)
        {
            var newPosition = Position + direction;
            if (board.IsValidPosition(newPosition) && !board.IsOccupiedByAlly(newPosition, Color))
            {
                legalMoves.Add(newPosition);
            }
        }

        return legalMoves;
    }
}

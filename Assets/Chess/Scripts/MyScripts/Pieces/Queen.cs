using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : ChessPiece
{
    public Queen(Vector2Int position, string color) : base(position, color) { }

    public override List<Vector2Int> GetLegalMoves(ChessBoard board)
    {
        var legalMoves = new List<Vector2Int>();

        // Horizontal, vertical, and diagonal directions
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
            for (int i = 1; i < 8; i++)
            {
                var newPosition = Position + (direction * i);
                if (!board.IsValidPosition(newPosition)) break;
                if (board.IsOccupiedByAlly(newPosition, Color)) break;

                legalMoves.Add(newPosition);

                if (board.IsOccupiedByEnemy(newPosition, Color)) break; // Stop if an enemy piece is found
            }
        }

        return legalMoves;
    }
}
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece
{
    public Knight(Vector2Int position, string color) : base(position, color) { }

    public override List<Vector2Int> GetLegalMoves(ChessBoard board)
    {
        var legalMoves = new List<Vector2Int>();
        var moves = new List<Vector2Int>
        {
            new Vector2Int(2, 1),
            new Vector2Int(2, -1),
            new Vector2Int(-2, 1),
            new Vector2Int(-2, -1),
            new Vector2Int(1, 2),
            new Vector2Int(1, -2),
            new Vector2Int(-1, 2),
            new Vector2Int(-1, -2)
        };

        foreach (var move in moves)
        {
            var newPosition = Position + move;
            if (board.IsValidPosition(newPosition) && !board.IsOccupiedByAlly(newPosition, Color))
            {
                legalMoves.Add(newPosition);
            }
        }

        return legalMoves;
    }
}

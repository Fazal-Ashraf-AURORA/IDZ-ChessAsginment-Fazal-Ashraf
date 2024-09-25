using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece
{
    public Pawn(Vector2Int position, string color) : base(position, color) { }

    public override List<Vector2Int> GetLegalMoves(ChessBoard board)
    {
        var legalMoves = new List<Vector2Int>();
        int direction = (Color == "White") ? -1 : 1;  // White pawns move up (y-), Black pawns move down (y+)

        // Move forward by 1 square
        var forward = new Vector2Int(Position.x + direction, Position.y);  // Only move forward in Y direction
        if (board.IsValidPosition(forward) && !board.IsOccupied(forward))
        {
            legalMoves.Add(forward);
        }

        // First move: Allow moving 2 squares forward
        if ((Color == "Black" && Position.x == 1) || (Color == "White" && Position.x == 6))
        {
            var doubleForward = new Vector2Int(Position.x + (2 * direction), Position.y);  // Two squares forward
            if (board.IsValidPosition(doubleForward) && !board.IsOccupied(doubleForward) && !board.IsOccupied(forward))
            {
                legalMoves.Add(doubleForward);
            }
        }

        // Capturing diagonally: Only 1 step diagonally forward (left and right)
        //var captureLeft = new Vector2Int(Position.x - 1, Position.y + direction);
        //var captureRight = new Vector2Int(Position.x + 1, Position.y + direction);
        
        //if (board.IsValidPosition(captureLeft) && board.IsOccupiedByEnemy(captureLeft, Color))
        //{
        //    legalMoves.Add(captureLeft);
        //}

        //if (board.IsValidPosition(captureRight) && board.IsOccupiedByEnemy(captureRight, Color))
        //{
        //    legalMoves.Add(captureRight);
        //}

        return legalMoves;
    }
}
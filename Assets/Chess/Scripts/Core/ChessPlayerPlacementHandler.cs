//using System;
//using UnityEngine;

//namespace Chess.Scripts.Core {
//    public class ChessPlayerPlacementHandler : MonoBehaviour {
//        [SerializeField] public int row, column;

//        private void Start()
//        {
//            transform.position = ChessBoardPlacementHandler.Instance.GetTile(row, column).transform.position;

//            // Initialize the piece based on the type
//            var position = new Vector2Int(row, column);
//            switch (pieceType)
//            {
//                case "Queen":
//                    _selectedPiece = new Queen(position, "White");
//                    break;
//                case "King":
//                    _selectedPiece = new King(position, "White");
//                    break;
//                case "Bishop":
//                    _selectedPiece = new Bishop(position, "White");
//                    break;
//                case "Knight":
//                    _selectedPiece = new Knight(position, "White");
//                    break;
//                case "Rook":
//                    _selectedPiece = new Rook(position, "White");
//                    break;
//                case "Pawn":
//                    _selectedPiece = new Pawn(position, "White");
//                    break;
//            }
//        }

//    }
//}

using System.Collections.Generic;
using UnityEngine;


namespace Chess.Scripts.Core
{
    public class ChessPlayerPlacementHandler : MonoBehaviour
    {
        [SerializeField] public int row, column;
        [SerializeField] private string pieceType;  // Piece type: "Queen", "King", "Bishop", etc.
        [SerializeField] private string pieceColor = "White"; // Piece color: "White" or "Black"

        private ChessPiece _selectedPiece;

        private void Start()
        {
            // Place the chess piece on the correct tile based on the row and column
            transform.position = ChessBoardPlacementHandler.Instance.GetTile(row, column).transform.position;

            // Initialize the piece based on its type
            var position = new Vector2Int(row, column);
            switch (pieceType)
            {
                case "Queen":
                    _selectedPiece = new Queen(position, pieceColor);
                    break;
                case "King":
                    _selectedPiece = new King(position, pieceColor);
                    break;
                case "Bishop":
                    _selectedPiece = new Bishop(position, pieceColor);
                    break;
                case "Knight":
                    _selectedPiece = new Knight(position, pieceColor);
                    break;
                case "Rook":
                    _selectedPiece = new Rook(position, pieceColor);
                    break;
                case "Pawn":
                    _selectedPiece = new Pawn(position, pieceColor);
                    break;
                default:
                    Debug.LogError("Invalid piece type selected.");
                    break;
            }
        }

        private void OnMouseDown()
        {
            // When the chess piece is clicked, highlight its legal moves
            if (_selectedPiece != null)
            {
                HighlightLegalMoves();
            }
        }

        private void HighlightLegalMoves()
        {
            // Clear any existing highlights on the chessboard
            ChessBoardPlacementHandler.Instance.ClearHighlights();

            // Create a reference to the chessboard
            var chessBoard = new ChessBoard();  // You may already have a ChessBoard instance somewhere, so adjust accordingly.

            // Get the legal moves for the selected piece
            List<Vector2Int> legalMoves = _selectedPiece.GetLegalMoves(chessBoard);

            // Highlight the legal move tiles on the board
            foreach (var move in legalMoves)
            {
                ChessBoardPlacementHandler.Instance.Highlight(move.x, move.y);
            }
        }
    }
}

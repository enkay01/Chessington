using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }
        public bool HasMoved { get; set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);
        protected IEnumerable<Square> GetLateralMoVes(Board board)
        {
            var squares = GetAvailableMovesInDirection(board, s => Square.At(s.Row+1, s.Col)).ToList();//Up
            squares.AddRange(GetAvailableMovesInDirection(board, s => Square.At(s.Row, s.Col + 1)));//Right
            squares.AddRange(GetAvailableMovesInDirection(board, s => Square.At(s.Row-1, s.Col)));//Down
            squares.AddRange(GetAvailableMovesInDirection(board, s => Square.At(s.Row, s.Col - 1)));//Left
            return squares;

        }
        protected IEnumerable<Square> GetDiagonalMoves(Board board)
        {
            var squares = GetAvailableMovesInDirection(board, s => Square.At(s.Row + 1, s.Col + 1)).ToList();
            squares.AddRange(GetAvailableMovesInDirection(board, s => Square.At(s.Row - 1, s.Col + 1)));
            squares.AddRange(GetAvailableMovesInDirection(board, s => Square.At(s.Row - 1, s.Col - 1)));
            squares.AddRange(GetAvailableMovesInDirection(board, s => Square.At(s.Row + 1, s.Col - 1)));
            return squares;
        }
        private IEnumerable<Square> GetAvailableMovesInDirection(Board board, Func<Square, Square> iterator)
        {
            var location = board.FindPiece(this);
            var square = iterator(location);
            while (board.IsSquareAvailable(square))
            {
                yield return square;
                if (board.GetPiece(square) != null) break;
                square = iterator(square);
            }
        } 

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }
    }
}
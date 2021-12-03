using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentPosition = board.FindPiece(this);
            List<Square> availableSquares = new List<Square>();
            int newRow;
            int newCol;

            // downwards - right
            newRow = currentPosition.Row + 2;
            newCol = currentPosition.Col + 1;
            if (board.IsSquareAvailable(Square.At(newRow, newCol))) availableSquares.Add(Square.At(newRow, newCol));

            // downwards - left
            newRow = currentPosition.Row + 2;
            newCol = currentPosition.Col - 1;
            if (board.IsSquareAvailable(Square.At(newRow, newCol))) availableSquares.Add(Square.At(newRow, newCol));

            // upwards - right
            newRow = currentPosition.Row - 2;
            newCol = currentPosition.Col + 1;
            if (board.IsSquareAvailable(Square.At(newRow, newCol))) availableSquares.Add(Square.At(newRow, newCol));

            // upwards - left
            newRow = currentPosition.Row - 2;
            newCol = currentPosition.Col - 1;
            if (board.IsSquareAvailable(Square.At(newRow, newCol))) availableSquares.Add(Square.At(newRow, newCol));

            // rightwards - up
            newRow = currentPosition.Row - 1;
            newCol = currentPosition.Col + 2;
            if (board.IsSquareAvailable(Square.At(newRow, newCol))) availableSquares.Add(Square.At(newRow, newCol));

            // rightwards - down
            newRow = currentPosition.Row + 1;
            newCol = currentPosition.Col + 2;
            if (board.IsSquareAvailable(Square.At(newRow, newCol))) availableSquares.Add(Square.At(newRow, newCol));
            // leftwards - up
            newRow = currentPosition.Row - 1;
            newCol = currentPosition.Col - 2;
            if (board.IsSquareAvailable(Square.At(newRow, newCol))) availableSquares.Add(Square.At(newRow, newCol));

            // leftwards - down
            newRow = currentPosition.Row + 1;
            newCol = currentPosition.Col - 2;
            if (board.IsSquareAvailable(Square.At(newRow, newCol))) availableSquares.Add(Square.At(newRow, newCol));

            return availableSquares;
        }
    }
}
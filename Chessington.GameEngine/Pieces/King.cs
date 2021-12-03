using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentPosition = board.FindPiece(this);
            List<Square> availableSquares = new List<Square>();
            int newRow;
            int newCol;
            // up
            newRow = currentPosition.Row - 1;
            newCol = currentPosition.Col;
            if (board.IsSquareAvailable(Square.At(newRow, newCol))) availableSquares.Add(Square.At(newRow, newCol));
            // down
            newRow = currentPosition.Row + 1;
            newCol = currentPosition.Col;
            if (board.IsSquareAvailable(Square.At(newRow, newCol))) availableSquares.Add(Square.At(newRow, newCol));
            //left
            newRow = currentPosition.Row;
            newCol = currentPosition.Col - 1;
            if (board.IsSquareAvailable(Square.At(newRow, newCol))) availableSquares.Add(Square.At(newRow, newCol));
            //right
            newRow = currentPosition.Row;
            newCol = currentPosition.Col + 1;
            if (board.IsSquareAvailable(Square.At(newRow, newCol))) availableSquares.Add(Square.At(newRow, newCol));
            // up - left
            newRow = currentPosition.Row - 1;
            newCol = currentPosition.Col - 1;
            if (board.IsSquareAvailable(Square.At(newRow, newCol))) availableSquares.Add(Square.At(newRow, newCol));
            // up - right
            newRow = currentPosition.Row - 1;
            newCol = currentPosition.Col + 1;
            if (board.IsSquareAvailable(Square.At(newRow, newCol))) availableSquares.Add(Square.At(newRow, newCol));
            // down - left
            newRow = currentPosition.Row + 1;
            newCol = currentPosition.Col - 1;
            if (board.IsSquareAvailable(Square.At(newRow, newCol))) availableSquares.Add(Square.At(newRow, newCol));

            // down - right
            newRow = currentPosition.Row + 1;
            newCol = currentPosition.Col + 1;
            if (board.IsSquareAvailable(Square.At(newRow, newCol))) availableSquares.Add(Square.At(newRow, newCol));

            return availableSquares;
        }
    }
}
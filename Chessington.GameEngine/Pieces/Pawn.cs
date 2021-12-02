using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var location = board.FindPiece(this);
            var nextRow = location.Row + (Player == Player.White? -1 : 1);
            Square[] captureMoves = { Square.At(nextRow, location.Col + 1), Square.At(nextRow, location.Col - 1) };

            foreach (var captureSquare in captureMoves)
            {
                if (board.IsOccupied(captureSquare) && board.GetPiece(captureSquare).Player != Player)
                {
                    yield return captureSquare;
                }
            }

            var nextSquare = Square.At(nextRow, location.Col);
            if (!board.IsSquareAvailable(nextSquare))
                yield break;
            yield return nextSquare;

            if (this.HasMoved)
                yield break;

            var rowAfterNext = location.Row + (Player == Player.White ? -2 : 2);
            Square doubleMove = Square.At(rowAfterNext, location.Col);
            if (!board.IsSquareAvailable(doubleMove))
                yield break;
            if(!this.HasMoved)
                yield return doubleMove;
        }
    }
}
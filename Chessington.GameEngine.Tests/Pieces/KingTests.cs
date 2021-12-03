using System.Collections.Generic;
using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class KingTests
    {
        [Test]
        public void KingsCanMoveToAdjacentSquares()
        {
            var board = new Board();
            var king = new King(Player.White);
            board.AddPiece(Square.At(4, 4), king);

            var moves = king.GetAvailableMoves(board);

            var expectedMoves = new List<Square>
            {
                Square.At(3, 3),
                Square.At(3, 4),
                Square.At(3, 5),
                Square.At(4, 3),
                Square.At(4, 5),
                Square.At(5, 3),
                Square.At(5, 4),
                Square.At(5, 5)
            };

            moves.ShouldAllBeEquivalentTo(expectedMoves);
        }
        [Test]
        public void King_Cannot_Move()
        {
            var board = new Board(Player.Black);
            var pawnB = new Pawn(Player.Black);
            var king = new King(Player.Black);
            var knight = new Knight(Player.Black);

            board.AddPiece(Square.At(0, 4), king);
            //in front
            board.AddPiece(Square.At(1, 3), pawnB);
            board.AddPiece(Square.At(1, 4), pawnB);
            board.AddPiece(Square.At(1, 5), pawnB);
            //left and right
            board.AddPiece(Square.At(0, 3), pawnB);
            board.AddPiece(Square.At(0, 5), knight);

            var moves = king.GetAvailableMoves(board);
            moves.Should().BeEmpty();

        }
    }
}
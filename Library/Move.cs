using static ThreeKings.Library.Piece;
using static ThreeKings.Utilities.MoveUtility;
using static ThreeKings.MoveFinder;

namespace ThreeKings.Library
{
    public class Move
    {
        public byte FromIndex;
        public byte ToIndex;
        public PieceType Promotion;

        public Move(string uciMoveNotation)
        {
            string fromSquare = uciMoveNotation.Substring(0, 2);
            string toSquare = uciMoveNotation.Substring(2, 2);
            FromIndex = Notation.ToSquare(fromSquare);
            ToIndex = Notation.ToSquare(toSquare);
            Promotion = (uciMoveNotation.Length == 5) ? Notation.ToPiece(uciMoveNotation[4]) : PieceType.None;
        }

        public override string ToString()
        {
            //result represents the move in the long algebraic notation (without piece names)
            string result = Notation.ToSquareName(FromIndex);
            result += Notation.ToSquareName(ToIndex);
            //the presence of a 5th character should mean promotion
            if (Promotion != PieceType.None)
                result += Notation.ToChar(Promotion);

            return result;
        }

        public void Adjust()
        {
            if (isUpperEdge(ToIndex))
            {
                if (Promotion != PieceType.None)
                {
                    Promotion = Notation.ToPiece(Notation.ToChar(Promotion).ToString().ToUpper());
                }
            }
        }
    }
}

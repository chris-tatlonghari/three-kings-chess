namespace ThreeKings.Library
{
    public class Piece
    {
        public PieceType _type;
        public bool hasMoved;

        public enum PieceType
        {
            None = 0,
            WhitePawn = 1,
            WhiteKnight = 2,
            WhiteBishop = 3,
            WhiteRook = 4,
            WhiteQueen = 5,
            WhiteKing = 6,
            BlackPawn = 7,
            BlackKnight = 8,
            BlackBishop = 9,
            BlackRook = 10,
            BlackQueen = 11,
            BlackKing = 12
        }

        public Piece(PieceType type)
        {
            _type = type;
            hasMoved = false;
        }

        public bool isWhite()
        {
            if (_type == PieceType.WhitePawn || _type == PieceType.WhiteKnight || _type == PieceType.WhiteBishop ||
                _type == PieceType.WhiteRook || _type == PieceType.WhiteQueen || _type == PieceType.WhiteKing)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isBlack()
        {
            if (_type == PieceType.BlackPawn || _type == PieceType.BlackKnight || _type == PieceType.BlackBishop ||
                _type == PieceType.BlackRook || _type == PieceType.BlackQueen || _type == PieceType.BlackKing)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isPiece()
        {
            if (_type == PieceType.None)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

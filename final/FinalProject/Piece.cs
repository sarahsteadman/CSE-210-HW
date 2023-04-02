public class Piece
{
    protected bool _white;
    protected string _symbol;
    protected Square _place;
    protected List<Square> _moves = new List<Square>();
    protected char[] _letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
    protected List<Square> _currentBoard;
    protected bool _moved = false;
    protected bool _inCheck;

    public virtual Piece MakeCopy()
    {
        return new Piece();
    }

    public bool IsWhite()
    {
        return _white;
    }

    public virtual void SetPlace(Square place)
    {
        _place = place;
    }

    public string GetSymbol()
    {
        return _symbol;
    }

    public bool hasMoved()
    {
        return _moved;
    }

    public virtual List<Square> GetMoves(List<Square> squares)
    {
        _currentBoard = squares;
        _moves.Clear();

        string currentSpot = _place.GetName();
        char[] parts = currentSpot.ToCharArray();
        double num = Char.GetNumericValue(parts[1]);
        char let = parts[0];

        CalculateMoves(let, num, squares);
        return _moves;
    }
    public virtual void CalculateMoves(char letter, double num, List<Square> squares)
    {
    }

    //Checks to see if a spot that a piece would like to move to is occupied and what color it is
    // It will add the spot to the moves list if appropriate and return a bool to tell 
    // the piece to stop or continue
    protected bool SpotOccupied(string name, List<Square> squares)
    {
        Square spot = squares.First(square => square.GetName() == name);
        var occupied = spot.IsOccupied();

        if (occupied)
        {
            Piece piece = spot.OccupyingPiece();
            var white = piece.IsWhite();
            if (white == _white)
            {
                return true;
            }
            else
            {
                _moves.Add(spot);
                return true;
            }
        }

        if (_symbol == "P")
        {
            if (spot.IsEnPassant())
            {
                _moves.Add(spot);
            }
            return false;
        }
        else
        {
            _moves.Add(spot);
            return false;
        }
    }

    protected void MoveDiagnally(char letter, double num, List<Square> squares)
    {


        // POSITION IS THE INDEX OF THE LETTER IN ITS LIST
        int position = Array.IndexOf(_letters, letter);
        int iup = (int)num;
        int idown = (int)num;
        string name = "";
        bool occupied = false;

        // START AFTER THE _PLACE LETTER ON THE LETTER LIST AND GO UP UNTIL YOU REACH THE END
        for (int i = position + 1; i < 8; i++)
        {
            //INCREASE THE _PLACE NUMBER EACH ROUND AND IF IT'S LESS THAN NINE CREATE A POSITION NAME TO ADD TO THE LIST
            iup++;

            if (iup < 9)
            {
                name = $"{_letters[i]}{iup}";
                occupied = SpotOccupied(name, squares);

                if (occupied)
                {
                    iup = 10;
                }
            }

            //DECREASE THE _PLACE NUM EACH ROUND  AND IF IT'S MORE THAN 0 CREATE A ZERO AND ADD TO THE LIST
            idown -= 1;

            if (idown > 0)
            {
                name = $"{_letters[i]}{idown}";
                occupied = SpotOccupied(name, squares);

                if (occupied)
                {
                    idown = -1;
                }
            }
        }

        iup = (int)num;
        idown = (int)num;
        // START BEFORE THE _PLACE LETTER AND DESCEND THE LETTER LIST UNTIL YOU REACH THE END
        for (int i = position - 1; i > -1; i--)
        {
            //INCREASE THE _PLACE NUMBER EACH ROUND AND IF IT'S LESS THAN NINE CREATE A POSITION NAME TO ADD TO THE LIST
            iup++;

            if (iup < 9)
            {
                name = $"{_letters[i]}{iup}";
                occupied = SpotOccupied(name, squares);

                if (occupied)
                {
                    iup = 10;
                }
            }
            //DECREASE THE _PLACE NUM EACH ROUND  AND IF IT'S MORE THAN 0 CREATE A ZERO AND ADD TO THE LIST
            idown -= 1;

            if (idown > 0)
            {
                name = $"{_letters[i]}{idown}";
                occupied = SpotOccupied(name, squares);

                if (occupied)
                {
                    idown = -1;
                }
            }
        }
    }

    protected void MoveLinearly(char letter, double num, List<Square> squares)
    {
        int position = Array.IndexOf(_letters, letter);
        string name = "";
        bool occupied = true;

        for (int i = position + 1; i < 8; i++)
        {
            name = $"{_letters[i]}{num}";
            occupied = SpotOccupied(name, squares);

            if (occupied)
            {
                break;
            }
        }

        for (int i = position - 1; i > -1; i--)
        {
            name = $"{_letters[i]}{num}";
            occupied = SpotOccupied(name, squares);

            if (occupied)
            {
                break;
            }
        }

        for (int i = (int)num + 1; i < 9; i++)
        {
            name = $"{letter}{i}";
            occupied = SpotOccupied(name, squares);

            if (occupied)
            {
                break;
            }
        }
        for (int i = (int)num - 1; i > 0; i--)
        {
            name = $"{letter}{i}";
            occupied = SpotOccupied(name, squares);

            if (occupied)
            {
                break;
            }
        }
    }

    public List<Square> TargetKing(List<Square> squares)
    {
        List<Square> attacks = new List<Square>();
        foreach (Square square in squares)
        {
            if (square.IsOccupied())
            {
                Piece piece = square.OccupyingPiece();
                if (piece.IsWhite() != _white)
                {

                    attacks = attacks.Concat(piece.GetMoves(squares)).ToList();

                }
            }
        }

        return attacks;
    }

    public void setCheck(bool inCheck)
    {
        _inCheck = inCheck;
    }
}
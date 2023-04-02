public class Pawn : Piece
{

    public Pawn(bool white)
    {
        _white = white;
        _moved = false;
        _symbol = "P";

    }
    public override Piece MakeCopy()
    {
        Pawn copy = new Pawn(_white);

        copy._moved = _moved;

        return copy;
    }
    public override void SetPlace(Square place)
    {
        if (_place != null)
        {
            checkEnPassant(place);
        }

        _place = place;

        if (_place.GetName()[1] != '2' && _place.GetName()[1] != '7')
        {
            _moved = true;
        }

    }
    public override void CalculateMoves(char let, double num, List<Square> squares)
    {
        int position = Array.IndexOf(_letters, let);

        if (!_moved)
        {
            MoveForward(2, num, let, squares);

        }

        num = MoveForward(1, num, let, squares);


        if (position + 1 < 8)
        {
            string right = $"{_letters[position + 1]}{num}";

            SpotOccupied(right, squares);
        }
        if (position - 1 > -1)
        {
            string left = $"{_letters[position - 1]}{num}";

            SpotOccupied(left, squares);
        }
    }

    private double MoveForward(int spaces, double num, char let, List<Square> squares)
    {
        if (!_white)
        {
            num += spaces;
        }
        else
        {
            num -= spaces;
        }

        // lines 32 - 39 are used instead of the SpotOccupied method because it behaves 
        // differently than when a pawn moves diagnolly which is what that method accounts
        // for.

        if (num > 0 && num < 9)
        {
            Square move = squares.First(square => square.GetName() == $"{let}{num}");

            bool occupied = move.IsOccupied();

            if (!occupied)
            {
                _moves.Add(move);
            }

        }

        return num;
    }
    private void checkEnPassant(Square place)
    {
        int num = place.GetY();
        char let = place.GetName()[0];

        int difference = num - _place.GetY();

        if (difference == 2 || difference == -2)
        {
            int position = Array.IndexOf(_letters, let);
            Square ep = null;

            if (difference == -2)
            {
                ep = _currentBoard.Find(s => s.GetName() == ($"{let}{num + 1}"));
            }
            else if (difference == +2)
            {
                ep = _currentBoard.Find(s => s.GetName() == ($"{let}{num - 1}"));
            }

            if (position + 1 < 8)
            {
                string right = $"{_letters[position + 1]}{num}";
                Square spot = _currentBoard.First(square => square.GetName() == right);

                if (spot.IsOccupied())
                {
                    Square current = _currentBoard.First(square => square.GetName() == $"{let}{num}");
                    ep.SetEnPassant(current);
                }
            }
            if (position - 1 > -1)
            {
                string left = $"{_letters[position - 1]}{num}";
                Square spot = _currentBoard.First(square => square.GetName() == left);

                if (spot.IsOccupied())
                {
                    Square current = _currentBoard.First(square => square.GetName() == $"{let}{num}");
                    ep.SetEnPassant(current);
                }
            }
        }
    }
}

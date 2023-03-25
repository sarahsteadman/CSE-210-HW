public class Pawn : Piece
{
    private bool _moved = false;

    public Pawn(bool white)
    {
        _white = white;

        if (_white)
        {
            _symbol = "P";
        }
        else
        {
            _symbol = "p";
        }
    }
    public override Piece MakeCopy()
    {
        Pawn copy = new Pawn(_white);

        copy._moved = _moved;

        return copy;
    }
    public override void SetPlace(Square place)
    {
        _place = place;
        if (_place.GetName()[1] != '2' && _place.GetName()[1] != '7')
        {
            _moved = true;
        }
        if (_place.GetName()[1] == '1' || _place.GetName()[1] == '8')
        {
            Upgrade();
        }

    }
    public override void CalculateMoves(char let, double num, List<Square> squares)
    {

        if (!_moved)
        {
            MoveForward(2, num, let, squares);
        }

        num = MoveForward(1, num, let, squares);

        int position = Array.IndexOf(_letters, let);

        if (position + 1 < 8)
        {
            string left = $"{_letters[position + 1]}{num}";

            SpotOccupied(left, squares);
        }
        if (position - 1 > -1)
        {
            string right = $"{_letters[position - 1]}{num}";

            SpotOccupied(right, squares);
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
    private void Upgrade()
    {
        Console.WriteLine("Type 'N' or 'Q' to upgrade this pawn to a Knight or Queen.");
        string choice = Console.ReadLine().ToUpper();

        if (choice == "N")
        {
            Knight knight = new Knight(_white);
            _place.Occupy(knight, _place);
        }
        else if (choice == "Q")
        {
            Queen queen = new Queen(_white);
            _place.Occupy(queen, _place);
        }
    }
}
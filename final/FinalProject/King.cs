public class King : Piece
{
    public King(bool white)
    {
        _white = white;
        _symbol = "K";
        _moved = false;
    }

    public override Piece MakeCopy()
    {
        King copy = new King(_white);

        copy._moved = _moved;

        return copy;
    }

    public override void CalculateMoves(char let, double num, List<Square> squares)
    {

        int position = Array.IndexOf(_letters, let);
        List<string> moves = new List<string>();

        if (position - 1 > -1)
        {
            SpotOccupied($"{_letters[position - 1]}{num}", squares);

            if (num - 1 > 0)
            {
                SpotOccupied($"{_letters[position - 1]}{num - 1}", squares);
            }
            if (num + 1 < 9)
            {
                SpotOccupied($"{_letters[position - 1]}{num + 1}", squares);
            }
        }
        if (position + 1 < 8)
        {
            SpotOccupied($"{_letters[position + 1]}{num}", squares);

            if (num - 1 > 0)
            {
                SpotOccupied($"{_letters[position + 1]}{num - 1}", squares);
            }
            if (num + 1 < 9)
            {
                SpotOccupied($"{_letters[position + 1]}{num + 1}", squares);
            }
        }

        if (num - 1 > 0)
        {
            SpotOccupied($"{_letters[position]}{num - 1}", squares);
        }
        if (num + 1 < 9)
        {
            SpotOccupied($"{_letters[position]}{num + 1}", squares);
        }
    }

}

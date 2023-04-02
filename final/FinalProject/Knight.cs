public class Knight : Piece
{
    public Knight(bool white)
    {
        _white = white;


        _symbol = "N";


    }
    public override Piece MakeCopy()
    {
        Knight copy = new Knight(_white);

        return copy;
    }
    public override void CalculateMoves(char let, double num, List<Square> squares)
    {
        int position = Array.IndexOf(_letters, let);

        if (position - 1 > -1)
        {
            if (num - 2 > 0)
            {
                SpotOccupied($"{_letters[position - 1]}{num - 2}", squares);
            }
            if (num + 2 < 9)
            {
                SpotOccupied($"{_letters[position - 1]}{num + 2}", squares);
            }
        }
        if (position + 1 < 8)
        {
            if (num - 2 > 0)
            {
                SpotOccupied($"{_letters[position + 1]}{num - 2}", squares);
            }
            if (num + 2 < 9)
            {
                SpotOccupied($"{_letters[position + 1]}{num + 2}", squares);
            }
        }

        if (position - 2 > -1)
        {

            if (num - 1 > 0)
            {
                SpotOccupied($"{_letters[position - 2]}{num - 1}", squares);
            }
            if (num + 1 < 9)
            {
                SpotOccupied($"{_letters[position - 2]}{num + 1}", squares);
            }
        }
        if (position + 2 < 8)
        {
            if (num - 1 > 0)
            {
                SpotOccupied($"{_letters[position + 2]}{num - 1}", squares);
            }
            if (num + 1 < 9)
            {
                SpotOccupied($"{_letters[position + 2]}{num + 1}", squares);
            }
        }

    }


}
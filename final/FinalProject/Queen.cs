public class Queen : Piece
{
private bool _inCheck = false;

public Queen( bool white)
{
    _white = white;

        if (_white)
        {
            _symbol = "Q";
        }
        else
        {
            _symbol = "q";
        }
}
    public override Piece MakeCopy()
    {
        Queen copy = new Queen(_white);

        return copy;
    }
    public override void CalculateMoves(char letter, double num, List<Square> squares)
    {
        MoveDiagnally(letter, num, squares);
        MoveLinearly(letter, num, squares);

    }
}
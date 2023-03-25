public class Rook : Piece
{
    private bool _moved = false;
    private bool _inCheck = false;

    public Rook(bool white)
    {
        _white = white;

        if (_white)
        {
            _symbol = "R";
        }
        else
        {
            _symbol = "r";
        }
    }
    public override Piece MakeCopy()
    {
        Rook copy = new Rook(_white);

        copy._moved = _moved;

        return copy;
    }

    public override void CalculateMoves(char letter, double num, List<Square> squares)
    {
        MoveLinearly(letter, num, squares);
    }

}
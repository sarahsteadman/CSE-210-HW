public class Bishop : Piece
{
    public Bishop(bool white)
    {
        _white = white;
        _moved = false;
        _symbol = "B";
    }

    public override Piece MakeCopy()
    {
        Bishop copy = new Bishop(_white);

        return copy;
    }

    public override void CalculateMoves(char letter, double num, List<Square> squares)
    {
        MoveDiagnally(letter, num, squares);

    }
}
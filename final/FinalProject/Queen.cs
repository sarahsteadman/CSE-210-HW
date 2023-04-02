public class Queen : Piece
{

    public Queen(bool white)
    {
        _white = white;
        _moved = false;
        _symbol = "Q";
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
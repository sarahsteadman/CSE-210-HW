public class King : Piece
{
    private bool _moved = false;
    private bool _inCheck = false;

    public King(bool white)
    {
        _white = white;

        if (_white)
        {
            _symbol = "K";
        }
        else
        {
            _symbol = "k";
        }
    }

    public override Piece MakeCopy()
    {
        King copy = new King(_white);

        copy._moved = _moved;

        return copy;
    }
    public override void CalculateMoves(char let, double num, List<Square> squares)
    {
        List<string> moves = KingMoves(let, num);

        List<Square> attacks = TargetKing(squares);

        foreach (string move in moves)
        {
            bool canTarget = attacks.Any(item => item.GetName() == move);
            if (!canTarget)
            {
                SpotOccupied(move, squares);
            }
        }
    }
}

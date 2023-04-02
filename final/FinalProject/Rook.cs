public class Rook : Piece
{
    private bool _canCastle = false;

    public Rook(bool white)
    {
        _white = white;
        _symbol = "R";
        _moved = false;

    }

    public override Piece MakeCopy()
    {
        Rook copy = new Rook(_white);

        copy._moved = _moved;

        return copy;
    }

    public override void SetPlace(Square place)
    {

        string name = place.GetName();

        if (name == "C1" || name == "C8" || name == "F1" || name == "F8")
        {
            if (_canCastle)
            {
                Console.WriteLine("Would you like to castle?");
                Console.WriteLine("(Enter Y to castle)");
                string answer = Console.ReadLine();

                if (answer.ToUpper() == "Y")
                {

                    if (name == "C1" && _place.GetName() == "A1")
                    {
                        Castle(1);
                    }
                    else if (name == "C8" && _place.GetName() == "A8")
                    {
                        Castle(2);
                    }
                    else if (name == "F1" && _place.GetName() == "H1")
                    {
                        Castle(3);
                    }
                    else if (name == "F8" && _place.GetName() == "H8")
                    {
                        Castle(4);
                    }
                }
            }
        }

        _place = place;
    }

    public override void CalculateMoves(char letter, double num, List<Square> squares)
    {
        _canCastle = false;
        MoveLinearly(letter, num, squares);

        if (!_moved)
        {
            if (!_inCheck)
            {
                if (_white)
                {
                    Square kingsSquare = squares.Find(s => s.GetName() == "E8");

                    if (kingsSquare.IsOccupied())
                    {
                        Piece king = kingsSquare.OccupyingPiece();

                        if (!king.hasMoved())
                        {
                            if (_place.GetName() == "A8")
                            {
                                if (_moves.Any(s => s.GetName() == "B8") && _moves.Any(s => s.GetName() == "C8") && _moves.Any(s => s.GetName() == "D8"))
                                {
                                    _canCastle = true;
                                }
                            }
                            else if (_place.GetName() == "H8")
                            {
                                if (_moves.Any(s => s.GetName() == "G8") && _moves.Any(s => s.GetName() == "F8"))
                                {
                                    _canCastle = true;
                                }
                            }
                        }


                    }
                }
                if (!_white)
                {
                    Square kingsSquare = squares.Find(s => s.GetName() == "E1");

                    if (kingsSquare.IsOccupied())
                    {
                        Piece king = kingsSquare.OccupyingPiece();

                        if (!king.hasMoved())
                        {
                            if (_place.GetName() == "A1")
                            {
                                if (_moves.Any(s => s.GetName() == "B1") && _moves.Any(s => s.GetName() == "C1") && _moves.Any(s => s.GetName() == "D1"))
                                {
                                    _canCastle = true;
                                }
                            }
                            else if (_place.GetName() == "H1")
                            {
                                if (_moves.Any(s => s.GetName() == "G1") && _moves.Any(s => s.GetName() == "F1"))
                                {
                                    _canCastle = true;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    private void Castle(int num)
    {
        Square kingmove = new Square(1, 1);

        switch (num)
        {
            case 1:
                kingmove = _currentBoard.Find(s => s.GetName() == "B1");
                break;
            case 2:
                kingmove = _currentBoard.Find(s => s.GetName() == "B8");
                break;
            case 3:
                kingmove = _currentBoard.Find(s => s.GetName() == "G1");
                break;
            case 4:
                kingmove = _currentBoard.Find(s => s.GetName() == "G8");

                break;
        }

        Square kingsquare = _currentBoard.Find(s => Program.FindBySymbol(s, "K", _white));
        Piece king = kingsquare.OccupyingPiece();

        kingsquare.Leave();
        kingmove.Occupy(king, kingmove);

    }
}
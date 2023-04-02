public class Square
{
    private string _name;
    private int _x;
    private int _y;
    private bool _isOccupied;
    private Piece _occupyingPiece;
    private Square _epPawn = null;

    public Square(int x, int y)
    {
        _x = x;
        _y = y;

        SpotNamer();
    }

    private void SpotNamer()
    {
        string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H" };

        int i = _x - 1;
        _name = $"{letters[i]}{_y}";
    }

    public string GetName()
    {
        return _name;
    }

    public int GetY()
    {
        return _y;
    }

    public void Occupy(Piece p, Square s)
    {
        p.SetPlace(s);
        _isOccupied = true;
        _occupyingPiece = p;

        if (_epPawn != null)
        {
            if (p.GetSymbol() == "P") ;
            {
                EnPassant();
            }
        }
    }

    public void Leave()
    {
        _isOccupied = false;
        _occupyingPiece = null;
    }

    public void DisplaySquare(int magicNumber)
    {
        if (_x == magicNumber)
        {
            if (_isOccupied)
            {
                if (!_occupyingPiece.IsWhite())
                {
                    Console.Write("| ");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(_occupyingPiece.GetSymbol());
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" |");

                }
                else
                {
                    Console.Write($"| {_occupyingPiece.GetSymbol()} |");
                }
            }
            else
            {
                Console.Write("|   |");
            }
        }
        else
        {
            if (_isOccupied)
            {
                if (!_occupyingPiece.IsWhite())
                {
                    Console.Write("| ");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(_occupyingPiece.GetSymbol());
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" ");
                }
                else
                {
                    Console.Write($"| {_occupyingPiece.GetSymbol()} ");
                }
            }
            else
            {
                Console.Write("|   ");
            }

        }
    }

    public bool IsOccupied()
    {
        return _isOccupied;
    }

    public Piece OccupyingPiece()
    {
        return _occupyingPiece;
    }

    public void SetEnPassant(Square PawnsSquare)
    {
        _epPawn = PawnsSquare;
    }

    public Square GetEPPawn()
    {
        return _epPawn;
    }

    public bool IsEnPassant()
    {

        if (_epPawn != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void EnPassant()
    {
        _epPawn.Leave();
        _epPawn = null;
    }
}
public class Square
{
    private string _name;
    private int _x;
    private int _y;
    private bool _isOccupied;
    private Piece _occupyingPiece;
    private Square _enPassant = null;

    public Square(int x, int y)
    {
        _x = x;
        _y = y;

        SpotNamer();
    }
    private void SpotNamer()
    {
        string[] letters = {"A","B","C","D","E", "F", "G", "H"};

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
        _isOccupied = true;
        _occupyingPiece = p;
        p.SetPlace(s);

        if (_enPassant != null)
        {
            if( p.GetSymbol() == "p" || p.GetSymbol() ==  "P");
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
            Console.Write($"| {_occupyingPiece.GetSymbol()} |");
            }
            else{
                Console.Write("|   |");
            }
        }
        else
        {
            if (_isOccupied)
            {
            Console.Write($"| {_occupyingPiece.GetSymbol()} ");
            }
            else{
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
        PawnsSquare = _enPassant;
    }
    public bool ActiveEnPassant()
    {
        if(_enPassant != null)
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
            _enPassant.Leave();
            _enPassant = null;
    }
}
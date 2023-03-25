using System;

//  Castling, En Passant
//
//Hypothetically Checks and game ending has been programmed. Requires testing.
//

// 
class Program
{
    static void Main(string[] args)
    {
        List<Square> squares = MakeChessBoard();

        Queen q = new Queen(false);
        Square s = squares.Find(s => s.GetName() == "E7");

        s.Occupy(q, s);
        bool over = false;
        bool whiteTurn = true;


        while (!over)
        {
            DisplayChessBoard(whiteTurn, squares);
            string symbol = "";
            if (whiteTurn)
            {
                Console.WriteLine("White choose a piece to move");

                symbol = "K";
            }
            else
            {
                symbol = "k";
                Console.WriteLine("Black choose a piece to move");
            }

            bool incheck = checkCheck(symbol, squares);
            if (incheck)
            {
                over = checkCheckmate(symbol, squares);

                if (over)
                {
                    Console.WriteLine("CHECKMATE!!!");
                    break;
                }
                else
                {
                    Console.WriteLine("Your king is in check. He must be out of check by the end of your turn.");
                }
            }

            string selectedSquare = Console.ReadLine().ToUpper();
            Square selected = squares.Find(s => s.GetName() == selectedSquare);

            try
            {

                if (selected.IsOccupied() == false)
                {
                    Console.WriteLine("This Square is empty. Please select another");
                    Thread.Sleep(2000);
                    Console.Clear();
                    continue;
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("That is not a valid square name. Select another one.");
                Thread.Sleep(2000);
                Console.Clear();
                continue;
            }

            Piece piece = selected.OccupyingPiece();

            if (piece.IsWhite() != whiteTurn)
            {
                Console.WriteLine("This piece is your opponents. Choose one of your own pieces");
                Thread.Sleep(2000);
                Console.Clear();
                continue;
            }

            List<Square> moves = piece.GetMoves(squares);
            if (moves.Count > 0)
            {
                Console.WriteLine("The available moves for this piece are:");

                foreach (Square move in moves)
                {
                    Console.Write($"{move.GetName()} ");
                }

                Console.WriteLine();
                Console.WriteLine("Enter the move you want or 'b' to select a different piece.");

                string selectedMove = Console.ReadLine().ToUpper();

                if (selectedMove == "B")
                {
                    Console.Clear();
                    continue;
                }

                int index = moves.FindIndex(move => move.GetName() == selectedMove);
                if (index >= 0)
                {
                    selected.Leave();
                    moves[index].Occupy(piece, moves[index]);

                    if (incheck)
                    {
                        incheck = checkCheck(symbol, squares);

                        if (incheck)
                        {
                            moves[index].Leave();
                            selected.Occupy(piece, selected);
                            Console.WriteLine("This move does not protect your king from being in check. Select another one.");
                            Thread.Sleep(2000);
                            Console.Clear();
                            continue;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("That is not an available move.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    continue;
                }

            }
            else
            {
                Console.WriteLine("There are no moves for this piece. Select another one");
                Thread.Sleep(2000);

                Console.Clear();

                continue;
            }

            if (whiteTurn)
            {
                whiteTurn = false;
            }
            else
            {
                whiteTurn = true;
            }


        }


    }

    static List<Square> MakeChessBoard()

    {
        List<Square> squares = MakeSquares();
        var pawns = MakePawns();
        var pieces = MakePieces();

        foreach (Square spot in squares)
        {

            if (spot.GetY() == 2 | spot.GetY() == 7)
            {

                spot.Occupy(pawns.First(), spot);
                pawns.RemoveAt(0);

            }
            else if (spot.GetY() == 8)
            {
                spot.Occupy(pieces.First(), spot);
                pieces.RemoveAt(0);
            }
        }

        pieces.Reverse();

        foreach (Square spot in squares)
        {
            if (spot.GetY() == 1)
            {
                spot.Occupy(pieces.First(), spot);
                pieces.RemoveAt(0);
            }
        }

        return squares;
    }
    static void DisplayChessBoard(bool white, List<Square> squares)
    {
        Console.WriteLine(white);
        foreach (Square square in squares)
        {
            Console.WriteLine(square.GetName());
        }

        List<Square> fakeSquares = squares;
        string letters = "   A   B   C   D   E   F   G   H";
        int grid = 1;
        int counter = 8;
        int rowStart = 8;

        if (!white)
        {
            fakeSquares = Enumerable.Reverse(squares).ToList();
            letters = "   H   G   F   E   D   C   B   A";
            grid = 8;
            rowStart = 1;
        }

        Console.Clear();
        foreach (Square square in fakeSquares)
        {

            if (counter == 8)
            {
                Console.WriteLine();
                Console.WriteLine($" + — + — + — + — + — + — + — + — +");
                Console.Write(grid);
                if (!white)
                {
                    grid--;
                }
                else
                {
                    grid++;
                }
                counter = 0;
            }
            square.DisplaySquare(rowStart);
            counter++;
        }

        Console.WriteLine();
        Console.WriteLine($" + — + — + — + — + — + — + — + — +");
        Console.WriteLine(letters);

        Console.WriteLine();
        // + — + — + — + — + — + — + — + — +
        //1|   |   |   |   |   |   |   |   |
        // + — + — + — + — + — + — + — + — +
        //2|   |   |   |   |   |   |   |   |
        // + — + — + — + — + — + — + — + — +
        //3|   |   |   |   |   |   |   |   |
        // + — + — + — + — + — + — + — + — +
        //4|   |   |   |   |   |   |   |   |
        // + — + — + — + — + — + — + — + — +
        //5|   |   |   |   |   |   |   |   |
        // + — + — + — + — + — + — + — + — +
        //6|   |   |   |   |   |   |   |   |
        // + — + — + — + — + — + — + — + — +
        //7|   |   |   |   |   |   |   |   |
        // + — + — + — + — + — + — + — + — +
        //8|   |   |   |   |   |   |   |   |
        // + — + — + — + — + — + — + — + — +
        //   A   B   C   D   E   F   G   H
    }
    static List<Piece> MakePawns()
    {
        List<Piece> pawns = new List<Piece>();

        for (int i = 1; i < 17; i++)
        {
            bool white = true;
            if (i < 9)
            {
                white = false;
            }

            Pawn p = new Pawn(white);
            pawns.Add(p);
        }


        return pawns;
    }

    static List<Square> MakeSquares()
    {
        List<Square> squares = new List<Square>();

        for (int y = 1; y < 9; y++)
        {
            for (int x = 1; x < 9; x++)
            {
                Square newSquare = new Square(x, y);

                squares.Add(newSquare);
            }
        }


        return squares;
    }

    static List<Piece> MakePieces()
    {
        var white = true;
        var pieces = new List<Piece>();

        for (int i = 1; i < 3; i++)
        {
            if (i > 1)
            {
                white = false;
            }

            Rook rook1 = new Rook(white);
            Knight knight1 = new Knight(white);
            Bishop bishop1 = new Bishop(white);
            Queen queen = new Queen(white);
            King king = new King(white);
            Bishop bishop2 = new Bishop(white);
            Knight knight2 = new Knight(white);
            Rook rook2 = new Rook(white);

            pieces.Add(rook1);
            pieces.Add(knight1);
            pieces.Add(bishop1);
            pieces.Add(queen);
            pieces.Add(king);
            pieces.Add(bishop2);
            pieces.Add(knight2);
            pieces.Add(rook2);

        }
        return pieces;
    }

    static bool checkCheck(string symbol, List<Square> squares)
    {
        Square kingsSquare = squares.Find(s => FindBySymbol(s, symbol));
        Piece king = kingsSquare.OccupyingPiece();
        List<Square> attacks = king.TargetKing(squares);
        bool canTarget = attacks.Any(s => s.GetName() == kingsSquare.GetName());

        return canTarget;
    }

    static bool checkCheckmate(string symbol, List<Square> squares)
    {
        List<Square> fakeSquares = MakeSquares();

        foreach (Square square in squares)
        {
            if (square.IsOccupied())
            {
                Piece p = square.OccupyingPiece();
                Piece fakeP = p.MakeCopy();

                Square fakeSquare = fakeSquares.Find(s => s.GetName() == square.GetName());

                fakeSquare.Occupy(fakeP, fakeSquare);
            }
        }

        Square kingsSquare = fakeSquares.Find(s => FindBySymbol(s, symbol));
        Piece king = kingsSquare.OccupyingPiece();
        List<Square> moves = new List<Square>();
        List<Square> kingMoves = new List<Square>();

        foreach (Square square in fakeSquares)
        {
            if (square.IsOccupied())
            {
                Piece piece = square.OccupyingPiece();
                if (piece.IsWhite() == king.IsWhite())
                {
                    // if (piece.GetSymbol() == "K" || piece.GetSymbol() == "k")
                    // {
                    //     kingMoves = kingMoves.Concat(piece.ForbidonSquares(kingsSquare.GetName(), squares)).ToList();
                    //     continue;
                    // }
                    moves = moves.Concat(piece.GetMoves(fakeSquares)).ToList();

                }
            }
        }

        foreach (Square move in kingMoves)
        {
            kingsSquare.Leave();
            move.Occupy(king, move);

            if (move.IsOccupied())
            {
                continue;
            }


            if (!checkCheck(symbol, fakeSquares))
            {
                move.Leave();
                kingsSquare.Occupy(king, kingsSquare);

                DisplayChessBoard(true, squares);
                Console.WriteLine("1");
                Console.ReadLine();
                return false;
            }

            move.Leave();
            kingsSquare.Occupy(king, kingsSquare);
        }

        foreach (Square move in moves)
        {
            Pawn pretend = new Pawn(king.IsWhite());
            move.Occupy(pretend, move);

            if (!checkCheck(symbol, fakeSquares))
            {
                move.Leave();
                return false;
            }

            move.Leave();
        }

        return true;

    }
    static bool FindBySymbol(Square square, string symbol)
    {
        if (square.IsOccupied())
        {
            if (square.OccupyingPiece().GetSymbol() == symbol)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}

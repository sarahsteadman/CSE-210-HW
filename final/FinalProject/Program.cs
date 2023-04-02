using System;

// test if program tries to get pawns to upgrade during checkcheckmate
class Program
{
    static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.DarkCyan;
        Console.ForegroundColor = ConsoleColor.White;
        List<Square> squares = MakeChessBoard();
        Stack<List<Square>> boardRecord = new Stack<List<Square>>();

        bool over = false;
        bool whiteTurn = true;

        boardRecord.Push(CopyBoard(squares));
        Instructions();

        while (!over)
        {

            // ****************************Round Set Up******************************** //

            bool inCheck = false;

            EndEnPassant(whiteTurn, squares);

            DisplayChessBoard(whiteTurn, squares);

            if (whiteTurn)
            {
                Console.WriteLine("White choose a piece to move");
            }
            else
            {
                Console.WriteLine("Black choose a piece to move");
            }

            inCheck = CheckCheck(whiteTurn, squares);

            over = CheckCheckmate(whiteTurn, squares);

            if (inCheck)
            {
                if (over)
                {
                    Console.WriteLine("CHECKMATE!!!");
                    Console.ReadLine();
                    over = true;
                }
                else
                {
                    Console.WriteLine("Your king is in check. He must be out of check by the end of your turn.");
                }
            }


            if (over)
            {
                break;
            }


            // ***********************Selecting a move*************************** //



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
                Console.WriteLine("Enter the move you want or 'B' to select a different piece.");

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

                    bool secondCheck = CheckCheck(whiteTurn, squares);

                    if (secondCheck)
                    {
                        string message = "This move puts your king in check. Select another move";
                        if (inCheck)
                        {
                            message = "This move does not protect your king from being in check. Select another one.";
                        }

                        squares = boardRecord.Peek().ToList();
                        Console.WriteLine(message);
                        Thread.Sleep(2000);
                        Console.Clear();
                        continue;

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

            UpgradePawn(squares);
            DisplayChessBoard(whiteTurn, squares);

            Console.WriteLine("Is this the move you wanted?");
            Console.WriteLine("(Entern N to undo)");
            string answer = Console.ReadLine().ToUpper();

            if (answer == "N")
            {
                squares = boardRecord.Peek().ToList();
                continue;
            }

            boardRecord.Push(CopyBoard(squares));

            // **********************Switching Players************************ //


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

    static void Instructions()
    {
        Console.WriteLine("Welcome to the Chess Program!");
        Console.WriteLine("Would you like some instructions on how to use this program?");
        Console.WriteLine("(Entern Y to bring up instructions)");

        string answer = Console.ReadLine();
        answer = answer.ToUpper();

        if (answer == "Y")
        {
            Console.WriteLine(" To move pieces on the Chess board, select a square by typing in the row then column name ie(A1)");
            Console.WriteLine();
            Console.WriteLine(" A set of moves that the piece can perform will will appear.  Enter one of the options.");
            Console.WriteLine();
            Console.WriteLine(" Please note that if that move puts your king in check, you will be asked to select another one.");
            Console.WriteLine();
            Console.WriteLine(" If you'd like to select another piece to move, type b.");
            Console.WriteLine();
            Console.WriteLine(" If you would like to castle, select the rook and then the spot it would move to when it castles. If you are able to castle you will be given that option.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" To learn what moves each Piece can perform, or to learn the rules of Chess, go to https://chesscoachonline.com/chess-rules");
            Console.ReadLine();
        }
    }

    static List<Square> MakeChessBoard()

    {
        List<Square> squares = MakeSquares();
        var pawns = MakePawns();
        var pieces = MakePieces();

        foreach (Square spot in squares)
        {

            if (spot.GetY() == 2 || spot.GetY() == 7)
            {

                spot.Occupy(pawns.First(), spot);
                pawns.RemoveAt(0);

            }
            else if (spot.GetY() == 8 || spot.GetY() == 1)
            {
                spot.Occupy(pieces.First(), spot);
                pieces.RemoveAt(0);
            }
        }

        return squares;
    }

    static void DisplayChessBoard(bool white, List<Square> squares)
    {

        List<Square> fakeSquares = squares;
        string letters = "   A   B   C   D   E   F   G   H  ";
        int grid = 1;
        int counter = 8;
        int rowStart = 8;

        if (!white)
        {
            fakeSquares = Enumerable.Reverse(squares).ToList();
            letters = "   H   G   F   E   D   C   B   A  ";
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
        //2|   | * |   |   |   |   |   |   |
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
        var white = false;
        var pieces = new List<Piece>();

        for (int i = 1; i < 3; i++)
        {
            if (i > 1)
            {
                white = true;
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

    static bool CheckCheck(bool white, List<Square> squares)
    {
        string symbol = "K";
        Square kingsSquare = squares.Find(s => FindBySymbol(s, symbol, white));
        Piece king = kingsSquare.OccupyingPiece();
        List<Square> attacks = king.TargetKing(squares);

        bool canTarget = attacks.Any(s => s.GetName() == kingsSquare.GetName());

        List<Square> rooksquares = squares.FindAll(s => (FindBySymbol(s, "R", white)));

        foreach (Square square in rooksquares)
        {
            square.OccupyingPiece().setCheck(canTarget);
        }

        return canTarget;
    }

    static bool CheckCheckmate(bool white, List<Square> squares)
    {
        string symbol = "K";

        List<Square> fakeSquares = CopyBoard(squares);

        Square kingsSquare = fakeSquares.Find(s => FindBySymbol(s, symbol, white));
        Piece king = kingsSquare.OccupyingPiece();
        List<Square> moves = new List<Square>();
        bool viableMoves = false;

        foreach (Square square in fakeSquares)
        {
            if (square.IsOccupied())
            {
                Piece piece = square.OccupyingPiece();
                if (piece.IsWhite() == king.IsWhite())
                {
                    //Checks to see if a 'StaleMate' has occured
                    moves = piece.GetMoves(fakeSquares);
                    if (moves.Count < 1)
                    {
                        continue;
                    }

                    viableMoves = true;

                    if (piece.GetSymbol() == "P")
                    {
                        piece = new Queen(king.IsWhite());
                    }
                    foreach (Square move in moves)
                    {
                        square.Leave();
                        move.Occupy(piece, move);
                        if (!CheckCheck(white, fakeSquares))
                        {
                            return false;
                        }
                        else
                        {
                            move.Leave();
                            square.Occupy(piece, move);
                        }

                    }

                }
            }
        }

        if (!viableMoves)
        {
            Console.WriteLine("There are no more viable moves!");
        }

        return true;
    }

    public static bool FindBySymbol(Square square, string symbol, bool white)
    {
        if (square.IsOccupied())
        {
            if (square.OccupyingPiece().GetSymbol() == symbol)
            {
                if (square.OccupyingPiece().IsWhite() == white)
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
        else
        {
            return false;
        }
    }

    static void EndEnPassant(bool white, List<Square> squares)
    {
        foreach (Square square in squares)
        {
            if (square.IsEnPassant())
            {
                Square s = square.GetEPPawn();
                Piece p = s.OccupyingPiece();
                bool w = p.IsWhite();

                if (square.GetEPPawn().OccupyingPiece().IsWhite() == white)
                {
                    square.SetEnPassant(null);
                }
            }
        }
    }

    static List<Square> CopyBoard(List<Square> squares)
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

        return fakeSquares;
    }

    public static void UpgradePawn(List<Square> squares)
    {
        foreach (Square square in squares)
        {
            if (square.GetY() == 1 || square.GetY() == 8)
            {
                if (square.IsOccupied())
                {
                    bool white = square.OccupyingPiece().IsWhite();
                    if (square.OccupyingPiece().GetSymbol() == "P")
                    {

                        Console.WriteLine("Type 'N' or 'Q' to upgrade this pawn to a Knight or Queen.");
                        string choice = Console.ReadLine().ToUpper();

                        if (choice == "N")
                        {
                            Knight knight = new Knight(white);
                            square.Occupy(knight, square);
                        }
                        else if (choice == "Q")
                        {
                            Queen queen = new Queen(white);
                            square.Occupy(queen, square);
                        }
                    }
                }
            }
        }

    }
}
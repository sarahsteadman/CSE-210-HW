using System;

class Program
{
    static void Main(string[] args)
    {
        string end = "";
        Scripture Luke = impossible();

        Console.WriteLine("How many words would you like to disapear at a time?");
        int amount = int.Parse(Console.ReadLine());



        Luke.DisplayScripture();
        Console.WriteLine("");
        Console.WriteLine("Press enter to continue or type 'quit' to finish: ");
        end = Console.ReadLine();


        while (end != "quit")
        {
            Console.Clear();
            for (int i = 0; i < amount; i++)
            { Luke.HideWord(); }

            Luke.DisplayScripture();
            end = Console.ReadLine();

            if (end != "quit")
            {
                end = Luke.StillGoing();
            }

        }

    }
    static Scripture impossible()
    {
        Scripture imp = new Scripture();

        Reference impRef = new Reference();
        impRef.SetBook("Luke");
        impRef.SetChapter(1);
        impRef.SetfirstVerse("37");
        impRef.SetLastVerse("38");
        imp.SetReference(impRef);
        imp.SetText("For with God nothing shall be impossible. And Mary said, Behold the handmaid of the Lord; be it unto me according to thy word. And the angel departed from her.");

        return imp;
    }

}
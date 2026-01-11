using System;
using System.Collections;

public static partial class Draw
{
    public static void Rabbit(int ground)
    {
        (int x, int y) pos = GetGridPosition(ground);

        string[] Art = new string[]
        {
            " ⧵ / ",
            "(>_<)",
            "(_n_)"//귀엽다
        };

        //플레이어와 가까울때 변화 4~5, 7~8
        if (ground >= 4 && ground <= 5 || ground >= 7 && ground <= 8)
        {
            string[] attackArt = new string[]
            {
                " ⧵ / ",
                "(◣_◢)",
                "(_n_)"//사납다
            };
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(pos.x, pos.y + i);
                attackArt[i].Print(ConsoleColor.Red);
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(pos.x, pos.y + i);
                Art[i].Print();
            }
        }
    }

    public static void Ghost(int ground)
    {
        (int x, int y) pos = GetGridPosition(ground);

        string[] Art = new string[]
        {
            " ┌──┐",
            " ◠⌒◠",
            " └∾∾┘"
        };
        if (ground == 12)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(pos.x + 1, pos.y + i);
                Art[i].Print(ConsoleColor.Gray);
            }
        }
        else if (ground <= 8)
        {
            string[] attackArt = new string[]
            {
                " ┌──┐",
                " ◠‿◠)",
                " └∾∾┘"
            };
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(pos.x, pos.y + i);
                attackArt[i].Print(ConsoleColor.Red);
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(pos.x, pos.y + i);
                Art[i].Print(ConsoleColor.Gray);
            }
        }
    }
}
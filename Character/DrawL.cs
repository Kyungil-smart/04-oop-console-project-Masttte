using System;
using System.Configuration;

public static partial class Draw
{
    public static void Slime(int ground)
    {
        (int x, int y) pos = GetGridPosition(ground);

        string[] Art = new string[]
        {
            "     ",
            " .-. ",
            "(o_o)",
        };

        // 플레이어(6)와 가까워질 때 공격 태세
        if (ground >= 4)
        {
            string[] attackArt = new string[]
            {
                " ✧╦✧ ",
                " .╬.",
                "(●_●",
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
                Art[i].Print(ConsoleColor.Blue);
            }
        }
    }
    public static void Knocker(int ground)
    {
        (int x, int y) pos = GetGridPosition(ground);

        string[] Art = new string[]
        {

            "╱●◉╲",
            "┝─╇─┩",
            " │ │ "
        };

        if (ground == 3)
        {
            string[] attackArt = new string[]
            {
                "╱●◉╲",
                "┝─╇─┩",
                " │ │ "
            };
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(pos.x, pos.y + i);
                attackArt[i].Print(ConsoleColor.Red);
            }
        }
        else if (ground >= 4)
        {
            string[] attackArt = new string[]
            {
                "╱●●",
                "┝─╇─┩",
                " │ │ "
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
                Art[i].Print(ConsoleColor.DarkRed);
            }
        }
    }

}

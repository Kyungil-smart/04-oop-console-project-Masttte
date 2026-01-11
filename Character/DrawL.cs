using System;
using System.Collections;

public static partial class Draw
{
    public static void DrawSlime(int ground)
    {
        (int x, int y) pos = GetGridPosition(ground);

        string[] slimeArt = new string[]
        {
            "     ",
            " .-. ",
            "(o_o)", 
        };

        // 플레이어(6)와 가까워질 때 공격 태세 (왼쪽 1 -> 6 접근)
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
                slimeArt[i].Print(ConsoleColor.Blue);
            }
        }
    }
}
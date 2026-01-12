using System;
using System.Collections;

public static partial class Draw
{
    public static void Door(int ground)
    {
        (int x, int y) pos = GetGridPosition(ground);

        string[] Art = new string[]
        {
            "╔════╗",
            "║    ║",
            "║   ◉║",
            "║    ║",
            "░░░░░░"
        };

        for (int i = 0; i < 5; i++)
        {
            Console.SetCursorPosition(pos.x, pos.y + i -2);
            Art[i].Print(ConsoleColor.Red);
        }
    }
}
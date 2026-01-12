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
            "║    ║",
            "║   ◉║",
            "║    ║",
            "║    ║",
            "░░░░░░"
        };

        for (int i = 0; i < 7; i++)
        {
            Console.SetCursorPosition(pos.x, pos.y + i - 4);
            Art[i].Print(ConsoleColor.Red);
        }
    }

    public static void DoorOpening(int ground)
    {
        Coroutine.StartCoroutine(DoorAnimation(ground));
    }   

    public static IEnumerator DoorAnimation(int ground)
    {
        (int x, int y) pos = GetGridPosition(ground);
        string[][] frames = new string[][]
        {
            new string[]
            {
                "╔════╗",
                "║    ║",
                "║    ║",
                "║   ◉║",
                "║    ║",
                "║    ║",
                "░░░░░░"
            },
            new string[]
            {
                "╔═══╗ ",
                "║   ║ ",
                "║   ║ ",
                "║  ◉║ ",
                "║   ║ ",
                "║   ║ ",
                "░░░░░░"
            },
            new string[]
            {
                "╔══╗  ",
                "║  ║  ",
                "║  ║  ",
                "║ ◉║  ",
                "║  ║  ",
                "║  ║  ",
                "░░░░░░"
            },
            new string[]
            {
                "╔═╗   ",
                "║ ║   ",
                "║ ║   ",
                "║◉║   ",
                "║ ║   ",
                "║ ║   ",
                "░░░░░░"
            },
            new string[]
            {
                "╔╗    ",
                "║║    ",
                "║║    ",
                "║◉    ",
                "║║    ",
                "║║    ",
                "░░░░░░"
            }
        };
        foreach (var frame in frames)
        {
            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(pos.x, pos.y + i - 4);
                frame[i].Print(ConsoleColor.Red);
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}
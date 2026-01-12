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

    public static void BigFoot(int ground)
    {
        (int x, int y) pos = GetGridPosition(ground);
        string[] Art = new string[]
        {
            "    /∖___/⧵ ",
            "   /  o o  ⧵",
            "  ( =     = )",
            "   )       ( ",
            "  /         ⧵",
            " /  /⧵   /⧵  ⧵",
            " | |  | |  | |",
            " ⧵_|  |_|  |_/",
            "   ⧵__/ ⧵__/  "
        };
        if (ground == 7)
        {
            string[] attackArt = new string[]
            {
                "    /∖___/⧵ ",
                "   /  ◣ ◢  ⧵",
                "  ( =     = )",
                "   )       ( ",
                "  /  ✦   ✦  ⧵",
                " /  /⧵   /⧵  ⧵",
                " | |  | |  | |",
                " ⧵_|  |_|  |_/",
                "   ⧵__/ ⧵__/  "
            };  

            for (int i = 0; i < 9; i++)
            {
                Console.SetCursorPosition(pos.x, pos.y + i - 6);
                attackArt[i].Print(ConsoleColor.Yellow);
            }
            return;
        }
        else
        {
            for (int i = 0; i < 9; i++)
            {
                Console.SetCursorPosition(pos.x, pos.y + i - 6);
                Art[i].Print(ConsoleColor.DarkYellow);
            }
        }
    }
    public static void EmptyBig(int ground)
    {
        (int x, int y) pos = GetGridPosition(ground);

            for (int i = 0; i < 9; i++)
            {
                Console.SetCursorPosition(pos.x, pos.y + i - 6);
                Console.Write("              ");
            }
    }
    public static void DieBigFoot()
    {
        Coroutine.StartCoroutine(DieBigFootAnimation());
    }
    private static IEnumerator DieBigFootAnimation()
    {
        (int x, int y) pos = GetGridPosition(7);

        string[] frame1 = new string[]
        {
            "    /∖ _ /⧵ ",
            "   /  X X  ⧵",
            "  ( ✦   ✦   )",
            "   )   X   ( ",
            "  /  X   X  ⧵",
            " /  /⧵ X /⧵  ⧵",
            " | |  | |  | |",
            " ⧵_|  | |  |_/",
            "   ⧵__/ ⧵__/  "
        };

        for (int i = 0; i < 9; i++)
        {
            Console.SetCursorPosition(pos.x, pos.y + i - 6);
            frame1[i].Print(ConsoleColor.Red);
        }

        yield return new WaitForSeconds(0.047f);

        string[][] explosions = new string[][]
        {
            new string[]
            {
                "   ✦゜・✧゜ ",
                " ・✧✦☆✦✧・ ",
                "  ゜✦ ✴ ✦゜ ",
                "  ✧゜✦☆✦゜✧ ",
                "  ゜・✧✦✧・",
                " ✦゜ ✧✴✧ ゜✦",
                "  ・☆  ☆  ・",
                " ✧ ゜   ゜ ✧",
                "  ✦゜・☆・゜"
            },
            new string[]
            {
                "  ☆ ✧゜✦゜✧ ",
                " ゜・ ✴ ・",
                " ゜✧・・✧゜ ",
                " ✧゜✦✴✦゜✧ ",
                "  ✦・✧☆✧・✦ ",
                " ゜☆  ✦  ☆゜",
                " ✧✦゜・・゜✧",
                "  ゜✦  ✴  ✦",
                "   ✧・☆・✧  "
            },
            new string[]
            {
                " ゜✧✦・✦✧゜ ",
                "✦ ・☆✴☆・ ✦",
                " ✧゜  ✦  ゜✧",
                "  ・✦゜☆ ✦・",
                " ゜・ ✧✴゜ ",
                "✧✦゜・・ ✧",
                " ✦゜✧☆✧゜✦ ",
                "  ✧・  ・✧ ",
                "   ゜✦☆✦゜ "
            }
        };

        string[] selectedExplosion = explosions[random.Next(explosions.Length)];

        for (int i = 0; i < 9; i++)
        {
            Console.SetCursorPosition(pos.x + 1, pos.y + i - 6);
            selectedExplosion[i].Print(ConsoleColor.DarkRed);
        }

        yield return new WaitForSeconds(0.056f);

        string[] frame3 = new string[]
        {
            "   ・ ・  ・   ",
            "  ・   ·   ・  ",
            " ・  ・ ・  ・ ",
            "   ・  ·  ・   ",
            "    ・     ·   ",
            " ・  ・ ・  ・ ",
            "  ・  · ·  ・  ",
            "   ・  ·  ・   ",
            "  ・ ・  ・ ・ "
        };

        for (int i = 0; i < 9; i++)
        {
            Console.SetCursorPosition(pos.x, pos.y + i - 6);
            frame3[i].Print(ConsoleColor.DarkGray);
        }

        yield return new WaitForSeconds(0.059f);

        EmptyBig(7);
    }
}
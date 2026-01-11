using System;
using System.Collections;

public static partial class Draw
{
    private static Random random = new Random();

    public static void DrawEmpty(int ground)
    {
        // 배열은 y,x 순서고 커서좌표는 x,y 순서다...
        (int x, int y) pos = GetGridPosition(ground);

        if (ground >= 11)
        {
            string emptyLine = new string(' ', 11);
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(pos.x, pos.y + i);
                Console.Write(emptyLine);
            }
        }
        else
        {
            string emptyLine = new string(' ', 5);
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(pos.x, pos.y + i);
                Console.Write(emptyLine);
            }
        }
    }

    // 5x3 크기의 캐릭터
    // 전각은 2칸 , 반각은 1칸 으로 5칸 맞추기 (중요!)
    public static void DrawPlayer(int ground = 6)
    {
        (int x, int y) pos = GetGridPosition(ground);

        string[] playerArt = new string[]
        {
            "  O  ",
            "メ`⑊֎",
            " / ⑊ "
        };

        for (int i = 0; i < 3; i++)
        {
            Console.SetCursorPosition(pos.x, pos.y + i);
            playerArt[i].Print();
        }
    }

    public static void DrawDie(int ground)
    {
        Coroutine.StartCoroutine(DieAnimation(ground));
    }

    private static IEnumerator DieAnimation(int ground)
    {
        (int x, int y) pos = GetGridPosition(ground);

        string[] frame1 = new string[]
        {
        "\\ | /",
        "- ✦ -",
        "/ | \\"
        };

        for (int i = 0; i < 3; i++)
        {
            Console.SetCursorPosition(pos.x, pos.y + i);
            frame1[i].Print(ConsoleColor.Yellow);
        }

        yield return new WaitForSeconds(0.04f);

        string[][] explosions = new string[][]
        {
            new string[]
            {
                "  ✧  ",
                ".  ☆",
                "✦   ."
            },
            new string[]
            {
                "✧ . '",
                "  ☆ ",
                ".   ✦"
            },
            new string[]
            {
                "'   `",
                "  ✴ ",
                "`   '"
            }
        };

        string[] selectedExplosion = explosions[random.Next(explosions.Length)];

        for (int i = 0; i < 3; i++)
        {
            Console.SetCursorPosition(pos.x, pos.y + i);
            selectedExplosion[i].Print(ConsoleColor.White);
        }

        yield return new WaitForSeconds(0.05f);

        string[] frame3 = new string[]
        {
            "     ",
            "  .  ",
            "     "
        };

        for (int i = 0; i < 3; i++)
        {
            Console.SetCursorPosition(pos.x, pos.y + i);
            frame3[i].Print(ConsoleColor.Gray);
        }

        yield return new WaitForSeconds(0.03f);

        DrawEmpty(ground);
    }

    // 공중 몬스터 (11x3)
    public static void DrawAirMonster(int ground)
    {
        (int x, int y) pos = GetGridPosition(ground);

        string[] airMobArt = new string[]
        {
        "  /^⧵___/^⧵  ",
        " < ( o.o ) > ",
        "  V   v   V  "
        };

        for (int i = 0; i < 3; i++)
        {
            Console.SetCursorPosition(pos.x, pos.y + i);
            airMobArt[i].Print(ConsoleColor.DarkMagenta);
        }
    }

    // 칸 번호(1~13)를 받아 시작좌표를 반환
    private static (int x, int y) GetGridPosition(int ground)
    {
        if (0 < ground && ground <= 10)
        {
            int x = (ground - 1) * 5;
            int y = 9;
            return (x, y);
        }
        // 공중
        else if (11 <= ground && ground <= 13)
        {
            int x = 22;
            // 11번 부터 공중으로 유형이 바뀌니까 sky로 다시 정의
            int sky = ground - 11;
            int y = 6 - (sky * 3); // 6, 3, 0

            return (x, y);
        }

        return (0, 0);
    }
}
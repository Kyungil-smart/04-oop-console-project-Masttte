using System;
using System.Collections;

public static partial class Draw
{
    private static Random random = new Random();

    public static void Empty(int ground)
    {
        // 배열은 y,x 순서고 커서좌표는 x,y 순서다...
        (int x, int y) pos = GetGridPosition(ground);

        if (ground >= 14)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(pos.x, pos.y + i);
                Console.Write("               ");
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(pos.x, pos.y + i);
                Console.Write("     ");
            }
        }
    }
    public static void Empty12() // 왜 이런코드가 존재하는걸까? 그야...12는 특수하니까
    {
        (int x, int y) pos = GetGridPosition(12);
        for (int i = 0; i < 3; i++)
        {
            Console.SetCursorPosition(pos.x + 1, pos.y + i);
            Console.Write("     ");
        }
    }

    // 칸 번호를 받아 시작좌표를 반환
    private static (int x, int y) GetGridPosition(int ground)
    {
        if (0 < ground && ground <= 13)
        {
            int x = (ground - 1) * 5;
            int y = 9;
            return (x, y);
        }
        // 공중
        else if (14 <= ground && ground <= 16)
        {
            int x = 21;
            // 14번 부터 공중으로 유형이 바뀌니까 sky로 다시 정의
            int sky = ground - 14;
            int y = 6 - (sky * 3); // 6, 3, 0

            return (x, y);
        }

        return (0, 0);
    }
    // 5x3 크기의 캐릭터
    // 전각은 2칸 , 반각은 1칸 으로 5칸 맞추기
    public static void Player(int ground = 6)
    {
        (int x, int y) pos = GetGridPosition(ground);

        string[] Art = new string[]
        {
            "  O  ",
            "メ`⑊֎",
            " / ⑊ "
        };

        for (int i = 0; i < 3; i++)
        {
            Console.SetCursorPosition(pos.x, pos.y + i);
            Art[i].Print();
        }
    }

    // 공중 몬스터 (11x3)
    public static void BatMonster(int ground)
    {
        (int x, int y) pos = GetGridPosition(ground);

        string[] Art = new string[]
        {
        " ⎛⎝(•ᴥ•)⎠⎞",
        " ⎝(⎝   ⎠)⎠",
        "    '◡◡   "
        };

        if (ground == 15)
        {
            string[] attackArt = new string[]
            {
                "⎛ ⎝(•ᴥ•)⎠ ⎞",
                "⎝ /⎝   ⎠⧵ ⎠",
                "   `◡ V   "
            };
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(pos.x, pos.y + i);
                attackArt[i].Print(ConsoleColor.Red);
            }
        }

        else if (ground == 14)
        {
            string[] attackArt = new string[]
            {
                " ⎛⎝(⚆ⱅ⚆)⎠ ⎞",
                "⎝<⎝_  _⎠> ⎠",
                "   †◡ V "
            };

            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(pos.x, pos.y + i);
                attackArt[i].Print(ConsoleColor.DarkRed);
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(pos.x, pos.y + i);
                Art[i].Print(ConsoleColor.Magenta);
            }
        }
    }

    public static void Die(int ground)
    {
        Coroutine.StartCoroutine(DieAnimation(ground));
    }

    private static IEnumerator DieAnimation(int ground)
    {
        (int x, int y) pos = GetGridPosition(ground);

        string[] frame1 = new string[]
        {
        "⧵ | /",
        "- ✦ -",
        "/ | ⧵"
        };

        for (int i = 0; i < 3; i++)
        {
            Console.SetCursorPosition(pos.x, pos.y + i);
            frame1[i].Print(ConsoleColor.Yellow);
        }

        yield return new WaitForSeconds(0.047f);

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

        yield return new WaitForSeconds(0.056f);

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

        yield return new WaitForSeconds(0.059f);

        Empty(ground);
    }
    public static void DieAirMob()
    {
        Coroutine.StartCoroutine(DieAirMobAnimation());
    }
    private static IEnumerator DieAirMobAnimation()
    {
        (int x, int y) pos = GetGridPosition(14);

        // 프레임 1 - 충격
        string[] frame1 = new string[]
        {
        "  ⧵⧵  | /",
        " - - ✦ - -",
        "  // | ⧵⧵ "
        };
        for (int i = 0; i < 3; i++)
        {
            Console.SetCursorPosition(pos.x, pos.y + i);
            frame1[i].Print(ConsoleColor.Yellow);
        }
        yield return new WaitForSeconds(0.047f);

        // 프레임 2 - 깃털과 폭발
        string[][] explosions = new string[][]
        {
        new string[]
        {
            " ✧゜・☆゜ ",
            " ゜✦ ✴ ✦゜",
            "   ☆゜・  "
        },
        new string[]
        {
            "  ☆ ✧ . ✦ ",
            " . ゜✴゜ .",
            "  ✦ . ✧   "
        },
        new string[]
        {
            " ゜✧  ✦ ✧",
            "  . ゜✴ .",
            "  ゜   ✧ "
        }
        };

        string[] selectedExplosion = explosions[random.Next(explosions.Length)];
        for (int i = 0; i < 3; i++)
        {
            Console.SetCursorPosition(pos.x, pos.y + i);
            selectedExplosion[i].Print(ConsoleColor.Magenta);
        }
        yield return new WaitForSeconds(0.056f);

        // 프레임 3 - 떨어지는 깃털
        string[] frame3 = new string[]
        {
        " .  '  .  '",
        "   ·   ·   ",
        "  .        "
        };
        for (int i = 0; i < 3; i++)
        {
            Console.SetCursorPosition(pos.x, pos.y + i);
            frame3[i].Print(ConsoleColor.DarkGray);
        }
        yield return new WaitForSeconds(0.059f);

        Empty(14);
    }
}
using System;
using System.Collections;

public static partial class Draw
{
    public static void DrawRabbit(int ground)
    {
        (int x, int y) pos = GetGridPosition(ground);

        string[] monsterArt = new string[]
        {
            " ⧵ / ",
            "(>_<)",
            "(_n_)"//귀엽다
        };

        //플레이어와 가까울때 변화
        if (ground <= 8) // 오른쪽에서만 나오는 설계
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
                monsterArt[i].Print();
            }
        }
    }
}
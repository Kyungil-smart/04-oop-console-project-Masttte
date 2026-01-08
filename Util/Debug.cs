using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Debug
{
    public enum LogType
    {
        Normal,
        Warning,
    }

    private static List<(LogType type, string text)> LogList = new List<(LogType type, string text)>();

    public static void Log(string text)
    {
        LogList.Add((LogType.Normal, text));
    }

    public static void LogWarning(string text)
    {
        LogList.Add((LogType.Warning, text));
    }

    public static void Render()
    {
        "-------- 로그 목록\n".Print(ConsoleColor.Blue);
        foreach (var log in LogList)
        {
            if (log.type == LogType.Normal)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (log.type == LogType.Warning)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.WriteLine(log.text);
        }
        Console.ResetColor();
        "-------- Enter를 눌러 나가기".Print(ConsoleColor.Red);
    }
}


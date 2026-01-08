using System;

public static class TextExtensions
{
    public static void Print(this string text, ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;

        Console.Write(text);

        Console.ResetColor();
    }

    public static void Print(this char character, ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;

        Console.Write(character);

        Console.ResetColor();
    }
}


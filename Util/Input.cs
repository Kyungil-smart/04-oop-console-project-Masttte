using System;
using System.Collections.Generic;

public static class Input
{
    // 중복을 허용하지 않는 자료구조인 HashSet 사용
    private static HashSet<ConsoleKey> _currentFrame = new HashSet<ConsoleKey>();
    private static HashSet<ConsoleKey> _previousFrame = new HashSet<ConsoleKey>();

    public enum Key
    {
        Up, Down, Left, Right, Enter, Q, L
    }

    // GameManager에서 매 프레임 호출
    public static void Update()
    {
        _previousFrame.Clear(); // 이전프레임에 키를 없애고

        foreach (ConsoleKey keys in _currentFrame)
        {
            _previousFrame.Add(keys); // 현재프레임 키를 이전프레임으로
        }

        _currentFrame.Clear();

        while (Console.KeyAvailable) // 비동기
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            _currentFrame.Add(key); // 현재프레임에 키 새 할당
        }
    }

    // 키가 눌린 순간만 true
    public static bool KeyDown(Key Key)
    {
        ConsoleKey[] keys = GetConsoleKeys(Key);
        foreach (ConsoleKey key in keys)
        {
            // 현재 프레임에 있고, 이전 프레임에 없을때
            if (_currentFrame.Contains(key) && !_previousFrame.Contains(key))
                return true;
        }
        return false;
    }

    private static ConsoleKey[] GetConsoleKeys(Key key)
    {
        switch (key)
        {
            case Key.Up: return new[] { ConsoleKey.UpArrow, ConsoleKey.W };
            case Key.Down: return new[] { ConsoleKey.DownArrow, ConsoleKey.S };
            case Key.Left: return new[] { ConsoleKey.LeftArrow, ConsoleKey.A };
            case Key.Right: return new[] { ConsoleKey.RightArrow, ConsoleKey.D };
            case Key.Enter: return new[] { ConsoleKey.Enter };
            case Key.Q: return new[] { ConsoleKey.Q };
            case Key.L: return new[] { ConsoleKey.L };
            default: return Array.Empty<ConsoleKey>();
        }
    }

    public static void Reset()
    {
        _currentFrame.Clear();
        _previousFrame.Clear();
        Console.Clear();
    }
}
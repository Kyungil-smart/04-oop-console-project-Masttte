using System;
using System.Collections;
using System.Collections.Generic;

public static class Coroutine
{
    private static List<CoroutineInstance> _coroutines = new List<CoroutineInstance>();

    public static void StartCoroutine(IEnumerator routine)
    {
        _coroutines.Add(new CoroutineInstance(routine));
    }

    public static void Update(float deltaTime)
    {
        for (int i = _coroutines.Count - 1; i >= 0; i--)
        {
            if (_coroutines[i].Update(deltaTime))
            {
                _coroutines.RemoveAt(i);
            }
        }
    }

    public static void Clear()
    {
        _coroutines.Clear();
    }
}

public class CoroutineInstance
{
    private IEnumerator _routine;
    private object _current;

    public CoroutineInstance(IEnumerator routine)
    {
        _routine = routine;
        if (!_routine.MoveNext())
        {
            return;
        }
        _current = _routine.Current;
    }

    public bool Update(float deltaTime)
    {
        if (_current is WaitForSeconds wait)
        {
            wait.elapsed += deltaTime;
            if (wait.elapsed < wait.duration)
            {
                return false;
            }
        }

        if (!_routine.MoveNext())
        {
            return true;
        }

        _current = _routine.Current;
        return false;
    }
}

public class WaitForSeconds
{
    public float duration;
    public float elapsed;

    public WaitForSeconds(float seconds)
    {
        duration = seconds;
        elapsed = 0;
    }
}
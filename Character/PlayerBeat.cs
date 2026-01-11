using System;
using System.Collections;

public enum HitType
{
    None,
    Critical,
    Perfect,
    Good,
    Miss,
}

public class Player
{
    // 판정 타이밍
    protected const float CRIT = 0.042f;
    protected const float PERF = 0.110f;
    protected const float GOOD = 0.203f;
    protected const float MISS = 0.450f;

    public static int combo;
    public static int criticals;
    public static int perfects;
    public static int goods;

    public static Action<HitType> OnJudge;
    public static bool somethingMissed;
    public static bool IsGameOver;

    // 점수 및 콤보 처리
    protected static void ProcessHit(HitType hitType)
    {
        switch (hitType)
        {
            case HitType.Critical:
                criticals++;
                combo++;
                Audio.Play("Per01.wav");
                break;

            case HitType.Perfect:
                perfects++;
                combo++;
                Audio.Play("Per01.wav");
                break;

            case HitType.Good:
                goods++;
                combo++;
                Audio.Play("Per01.wav");
                break;

            case HitType.Miss:
                Audio.Play("Miss01.wav");
                somethingMissed = true;
                break;
        }

        OnJudge?.Invoke(hitType);
    }

    // bool을 IEnumerator에 ref로 넣을 수 없었으므로 Func 사용
    protected static IEnumerator AttackTimeOver(Func<bool> direction)
    {
        yield return new WaitForSeconds(MISS * 2f);

        if (direction()) IsGameOver = true; // 공격 안함
        if (somethingMissed) IsGameOver = true; // 놓침
    }

    // 판정 부분
    protected static HitType Judge(DateTime perfectTime)
    {
        float timeDiff = Math.Abs((float)(DateTime.Now - perfectTime).TotalSeconds);

        if (timeDiff <= CRIT) return HitType.Critical;
        else if (timeDiff <= PERF) return HitType.Perfect;
        else if (timeDiff <= GOOD) return HitType.Good;
        else if (timeDiff <= MISS) return HitType.Miss;
        else return HitType.None;
    }

    public static void Reset()
    {
        somethingMissed = false;
        IsGameOver = false;
        combo = 0;
        criticals = 0;
        perfects = 0;
        goods = 0;
    }
}


public class BeatR : Player
{
    private DateTime perfectTime; // 자식이 나눠가져서 각각 판정을 하게하는 중요한 변수
    private bool _canAttack;

    public bool CanAttack
    {
        get => _canAttack;
        set
        {
            if (value)
            {
                _canAttack = true;
                perfectTime = DateTime.Now.AddSeconds(MISS);
                Coroutine.StartCoroutine(AttackTimeOver(() => _canAttack));
            }
            else _canAttack = false;
        }
    }

    public HitType TryRightAttack()
    {
        if (!_canAttack) return HitType.None;

        HitType result = Judge(perfectTime);
        ProcessHit(result);
        if (result != HitType.Miss) Draw.DrawDie(7);

        _canAttack = false;
        return result;
    }
}

public class BeatL : Player
{
    private DateTime perfectTime;
    private bool _canAttack;

    public bool CanAttack
    {
        get => _canAttack;
        set
        {
            if (value)
            {
                _canAttack = true;
                perfectTime = DateTime.Now.AddSeconds(MISS);
                Coroutine.StartCoroutine(AttackTimeOver(() => _canAttack));
            }
            else _canAttack = false;
        }
    }

    public HitType TryLeftAttack()
    {
        if (!_canAttack) return HitType.None;

        HitType result = Judge(perfectTime);
        ProcessHit(result);
        if (result != HitType.Miss) Draw.DrawDie(5);

        _canAttack = false;
        return result;
    }
}

public class BeatU : Player
{
    private static DateTime perfectTime;
    private static bool _canAttack;

    public static bool CanAttack
    {
        get => _canAttack;
        set
        {
            if (value)
            {
                _canAttack = true;
                perfectTime = DateTime.Now.AddSeconds(MISS);
                Coroutine.StartCoroutine(AttackTimeOver(() => _canAttack));
            }
            else _canAttack = false;
        }
    }

    public static HitType TryUpAttack()
    {
        if (!_canAttack) return HitType.None;

        HitType result = Judge(perfectTime);
        ProcessHit(result);
        if (result != HitType.Miss) Draw.DrawDie(11);

        _canAttack = false;
        return result;
    }
}
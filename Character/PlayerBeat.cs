using System;
using System.Collections;

public enum HitType { None, Crit, Perf, Good, Miss }

public class Player
{
    // 판정 타이밍
    protected const float CRIT = 0.046f;
    protected const float PERF = 0.110f;
    protected const float GOOD = 0.177f;
    protected const float MISS = 0.401f;

    public static int crits;
    public static int perfs;
    public static int goods;
    public static int combo;

    public static Action<HitType> OnJudge;
    public static bool somethingMissed;
    public static bool IsGameOver;

    // 점수 및 콤보 처리
    protected static void ProcessHit(HitType hitType)
    {
        switch (hitType)
        {
            case HitType.Crit: crits++; combo++; Audio.Play("Per01.wav"); break;
            case HitType.Perf: perfs++; combo++; Audio.Play("Per01.wav"); break;
            case HitType.Good: goods++; combo++; Audio.Play("Per01.wav"); break;
            case HitType.Miss: Audio.Play("Miss01.wav"); somethingMissed = true; break;
        }
        OnJudge?.Invoke(hitType);
    }

    // bool을 IEnumerator에 ref로 넣을 수 없었으므로 Func 사용
    protected static IEnumerator AttackTimeOver(Func<bool> direction)
    {
        yield return new WaitForSeconds(MISS * 2f);

        if (direction()) IsGameOver = true; // 공격 안함
        if (somethingMissed) IsGameOver = true; // Miss 판정
    }

    // 판정 부분
    protected static HitType Judge(DateTime perfectTime)
    {
        float timeDiff = Math.Abs((float)(DateTime.Now - perfectTime).TotalSeconds);

        if (timeDiff <= CRIT) return HitType.Crit;
        else if (timeDiff <= PERF) return HitType.Perf;
        else if (timeDiff <= GOOD) return HitType.Good;
        else if (timeDiff <= MISS) return HitType.Miss;
        else return HitType.None;
    }

    public static void Reset()
    {
        somethingMissed = false;
        IsGameOver = false;
        combo = 0;
        crits = 0;
        perfs = 0;
        goods = 0;
    }
}

public abstract class Beat : Player
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

    public void TryAttack()
    {
        if (!_canAttack) return;

        HitType result = Judge(perfectTime);
        ProcessHit(result);
        if (result != HitType.Miss) Attack();

        _canAttack = false;
    }

    protected abstract void Attack();
}

public class BeatR : Beat { protected override void Attack() => Draw.Die(7); }
public class BeatR_HP : Beat { protected override void Attack() { } } // 가상의 HP 역할
public class BeatR_BigFoot : Beat { protected override void Attack() => Draw.DieBigFoot(); }
public class BeatL : Beat { protected override void Attack() => Draw.Die(5); }
public class BeatU : Beat { protected override void Attack() => Draw.DieAirMob(); }
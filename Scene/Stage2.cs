using System;
using System.Collections;

public class Stage2 : Scene
{
    int step;

    BeatR BeatR1 = new BeatR();
    BeatR BeatR2 = new BeatR();
    BeatR_HP BeatR_HP = new BeatR_HP();
    BeatR_BigFoot BeatR_BigFoot = new BeatR_BigFoot();

    BeatL BeatL1 = new BeatL();
    BeatL BeatL2 = new BeatL();

    BeatU BeatU1 = new BeatU();

    public override void Load()
    {
        step = 1;
        render = true;
    }
    public override void Unload()
    {
        Player.OnJudge -= OnBeatJudgeR;
        Player.OnJudge -= OnBeatJudgeL;
        Player.OnJudge -= OnBeatJudgeU;
    }

    public override void Update()
    {
        if (Player.IsGameOver)
        {
            SceneManager.LoadScene(new GameOver());
            return;
        }
        if (render)
        {
            Render();
            render = false;
        }

        if (Input.KeyDown(Input.Key.Right))
        {
            if (BeatR1.CanAttack)
            {
                Player.OnJudge += OnBeatJudgeR;
                BeatR1.TryAttack();
            }
            else if (BeatR2.CanAttack)
            {
                Player.OnJudge += OnBeatJudgeR;
                BeatR2.TryAttack();
            }
            else if (BeatR_HP.CanAttack)
            {
                Player.OnJudge += OnBeatJudgeR_Hit;
                BeatR_HP.TryAttack();
            }
            else if (BeatR_BigFoot.CanAttack)
            {
                Player.OnJudge += OnBeatJudgeR;
                BeatR_BigFoot.TryAttack();
            }
        }

        if (Input.KeyDown(Input.Key.Left))
        {
            if (BeatL1.CanAttack)
            {
                Player.OnJudge += OnBeatJudgeL;
                BeatL1.TryAttack();
            }
            else if (BeatL2.CanAttack)
            {
                Player.OnJudge += OnBeatJudgeL;
                BeatL2.TryAttack();
            }
        }

        if (Input.KeyDown(Input.Key.Up))
        {
            if (BeatU1.CanAttack)
            {
                Player.OnJudge += OnBeatJudgeU;
                BeatU1.TryAttack();
            }
        }
    }

    private IEnumerator Stage1_Start()
    {
        Draw.Player(6);

        yield return new WaitForSeconds(0.10f);
        Spawn.Spider(BeatR1);

        yield return new WaitForSeconds(3.19f);
        Spawn.Spider(BeatR1);
        yield return new WaitForSeconds(0.805f);
        Spawn.RabbitL(BeatL1);

        yield return new WaitForSeconds(1.50f);
        Spawn.Ghost(BeatR2);

        yield return new WaitForSeconds(0.50f);
        Spawn.Spider(BeatR1);
        yield return new WaitForSeconds(1.00f);
        Spawn.Bat(BeatU1);

        yield return new WaitForSeconds(2.40f);
        Spawn.Spider(BeatR1);
        Spawn.Slime(BeatL1);
        yield return new WaitForSeconds(0.60f);
        Spawn.Slime(BeatL2);
        yield return new WaitForSeconds(2f);

        Spawn.Spider(BeatR1);
        yield return new WaitForSeconds(0.30f);
        Spawn.Ghost(BeatR2);
        Spawn.Slime(BeatL1);
        yield return new WaitForSeconds(1f);
        Spawn.Spider(BeatR1);
        yield return new WaitForSeconds(1.4f);
        Spawn.Bat(BeatU1);

        yield return new WaitForSeconds(2f);

        Audio.Play("Riser01.wav");
        yield return new WaitForSeconds(0.10f);
        Audio.Play("Scape03.wav");
        Spawn.Knocker(BeatL1); // 겹칠시 먼저 도착하는 녀석을 앞비트에 
        Spawn.Slime(BeatL2);

        yield return new WaitForSeconds(2.9f);
        Spawn.BigFootHP(BeatR_HP);
        Spawn.BigFoot(BeatR_BigFoot);
        yield return new WaitForSeconds(1.0f);
        yield return new WaitForSeconds(2.9f);
        Spawn.Slime(BeatL1);
        Spawn.RabbitL(BeatL2);

        yield return new WaitForSeconds(2.0f);
        Spawn.Bat(BeatU1);
        Spawn.BigFootHP(BeatR_HP);
        Spawn.BigFoot(BeatR_BigFoot);
        yield return new WaitForSeconds(1.5f);
        Spawn.Knocker(BeatL1);

        yield return new WaitForSeconds(2.23f); //빅풋 3번째
        Spawn.BigFootHP(BeatR_HP);
        Spawn.BigFoot(BeatR_BigFoot);
        yield return new WaitForSeconds(1.0f);
        Spawn.Spider(BeatR1);
        yield return new WaitForSeconds(0.6f);
        Spawn.Bat(BeatU1);

        yield return new WaitForSeconds(3f);
        Spawn.Knocker(BeatL1);
        Spawn.Slime(BeatL2);
        yield return new WaitForSeconds(1.2f);
        Spawn.RabbitR(BeatR1);
        Spawn.Bat(BeatU1);

        yield return new WaitForSeconds(1.5f);
        Spawn.RabbitR(BeatR1);
        yield return new WaitForSeconds(0.25f);
        Spawn.RabbitL(BeatL1);
        yield return new WaitForSeconds(0.35f);
        Spawn.Bat(BeatU1);
        yield return new WaitForSeconds(0.15f);
        Spawn.RabbitR(BeatR2);
        yield return new WaitForSeconds(0.25f);
        Spawn.RabbitL(BeatL2);
        yield return new WaitForSeconds(0.50f);
        Spawn.RabbitR(BeatR1);
        yield return new WaitForSeconds(0.50f);
        Spawn.RabbitL(BeatL1);
        yield return new WaitForSeconds(0.50f);
        Spawn.RabbitR(BeatR1);
        yield return new WaitForSeconds(0.20f);
        Spawn.BigFootHP(BeatR_HP);
        Spawn.BigFoot(BeatR_BigFoot);
        yield return new WaitForSeconds(0.30f);
        Spawn.RabbitL(BeatL1);
        yield return new WaitForSeconds(0.90f);
        Spawn.Spider(BeatR2);
        yield return new WaitForSeconds(5.00f);
        StageClear();
    }

    private void OnBeatJudgeR(HitType hitType)
    {
        Player.OnJudge -= OnBeatJudgeR;
        Console.SetCursorPosition(28, 14);

        switch (hitType)
        {
            case HitType.Crit:
                "CRITICAL!".Print(ConsoleColor.Yellow);
                break;
            case HitType.Perf:
                " PERFECT~ ".Print(ConsoleColor.Cyan);
                break;
            case HitType.Good:
                "  GOOD~  ".Print(ConsoleColor.Blue);
                break;
            case HitType.Miss:
                "  MISS?  ".Print(ConsoleColor.Gray);
                break;
        }

        Console.SetCursorPosition(23, 17);
        $"Combo: {Player.combo}x".Print(ConsoleColor.Cyan);
    }
    private void OnBeatJudgeR_Hit(HitType hitType)
    {
        Player.OnJudge -= OnBeatJudgeR_Hit;
        Console.SetCursorPosition(28, 14);

        if (hitType == HitType.Miss)
        {
            "  MISS?  ".Print(ConsoleColor.Gray);
        }
        else
        {
            "   HIT   ".Print(ConsoleColor.DarkRed);
        }
    }

    private void OnBeatJudgeL(HitType hitType)
    {
        Player.OnJudge -= OnBeatJudgeL;
        Console.SetCursorPosition(17, 14);

        switch (hitType)
        {
            case HitType.Crit:
                "CRITICAL!".Print(ConsoleColor.Yellow);
                break;
            case HitType.Perf:
                " PERFECT~ ".Print(ConsoleColor.Cyan);
                break;
            case HitType.Good:
                "  GOOD~  ".Print(ConsoleColor.Blue);
                break;
            case HitType.Miss:
                "  MISS?  ".Print(ConsoleColor.Gray);
                break;
        }

        Console.SetCursorPosition(23, 17);
        $"Combo: {Player.combo}x".Print(ConsoleColor.Cyan);
    }

    private void OnBeatJudgeU(HitType hitType)
    {
        Player.OnJudge -= OnBeatJudgeU;
        Console.SetCursorPosition(23, 13);
        switch (hitType)
        {
            case HitType.Crit:
                "CRITICAL!".Print(ConsoleColor.Yellow);
                break;
            case HitType.Perf:
                " PERFECT~ ".Print(ConsoleColor.Cyan);
                break;
            case HitType.Good:
                "  GOOD~  ".Print(ConsoleColor.Blue);
                break;
            case HitType.Miss:
                "  MISS?  ".Print(ConsoleColor.Gray);
                break;
        }
        Console.SetCursorPosition(23, 17);
        $"Combo: {Player.combo}x".Print(ConsoleColor.Cyan);
    }

    private void Render()
    {
        switch (step)
        {
            case 1:
                Coroutine.StartCoroutine(Stage1_Start());
                break;
            case 2:
                StageClear();
                break;
            default:
                break;
        }
    }

    private void StageClear()
    {
        Console.Clear();
        Console.SetCursorPosition(14, 3);
        "폴리 리듬 던전을 클리어 하였습니다!!!".Print(ConsoleColor.DarkRed);
        Console.SetCursorPosition(7, 6);
        "결과".Print(ConsoleColor.Gray);
        Console.SetCursorPosition(7, 7);
        $"CRIT: {Player.crits}".Print(ConsoleColor.Yellow);
        Console.SetCursorPosition(7, 8);
        $"PERF: {Player.perfs}".Print(ConsoleColor.Cyan);
        Console.SetCursorPosition(7, 9);
        $"GOOD: {Player.goods}".Print(ConsoleColor.Blue);
        Console.SetCursorPosition(7, 12);
        "Q 를 눌러 나가기...".Print(ConsoleColor.Gray);
        Debug.LogResult($"stage2 결과: CRIT: {Player.crits}, PERF: {Player.perfs}, GOOD: {Player.goods}");
    }
}

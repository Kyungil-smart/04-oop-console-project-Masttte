using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Stage1 : Scene
{
    int step;

    BeatR BeatR1 = new BeatR(); BeatR BeatR3 = new BeatR();
    BeatR BeatR2 = new BeatR();

    BeatL BeatL1 = new BeatL();
    BeatL BeatL2 = new BeatL();

    public override void Load()
    {
        Audio.Play("Scape01.wav");
        step = 1;
        render = true;
    }
    public override void Unload()
    {
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

        if (Input.KeyDown(Input.Key.Right)) // 크아아 하드코딩 느낌이잖아~~ 바꾸다가 버그가 많아서 일단 보류
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
            else if (BeatR3.CanAttack)
            {
                Player.OnJudge += OnBeatJudgeR;
                BeatR3.TryAttack();
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
    }

    private IEnumerator Stage1_Start()
    {
        Draw.Player(6);
        yield return new WaitForSeconds(1.8f);
        Draw.Door(11);
        Audio.Play("DoorApear.wav");
        yield return new WaitForSeconds(2.6f);

        Spawn.Knocker(BeatL1);
        yield return new WaitForSeconds(2.6f);
        Spawn.Knocker(BeatL1);
        yield return new WaitForSeconds(2.6f);
        Spawn.Ghost(BeatR1);
        yield return new WaitForSeconds(2.6f);
        Audio.Play("Scape02.wav");
        yield return new WaitForSeconds(2.0f);
        Spawn.Knocker(BeatL1);
        Spawn.Ghost(BeatR1);
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
                " PERFECT! ".Print(ConsoleColor.Cyan);
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
                " PERFECT! ".Print(ConsoleColor.Cyan);
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
                //StageClear();
                break;
            default:
                break;
        }
    }
}

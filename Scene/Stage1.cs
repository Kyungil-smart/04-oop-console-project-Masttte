using System;
using System.Collections;

public class Stage1 : Scene
{
    int step;

    public override void Load()
    {
        step = 1;
        Audio.Play("Scape01.wav");
        Player.Reset();
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
        // 공격
        if (Input.KeyDown(Input.Key.Left) && BeatL.CanAttack)
        {
            Player.OnJudge += OnBeatJudgeL;
            BeatL.TryLeftAttack();
        }
        if (Input.KeyDown(Input.Key.Right) && BeatR.CanAttack)
        {
            Player.OnJudge += OnBeatJudgeR;
            BeatR.TryRightAttack();
        }
    }

    private IEnumerator Stage1_Start()
    {
        Draw.DrawPlayer(6);
        Spawn.SpawnRabbit();
        yield return new WaitForSeconds(1.0f);
        Spawn.SpawnSlime();
        yield return new WaitForSeconds(1.0f);
        Spawn.SpawnRabbit();
        yield return new WaitForSeconds(1.0f);
        Spawn.SpawnSlime();
    }

    private void OnBeatJudgeR(HitType hitType)
    {
        Player.OnJudge -= OnBeatJudgeR;
        Console.SetCursorPosition(28, 14);

        switch (hitType)
        {
            case HitType.Critical:
                "CRITICAL!".Print(ConsoleColor.Yellow);
                break;
            case HitType.Perfect:
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
            case HitType.Critical:
                "CRITICAL!".Print(ConsoleColor.Yellow);
                break;
            case HitType.Perfect:
                " PERFECT! ".Print(ConsoleColor.Green);
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

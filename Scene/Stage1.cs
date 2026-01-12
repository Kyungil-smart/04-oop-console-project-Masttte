using System;
using System.Collections;

public class Stage1 : Scene
{
    int step;

    BeatR BeatR1 = new BeatR();
    BeatR BeatR2 = new BeatR();

    BeatL BeatL1 = new BeatL();
    BeatL BeatL2 = new BeatL();

    BeatU BeatU1 = new BeatU();

    public override void Load()
    {
        Audio.Play("Scape01.wav");
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

        if (Input.KeyDown(Input.Key.Enter) && step == 2)
            SceneManager.LoadScene(new Stage2());
    }

    private IEnumerator Stage1_Start()
    {
        Draw.Player(6);
        yield return new WaitForSeconds(0.65f);
        Spawn.Slime(BeatL1);
        yield return new WaitForSeconds(1.3f);
        Draw.Door(11);
        Audio.Play("Door01.wav");
        yield return new WaitForSeconds(2.6f);

        Spawn.Knocker(BeatL1);
        yield return new WaitForSeconds(2.6f);
        Spawn.Knocker(BeatL1);
        yield return new WaitForSeconds(2.2f);
        Spawn.Ghost(BeatR1);
        yield return new WaitForSeconds(2.5f);

        Audio.Play("Scape02.wav");
        yield return new WaitForSeconds(1.3f);
        Spawn.Knocker(BeatL1);
        yield return new WaitForSeconds(1.5f);
        Spawn.Ghost(BeatR1);
        yield return new WaitForSeconds(1.0f);
        Spawn.Knocker(BeatL1);
        yield return new WaitForSeconds(1.6f);
        Spawn.Ghost(BeatR1);
        yield return new WaitForSeconds(1.0f);
        Spawn.Knocker(BeatL2);
        yield return new WaitForSeconds(0.75f);
        Spawn.Ghost(BeatR2);
        yield return new WaitForSeconds(0.75f);
        Spawn.Knocker(BeatL1);

        yield return new WaitForSeconds(2.3f);
        Audio.Play("Scape01.wav");
        Spawn.RabbitR(BeatR1); // 마치 리듬 처럼
        yield return new WaitForSeconds(1.00f);
        Spawn.Knocker(BeatL2);
        yield return new WaitForSeconds(0.50f);
        Spawn.RabbitR(BeatR1);
        Spawn.Ghost(BeatR2);
        yield return new WaitForSeconds(1.5f);
        Spawn.Knocker(BeatL1);
        Spawn.RabbitR(BeatR1);
        yield return new WaitForSeconds(1.49f);
        Audio.Play("Scape02.wav");
        Spawn.RabbitL(BeatL1);
        yield return new WaitForSeconds(0.75f);
        Spawn.Slime(BeatL2);
        yield return new WaitForSeconds(0.25f);
        Spawn.Ghost(BeatR2);
        yield return new WaitForSeconds(0.50f);
        Spawn.RabbitL(BeatL1);
        yield return new WaitForSeconds(1.0f);
        Spawn.Knocker(BeatL2);

        yield return new WaitForSeconds(2.9f);
        Spawn.Bat(BeatU1);
        yield return new WaitForSeconds(2.3f);
        Audio.Play("Scape02.wav");
        Spawn.RabbitR(BeatR1);
        yield return new WaitForSeconds(0.3f);
        Spawn.Slime(BeatL1);
        yield return new WaitForSeconds(1.3f);
        Spawn.Ghost(BeatR1);
        Spawn.Knocker(BeatL1);
        yield return new WaitForSeconds(0.65f);
        Spawn.RabbitL(BeatL2);
        yield return new WaitForSeconds(1.3f);
        Spawn.Bat(BeatU1);
        Spawn.Ghost(BeatR1);
        Spawn.RabbitR(BeatR2);
        yield return new WaitForSeconds(3.25f);
        Audio.Play("Door02.wav");
        yield return new WaitForSeconds(0.05f);
        Draw.DoorOpening(11);
        yield return new WaitForSeconds(1.5f);

        Coroutine.StartCoroutine(EnterDoor());
        yield return new WaitForSeconds(5.30f);
        step++;
        render = true;
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
        Console.SetCursorPosition(23, 17);

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

    // 문 입장 연출
    private IEnumerator EnterDoor()
    {
        Draw.Empty(6); Draw.Player(7);
        Audio.Play("Dust01.wav");
        yield return new WaitForSeconds(1.65f);
        Draw.Empty(7); Draw.Player(8);
        Audio.Play("Dust01.wav");
        yield return new WaitForSeconds(0.65f);
        Draw.Empty(8); Draw.Player(9);
        Audio.Play("Dust01.wav");
        yield return new WaitForSeconds(0.65f);
        Draw.Empty(9); Draw.Player(10);
        Audio.Play("Dust01.wav");
        yield return new WaitForSeconds(0.65f);
        Draw.Empty(10);
        yield return new WaitForSeconds(0.65f);
        Console.Clear();
    }

    private void StageClear()
    {
        Console.Clear();
        Console.SetCursorPosition(14, 3);
        "스테이지 클리어. 던전 깊숙한곳에 도전해 보세요".Print(ConsoleColor.Yellow);
        Console.SetCursorPosition(7, 6);
        "결과".Print(ConsoleColor.Gray);
        Console.SetCursorPosition(7, 7);
        $"CRIT: {Player.crits}".Print(ConsoleColor.Yellow);
        Console.SetCursorPosition(7, 8);
        $"PERF: {Player.perfs}".Print(ConsoleColor.Cyan);
        Console.SetCursorPosition(7, 9);
        $"GOOD: {Player.goods}".Print(ConsoleColor.Blue);
        Console.SetCursorPosition(7, 12);
        "Enter = 다음 스테이지로\n       Q = 나가기".Print(ConsoleColor.Gray);
        Debug.LogResult($"stage1 결과: CRIT: {Player.crits}, PERF: {Player.perfs}, GOOD: {Player.goods}");
    }
}

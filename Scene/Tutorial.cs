using System;
using System.Collections;

public class Tutorial : Scene
{
    int step;

    BeatR BeatR1 = new BeatR();
    BeatR BeatR2 = new BeatR();

    BeatL BeatL1 = new BeatL();
    BeatL BeatL2 = new BeatL();

    public override void Load()
    {
        step = 0;
        Audio.Play("UI02.wav");
        Player.Reset();
        TextIntro();
    }

    public override void Unload()
    {
    }

    public override void Update()
    {
        if (Player.IsGameOver && step > 0)
        {
            step = -1;
            Fail();
            return;
        }

        if (render)
        {
            Render();
            render = false;
        }


        if (Input.KeyDown(Input.Key.Enter) && step == 0)
        {
            Console.Clear();
            step++;
            render = true;
        }

        // 공격
        if (Input.KeyDown(Input.Key.Left))
        {
            if (BeatL1.CanAttack)
            {
                Player.OnJudge += OnBeatJudgeL;
                BeatL1.TryLeftAttack();
            }
            else if (BeatL2.CanAttack)
            {
                Player.OnJudge += OnBeatJudgeL;
                BeatL2.TryLeftAttack();
            }
        }

        if (Input.KeyDown(Input.Key.Right))
        {
            if (BeatR1.CanAttack)
            {
                Player.OnJudge += OnBeatJudgeR;
                BeatR1.TryRightAttack();
            }
            else if (BeatR2.CanAttack)
            {
                Player.OnJudge += OnBeatJudgeR;
                BeatR2.TryRightAttack();
            }
        }

        if (Input.KeyDown(Input.Key.Enter) && step == 2)
            SceneManager.LoadScene(new Stages());
    }

    private void Render()
    {
        switch (step)
        {
            case 1:
                Coroutine.StartCoroutine(TutorialSequence());
                break;
            case 2:
                StageClear();
                break;

            default:
                break;
        }
    }

    private IEnumerator TutorialSequence()
    {
        Draw.DrawPlayer(6);
        Console.SetCursorPosition(31, 12);
        "⇑⇑⇑".Print(ConsoleColor.Yellow);
        Console.SetCursorPosition(12, 13);
        "         4박자 토끼가 접근합니다!".Print();

        yield return new WaitForSeconds(1.0f);

        Spawn.SpawnRabbit(BeatR2);

        yield return new WaitForSeconds(1.0f);
        Console.SetCursorPosition(10, 13);
        "                                        ".Print();
        yield return new WaitForSeconds(2.0f);

        Spawn.SpawnRabbit(BeatR1);

        yield return new WaitForSeconds(2f);

        Spawn.SpawnRabbit(BeatR1);
        yield return new WaitForSeconds(0.505f);
        Spawn.SpawnRabbit(BeatR2);

        yield return new WaitForSeconds(1.5f);

        Console.SetCursorPosition(21, 12);
        "⇑⇑⇑".Print(ConsoleColor.Yellow);
        Console.SetCursorPosition(9, 13);
        "5박자 슬라임이 접근합니다!".Print();

        yield return new WaitForSeconds(1.5f);
        Console.SetCursorPosition(9, 13);
        "                                        ".Print();
        yield return new WaitForSeconds(0.5f);

        Spawn.SpawnSlime(BeatL1);

        yield return new WaitForSeconds(3.0f);

        Spawn.SpawnSlime(BeatL1);

        yield return new WaitForSeconds(2f);
        Console.SetCursorPosition(10, 13);
        "양방향에서 오는 폴리리듬을 준비하세요".Print();

        yield return new WaitForSeconds(3.0f);
        Spawn.SpawnSlime(BeatL1);
        Spawn.SpawnRabbit(BeatR1);

        yield return new WaitForSeconds(2.5f);
        Spawn.SpawnSlime(BeatL1);
        Spawn.SpawnRabbit(BeatR1);

        yield return new WaitForSeconds(0.5f);
        Spawn.SpawnSlime(BeatL2);

        yield return new WaitForSeconds(2.0f);
        step++;
        render = true;
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

    private void TextIntro()
    {
        Console.Clear();
        Console.SetCursorPosition(14, 2);
        "폴리 리듬 던전에 오신것을 환영합니다!".Print(ConsoleColor.Yellow);
        Console.SetCursorPosition(7, 4);
        "리듬에 맞춰 가까이 오는 몬스터를 물리치는 게임입니다".Print(ConsoleColor.Red);
        Console.SetCursorPosition(7, 7);
        "몬스터 마다 고유의 리듬을 가집니다".Print();
        Console.SetCursorPosition(7, 8);
        "이 리듬은 엇박이 될수도 있습니다".Print();
        Console.SetCursorPosition(7, 9);
        "이것을 폴리리듬이라고 합니다".Print();
        Console.SetCursorPosition(14, 11);
        "=== 조작법 ===".Print(ConsoleColor.Yellow);
        Console.SetCursorPosition(7, 13);
        "A 키: 왼쪽 공격!".Print(ConsoleColor.Cyan);
        Console.SetCursorPosition(7, 14);
        "D 키: 오른쪽 공격!".Print(ConsoleColor.Cyan);
        Console.SetCursorPosition(7, 15);
        "방향키도 조작 가능합니다".Print(ConsoleColor.Gray);
        Console.SetCursorPosition(7, 18);
        "쉬운 난이도를 연습해보세요!".Print();
        Console.SetCursorPosition(7, 20);
        "소리를 듣고 화면을 보며 타이밍에 맞춰 물리칩시다!".Print(ConsoleColor.Cyan);
        Console.SetCursorPosition(7, 21);
        "Enter를 눌러 시작...".Print(ConsoleColor.Gray);
    }

    private void StageClear()
    {
        Console.Clear();
        Console.SetCursorPosition(14, 3);
        "튜토리얼 클리어!!!".Print(ConsoleColor.Yellow);
        Console.SetCursorPosition(7, 6);
        "결과".Print(ConsoleColor.Gray);
        Console.SetCursorPosition(7, 7);
        $"CRIT: {Player.criticals}".Print(ConsoleColor.Yellow);
        Console.SetCursorPosition(7, 8);
        $"PERF: {Player.perfects}".Print(ConsoleColor.Cyan);
        Console.SetCursorPosition(7, 9);
        $"GOOD: {Player.goods}".Print(ConsoleColor.Blue);
        Console.SetCursorPosition(7, 12);
        "Enter를 눌러 나가기...".Print(ConsoleColor.Gray);
        Debug.Log($"튜토리얼 결과: CRIT: {Player.criticals}, PERF: {Player.perfects}, GOOD: {Player.goods}");
    }
    private void Fail()
    {
        Debug.LogFatal("허걱스..튜토리얼 실패?! 유저의 실력에 에러 발생!!");

        SceneManager.LoadScene(new GameOver());
    }

}
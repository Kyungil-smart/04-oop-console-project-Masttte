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
        Draw.Player(6);
        Console.SetCursorPosition(31, 12);
        "⇑⇑⇑".Print(ConsoleColor.Yellow);
        Console.SetCursorPosition(12, 13);
        "         4박자 토끼가 접근합니다!".Print();

        yield return new WaitForSeconds(1.0f);

        Spawn.RabbitR(BeatR2);

        yield return new WaitForSeconds(2.0f);
        Console.SetCursorPosition(10, 13);
        "                                        ".Print();
        yield return new WaitForSeconds(1.0f);

        Spawn.RabbitR(BeatR1);

        yield return new WaitForSeconds(2.0f);
        Console.SetCursorPosition(21, 12);
        "⇑⇑⇑".Print(ConsoleColor.Yellow);
        Spawn.RabbitL(BeatL1);

        yield return new WaitForSeconds(2.0f);
        Spawn.RabbitR(BeatR1);

        yield return new WaitForSeconds(1.5f);

        Console.SetCursorPosition(9, 13);
        "5박자 슬라임이 접근합니다!".Print();

        yield return new WaitForSeconds(1.5f);
        Console.SetCursorPosition(9, 13);
        "                                        ".Print();
        yield return new WaitForSeconds(0.5f);

        Spawn.Slime(BeatL1);

        yield return new WaitForSeconds(3.0f);

        Spawn.Slime(BeatL1);

        yield return new WaitForSeconds(2f);
        Console.SetCursorPosition(10, 13);
        "양방향에서 오는 폴리리듬을 준비하세요".Print();

        yield return new WaitForSeconds(3.0f);
        Spawn.Slime(BeatL1);
        Spawn.RabbitR(BeatR1);

        yield return new WaitForSeconds(2.5f);
        Spawn.Slime(BeatL1);
        Spawn.RabbitR(BeatR1);

        yield return new WaitForSeconds(0.5f);
        Spawn.Slime(BeatL2);

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

    private void TextIntro()
    {
        Console.Clear();
        Console.SetCursorPosition(14, 2);
        "환영합니다!".Print(ConsoleColor.Yellow);
        Console.SetCursorPosition(7, 5);
        "리듬에 맞춰 몬스터가 다가오는 타이밍을 정확히 맞추세요!!!".Print(ConsoleColor.Red);
        Console.SetCursorPosition(7, 8);
        "몬스터 마다 고유의 리듬을 가집니다".Print();
        Console.SetCursorPosition(7, 9);
        "각각의 리듬은 엇박이 될수도 있습니다".Print();
        Console.SetCursorPosition(7, 10);
        "이것을 폴리리듬이라고 합니다".Print();
        Console.SetCursorPosition(14, 13);
        "=== 조작법 ===".Print(ConsoleColor.Yellow);
        Console.SetCursorPosition(7, 15);
        "A 키: 왼쪽 공격!".Print(ConsoleColor.Cyan);
        Console.SetCursorPosition(7, 16);
        "D 키: 오른쪽 공격!".Print(ConsoleColor.Cyan);
        Console.SetCursorPosition(7, 17);
        "방향키 조작 가능합니다".Print(ConsoleColor.Gray);
        Console.SetCursorPosition(7, 21);
        "소리를 듣고 화면을 보며 타이밍에 맞춰 물리칩시다!".Print(ConsoleColor.Cyan);
        Console.SetCursorPosition(7, 22);
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
        $"CRIT: {Player.crits}".Print(ConsoleColor.Yellow);
        Console.SetCursorPosition(7, 8);
        $"PERF: {Player.perfs}".Print(ConsoleColor.Cyan);
        Console.SetCursorPosition(7, 9);
        $"GOOD: {Player.goods}".Print(ConsoleColor.Blue);
        Console.SetCursorPosition(7, 12);
        "Enter를 눌러 나가기...".Print(ConsoleColor.Gray);
        Debug.Log($"튜토리얼 결과: CRIT: {Player.crits}, PERF: {Player.perfs}, GOOD: {Player.goods}");
    }
    private void Fail()
    {
        Debug.LogFatal("허걱스..튜토리얼 실패?! 유저의 실력에 에러 발생!!");

        SceneManager.LoadScene(new GameOver());
    }

}
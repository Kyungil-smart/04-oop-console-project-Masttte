using System;
using System.Collections;
public static partial class Spawn
{
    public static void RabbitL(BeatL beatL)
    {
        Coroutine.StartCoroutine(RabbitRoutineL(beatL));
    }
    private static IEnumerator RabbitRoutineL(BeatL beatL)
    {
        Draw.Rabbit(2);
        Audio.Play("Kick01.wav");
        yield return new WaitForSeconds(0.5f);

        Draw.Empty(2); Draw.Rabbit(3);
        Audio.Play("Kick01.wav");
        yield return new WaitForSeconds(0.5f);

        Draw.Empty(3); Draw.Rabbit(4);
        Audio.Play("Kick01.wav");
        yield return new WaitForSeconds(0.1f);
        beatL.CanAttack = true; // 판정 시작
        yield return new WaitForSeconds(0.4f);
        Draw.Empty(4); Draw.Rabbit(5);
        Audio.Play("Kick01.wav");
    }

    // 박쥐 1.4 초에 3박자
    public static void Bat(BeatU beatU)
    {
        Coroutine.StartCoroutine(AirEnemyRoutine(beatU));
    }

    private static IEnumerator AirEnemyRoutine(BeatU beatU)
    {
        Draw.BatMonster(-1);
        Audio.Play("TH01.wav");
        yield return new WaitForSeconds(0.7f);
        Draw.Empty(-1); Draw.BatMonster(-2);
        Audio.Play("TH02.wav");
        yield return new WaitForSeconds(0.3f);
        beatU.CanAttack = true; // 판정 시작
        yield return new WaitForSeconds(0.4f);
        Audio.Play("TH02.wav");
        Draw.Empty(-2); Draw.BatMonster(-3);
    }

    //빅풋 약 2.3 초에 2박자특수
    public static void BigFoot(BeatR_BigFoot beatR_BigFoot)
    {
        Coroutine.StartCoroutine(BigFootRoutine(beatR_BigFoot));
    }
    private static IEnumerator BigFootRoutine(BeatR_BigFoot beatR_BigFoot)
    {
        Draw.BigFoot(10);
        Audio.Play("BigFoot01.wav");
        yield return new WaitForSeconds(0.23f);
        Draw.EmptyBig(10); Draw.BigFoot(9);
        yield return new WaitForSeconds(1.77f);
        beatR_BigFoot.CanAttack = true;
        Draw.EmptyBig(9); Draw.BigFoot(8);
        Audio.Play("BigFoot01.wav");
        yield return new WaitForSeconds(0.26f);
        Draw.EmptyBig(8); Draw.BigFoot(7);
    }

    // 빅풋 HP 스폰
    public static void BigFootHP(BeatR_HP beatR_HP)
    {
        Coroutine.StartCoroutine(BigFootHPRoutine(beatR_HP));
    }
    private static IEnumerator BigFootHPRoutine(BeatR_HP beatR_HP)
    {
        yield return new WaitForSeconds(1.795f);
        beatR_HP.CanAttack = true;
    }

    // 스파이더는 매우 특수한 박자
    public static void Spider(BeatR beatR)
    {
        Coroutine.StartCoroutine(SpiderRoutine(beatR));
        Coroutine.StartCoroutine(Draw.SpiderFastMoving(23));
    }
    private static IEnumerator SpiderRoutine(BeatR beatR)
    {
        Audio.Play("LogBeat01.wav");

        yield return new WaitForSeconds(1.284f);
        Draw.Empty(12); Draw.Spider(11);

        yield return new WaitForSeconds(0.221f);
        Draw.Empty(11); Draw.Spider(10);

        yield return new WaitForSeconds(0.199f);
        Draw.Empty(10); Draw.Spider(9);

        yield return new WaitForSeconds(0.126f);
        beatR.CanAttack = true;
        yield return new WaitForSeconds(0.130f);
        Draw.Empty(9); Draw.Spider(8);

        yield return new WaitForSeconds(0.274f);
        Draw.Empty(8); Draw.Spider(7);
    }

    
}
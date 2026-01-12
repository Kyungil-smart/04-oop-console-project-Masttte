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
        Draw.BatMonster(16);
        Audio.Play("TH01.wav");
        yield return new WaitForSeconds(0.7f);
        Draw.Empty(16); Draw.BatMonster(15);
        Audio.Play("TH02.wav");
        yield return new WaitForSeconds(0.3f);
        beatU.CanAttack = true; // 판정 시작
        yield return new WaitForSeconds(0.4f);
        Audio.Play("TH02.wav");
        Draw.Empty(15); Draw.BatMonster(14);
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
}
using System;
using System.Collections;
public static partial class Spawn
{
    // 토끼는 1.5 초에 4박자인 리듬
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

    // 공중몹 스폰
    public static void AirEnemy(BeatU beatU)
    {
        Coroutine.StartCoroutine(AirEnemyRoutine(beatU));
    }

    private static IEnumerator AirEnemyRoutine(BeatU beatU)
    {
        Draw.AirMonster(16);
        Audio.Play("dust01.wav");
        yield return new WaitForSeconds(0.7f);
        Draw.Empty(16); Draw.AirMonster(15);
        Audio.Play("dust01.wav");
        yield return new WaitForSeconds(0.3f);
        beatU.CanAttack = true; // 판정 시작
        yield return new WaitForSeconds(0.4f);
        Audio.Play("dust01.wav");
        Draw.Empty(15); Draw.AirMonster(14);
    }
}
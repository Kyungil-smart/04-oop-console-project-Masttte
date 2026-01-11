using System;
using System.Collections;

public static partial class Spawn
{
    // 토끼는 1.5 초에 4박자인 리듬
    public static void RabbitR(BeatR beatR)
    {
        Coroutine.StartCoroutine(RabbitRoutineR(beatR));
    }
    private static IEnumerator RabbitRoutineR(BeatR beatR)
    {
        Draw.Rabbit(10);
        Audio.Play("Kick01.wav");
        yield return new WaitForSeconds(0.5f);

        Draw.Empty(10); Draw.Rabbit(9);
        Audio.Play("Kick01.wav");
        yield return new WaitForSeconds(0.5f);

        Draw.Empty(9); Draw.Rabbit(8);
        Audio.Play("Kick01.wav");
        yield return new WaitForSeconds(0.1f);
        beatR.CanAttack = true; // 판정 시작
        yield return new WaitForSeconds(0.4f);
        Draw.Empty(8); Draw.Rabbit(7);
        Audio.Play("Kick01.wav");
    }

    // 슬라임은 1.2초에 5박자인 리듬
    public static void Slime(BeatL beatL)
    {
        Coroutine.StartCoroutine(SlimeRoutine(beatL));
    }
    private static IEnumerator SlimeRoutine(BeatL beatL)
    {
        Draw.Slime(1);
        Audio.Play("Water01.wav");
        yield return new WaitForSeconds(0.3f);

        Draw.Empty(1); Draw.Slime(2);
        Audio.Play("Water01.wav");
        yield return new WaitForSeconds(0.3f);

        Draw.Empty(2); Draw.Slime(3);
        Audio.Play("Water01.wav");
        yield return new WaitForSeconds(0.2f);
        beatL.CanAttack = true;
        yield return new WaitForSeconds(0.1f);

        Draw.Empty(3); Draw.Slime(4);
        Audio.Play("Water01.wav");
        yield return new WaitForSeconds(0.3f);

        Draw.Empty(4); Draw.Slime(5);
        Audio.Play("Water02.wav");
    }

    // 노커는 1초에 5박자인 리듬
    public static void Knocker(BeatL beatL)
    {
        Coroutine.StartCoroutine(KnockerRoutine(beatL));
    }

    private static IEnumerator KnockerRoutine(BeatL beatL)
    {
        Draw.Knocker(1);
        Audio.Play("Knocks01.wav");
        yield return new WaitForSeconds(0.125f);
        Draw.Empty(1); Draw.Knocker(2);
        yield return new WaitForSeconds(0.375f);
        Draw.Empty(2); Draw.Knocker(3);
        yield return new WaitForSeconds(0.10f);
        beatL.CanAttack = true;
        yield return new WaitForSeconds(0.15f);
        Draw.Empty(3); Draw.Knocker(4);
        yield return new WaitForSeconds(0.25f);
        Draw.Empty(4); Draw.Knocker(5);
    }

    // 유령은 2초에 7박자인 리듬
    public static void Ghost(BeatR beatR)
    {
        Coroutine.StartCoroutine(GhostRoutine(beatR));
    }
    private static IEnumerator GhostRoutine(BeatR beatR)
    {
        Draw.Ghost(13);
        Audio.Play("Bell01.wav");
        yield return new WaitForSeconds(1f / 3f);
        Draw.Empty(13); Draw.Ghost(12);
        Audio.Play("Bell01.wav");
        yield return new WaitForSeconds(1f / 3f);
        Draw.Empty12();
        yield return new WaitForSeconds(1f / 3f);
        // 1박자 쉬기
        Draw.Ghost(10);
        Audio.Play("Bell01.wav");
        yield return new WaitForSeconds(1f / 3f);
        Draw.Empty(10); Draw.Ghost(9);
        Audio.Play("Bell01.wav");
        yield return new WaitForSeconds(4f / 15f);
        beatR.CanAttack = true;
        yield return new WaitForSeconds(1f / 15f);

        Draw.Empty(9); Draw.Ghost(8);
        Audio.Play("Bell01.wav");
        yield return new WaitForSeconds(1f / 3f);
        Draw.Empty(8); Draw.Ghost(7);
        Audio.Play("Bell02.wav");
    }
}

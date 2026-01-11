using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Spawn
{
    public static void SpawnRabbit(BeatR beatR)
    {
        Coroutine.StartCoroutine(RabbitRoutine(beatR));
    }
    private static IEnumerator RabbitRoutine(BeatR beatR)
    {
        // 1
        Draw.DrawRabbit(10);
        Audio.Play("Kick01.wav");

        yield return new WaitForSeconds(0.5f);

        // 2
        Draw.DrawEmpty(10);
        Draw.DrawRabbit(9);
        Audio.Play("Kick01.wav");

        yield return new WaitForSeconds(0.5f);

        // 3
        Draw.DrawEmpty(9);
        Draw.DrawRabbit(8);
        Audio.Play("Kick01.wav");

        yield return new WaitForSeconds(0.1f);

        beatR.CanAttack = true; // 판정 시작

        yield return new WaitForSeconds(0.4f);

        // 4
        Draw.DrawEmpty(8);
        Draw.DrawRabbit(7);
        Audio.Play("Kick01.wav");
    }

    public static void SpawnSlime(BeatL beatL)
    {
        Coroutine.StartCoroutine(SlimeRoutine(beatL));
    }
    private static IEnumerator SlimeRoutine(BeatL beatL)
    {
        Draw.DrawSlime(1);
        Audio.Play("Water01.wav");
        yield return new WaitForSeconds(0.3f);

        Draw.DrawEmpty(1);
        Draw.DrawSlime(2);
        Audio.Play("Water01.wav");
        yield return new WaitForSeconds(0.3f);

        Draw.DrawEmpty(2);
        Draw.DrawSlime(3);
        Audio.Play("Water01.wav");
        yield return new WaitForSeconds(0.2f);

        beatL.CanAttack = true;

        yield return new WaitForSeconds(0.1f);

        Draw.DrawEmpty(3);
        Draw.DrawSlime(4);
        Audio.Play("Water01.wav");
        yield return new WaitForSeconds(0.3f);

        Draw.DrawEmpty(4);
        Draw.DrawSlime(5);
        Audio.Play("Water02.wav");
    }
}

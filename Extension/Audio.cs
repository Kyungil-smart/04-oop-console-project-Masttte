using System;
using System.Runtime.InteropServices;

public static class Audio
{
    // 동시 재생을 위한 Windows API
    [DllImport("winmm.dll")]
    private static extern int mciSendString(string command, string buffer, int bufferSize, IntPtr callback);

    private static int audioCounter = 0;
    private const int maxAudioCounter = 31;

    public static void Play(string filePath)
    {
        string alias = "sound" + (audioCounter % maxAudioCounter); // 별명 번호 등록 하고
        audioCounter++;

        mciSendString($"close {alias}", null, 0, IntPtr.Zero); // 이미 오픈돼있으면 닫기 (메모리 누수 방지)

        mciSendString($"open \"{filePath}\" type waveaudio alias {alias}", null, 0, IntPtr.Zero);
        mciSendString($"play {alias}", null, 0, IntPtr.Zero);
    }

    public static void StopAll()
    {
        mciSendString("close all", null, 0, IntPtr.Zero);
    }
}
using System;
using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.CursorVisible = false;

        GameManager.Start();
    }
}

public static class GameManager
{
    public static string GameTitle = "POLY RHYTHM DUNGEON";

    public static void Start()
    {
        Title titleScene = new Title();
        LogScene logScene = new LogScene();
        SceneManager.LoadScene(titleScene);

        DateTime lastUpdate = DateTime.Now;

        while (true)
        {
            DateTime now = DateTime.Now;
            float deltaTime = (float)(now - lastUpdate).TotalSeconds;
            lastUpdate = now;

            Input.Update();
            Coroutine.Update(deltaTime);
            SceneManager.Update();

            if (Input.KeyDown(Input.Key.Q)) SceneManager.LoadPrevScene(); // 뒤로가기

            if (Input.KeyDown(Input.Key.L) && SceneManager._current != logScene) 
                SceneManager.LoadScene(logScene); // 디버그 용

            System.Threading.Thread.Sleep(13);  // 75 FPS
        }
    }
}
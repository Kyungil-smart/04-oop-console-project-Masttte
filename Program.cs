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

        while (true)
        {
            Input.Update();
            
            SceneManager.Update();

            // 뒤로가기
            if (Input.KeyDown(Input.Key.Q)) SceneManager.LoadPrevScene();

            // 로그씬 (디버그용)
            if (Input.KeyDown(Input.Key.L) && SceneManager._current != logScene) 
                SceneManager.LoadScene(logScene);

            System.Threading.Thread.Sleep(16);  // 60 FPS
        }
    }
}
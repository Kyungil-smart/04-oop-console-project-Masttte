using System;

public class GameOver : Scene
{
    public static int stage;
    public override void Load()
    {
        Audio.Play("gore01.wav");
        Render();

        if (SceneManager._prev is Tutorial)
        {
            stage = 0;
        }
        else if (SceneManager._prev is Stage1)
        {
            stage = 1;
        }
        else if (SceneManager._prev is Stage2)
        {
            stage = 2;
        }
    }
    public override void Unload()
    {

    }

    public override void Update()
    {
        if (Input.KeyDown(Input.Key.Enter))
        {
            SceneManager.LoadScene(new Stages());
        }
    }

    void Render()
    {
        Console.SetCursorPosition(13, 21);
        "     GAME OVER!".Print(ConsoleColor.Red);
        Console.SetCursorPosition(14, 23);
        "Enter를 눌러 나가기...".Print(ConsoleColor.Gray);
    }
}

using System;

public class GameOver : Scene
{
    public override void Load()
    {
        Audio.Play("gore01.wav");
        Render();
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

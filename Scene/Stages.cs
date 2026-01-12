using System;
using System.Diagnostics;

public class Stages : Scene
{
    private MenuList _stageMenu;

    public override void Load()
    {
        Audio.Play("UI01.wav");
        _stageMenu = new MenuList();
        _stageMenu.Add("튜토리얼", () => SceneManager.LoadScene(new Tutorial()));
        _stageMenu.Add("폴리 리듬 던전", () => SceneManager.LoadScene(new Stage1()));
        _stageMenu.Add("던전 깊숙한곳", () => SceneManager.LoadScene(new Stage2()));
        _stageMenu.Add("타이틀", () => SceneManager.LoadScene(new Title()));

        if (SceneManager._prev is Stage1) // 이전 씬에 따라 간편하게 메뉴 선택
        {
            _stageMenu.SelectDown();
        }
        else if (SceneManager._prev is Stage2)
        {
            _stageMenu.SelectDown();
            _stageMenu.SelectDown();
        }
        else if (SceneManager._prev is GameOver)
        {
            switch (GameOver.stage)
            {
                case 1:
                    _stageMenu.SelectDown();
                    break;
                case 2:
                    _stageMenu.SelectDown();
                    _stageMenu.SelectDown();
                    break;
                default:
                    break;
            }
        }

        render = true;
    }

    public override void Unload()
    {
        _stageMenu = null;
    }

    public override void Update()
    {
        if (render)
        {
            Render();
            render = false;
        }

        if (Input.KeyDown(Input.Key.Up))
        {
            Audio.Play("dust01.wav");
            _stageMenu.SelectUp();
            render = true;
        }

        if (Input.KeyDown(Input.Key.Down))
        {
            Audio.Play("dust01.wav");
            _stageMenu.SelectDown();
            render = true;
        }

        if (Input.KeyDown(Input.Key.Enter))
        {
            _stageMenu.Select();
        }

        System.Threading.Thread.Sleep(50);
    }

    private void Render()
    {
        Console.SetCursorPosition(10, 2);
        "    STAGE".Print(ConsoleColor.Yellow);

        _stageMenu.Render(12, 5);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Stages : Scene
{
    private MenuList _stageMenu;

    public override void Load()
    {
        Audio.Play("UI01.wav");
        _stageMenu = new MenuList();
        _stageMenu.Add("튜토리얼", () => SceneManager.LoadScene(new Tutorial()));
        _stageMenu.Add("스테이지-1", () => SceneManager.LoadScene(new Stage1()));
        _stageMenu.Add("타이틀", () => SceneManager.LoadScene(new Title()));

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
        "=== 스테이지 선택 ===".Print(ConsoleColor.Yellow);

        _stageMenu.Render(12, 5);
    }
}

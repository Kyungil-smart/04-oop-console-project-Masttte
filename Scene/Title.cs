using System;

public class Title : Scene
{
    private MenuList _titleMenu;

    public override void Load()
    {
        Console.Clear();
        _titleMenu = new MenuList();
        _titleMenu.Add("게임 시작", GameStart);
        _titleMenu.Add("사운드 재생 확인", SoundTest);
        _titleMenu.Add("도움말", () => { 
            Console.SetCursorPosition(0, 10);
            "\n          게임 조작법은 튜토리얼에서 숙지하시오!\n          뒤로가기: Q, NumPad0\n          로그출력: L".Print(ConsoleColor.Cyan); 
        });
        _titleMenu.Add("게임 종료", () => { Environment.Exit(0); });

        render = true;
    }

    public override void Unload()
    {
    }

    public override void Update()
    {
        if (render)// 이제 깜빡임 없이 비동기 렌더링 드가자~~
        {
            Render();
            render = false;
        }

        if (Input.KeyDown(Input.Key.Up))
        {
            Audio.Play("dust01.wav");
            _titleMenu.SelectUp();
            render = true;
        }

        if (Input.KeyDown(Input.Key.Down))
        {
            Audio.Play("dust01.wav");
            _titleMenu.SelectDown();
            render = true;
        }


        if (Input.KeyDown(Input.Key.Enter))
        {
            Audio.Play("UI01.wav");
            _titleMenu.Select();
        }
    }

    public void Render()
    {
        Console.SetCursorPosition(6, 2);
        GameManager.GameTitle.Print(ConsoleColor.Yellow);

        _titleMenu.Render(8, 5);
    }

    private void GameStart()
    {
        SceneManager.LoadScene(new Stages());
    }

    void SoundTest()
    {
        Audio.Play("Beep01.wav");
        Console.SetCursorPosition(0, 9);
        "\n          사운드가 재생되었습니다".Print(ConsoleColor.Magenta);
    }
}


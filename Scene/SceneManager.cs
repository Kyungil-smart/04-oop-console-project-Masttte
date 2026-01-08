using System;
using System.Collections.Generic;

public abstract class Scene
{
    // 렌더링 필요할때 마다 true로 설정
    protected bool render = false;

    public abstract void Load();
    public abstract void Unload();
    public abstract void Update();
}

public static class SceneManager
{
    public static Scene _current;
    public static Scene _prev;
    public static Stack<Scene> _prevScenes = new Stack<Scene>();

    public static Action OnSceneChanged;

    public static void LoadScene(Scene nextScene)
    {
        Audio.StopAll();
        _prev = _current;
        _current?.Unload();
        _current = null;

        // 뒤로가기용 스택에 쌓아두기
        if (_prev?.GetType().Name != "LogScene") _prevScenes.Push(_prev);
        Input.Reset();

        _current = nextScene;
        _current.Load();

        // 로그 저장
        if (nextScene?.GetType().Name != "LogScene" && _prev?.GetType().Name != "LogScene") Debug.Log("씬 로드: " + nextScene.GetType().Name);
    }

    public static void Update()
    {
        _current?.Update();
    }

    public static void LoadPrevScene() // 뒤로가기
    {
        if (_prevScenes.Count > 0)
        {
            Scene nextScene = _prevScenes.Pop();
            if (nextScene == null) return;
            Audio.StopAll();
            _prev = _current;
            _current?.Unload();
            _current = null;
            Input.Reset();
            _current = nextScene;
            _current.Load();
            if (_prev?.GetType().Name != "LogScene") Debug.LogWarning("뒤로가기: " + nextScene.GetType().Name);
        }
    }
}

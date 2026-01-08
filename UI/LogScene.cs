using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LogScene : Scene
{
    public override void Load()
    {
        Debug.Render();
    }

    public override void Unload()
    {

    }

    public override void Update()
    {
        if (Input.KeyDown(Input.Key.Enter))
        {
            SceneManager.LoadPrevScene();
        }

    }
}

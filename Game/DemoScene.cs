using Mofu.ECS;
using Mofu.Scenes;
using Raylib_cs;

namespace GameDemo;

public class DemoScene : IScene
{
    public uint SceneIndex { get; init; } = 0;

    
    public void LoadResources()
    {
    }

    public void Construct()
    {
        new Entity().AddComponent<DemoComponent>(10, 10, 5.0, Color.RED);
    }
}
using Mofu.ECS;
using Mofu.Scenes;
using Raylib_cs;

namespace GameDemo;

public class DemoScene2 : IScene
{
    public uint SceneIndex { get; init; } = 1;

    
    public void LoadResources()
    {
    }

    public void Construct()
    {
        new Entity().AddComponent<DemoComponent>(10, 10, 5.0f, Color.GREEN);
    }
}
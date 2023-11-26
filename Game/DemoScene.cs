using Mofu.ECS;
using Mofu.Scene;
using Raylib_cs;

namespace GameDemo;

public class DemoScene : IScene
{
    public uint SceneIndex { get; init; } = 0;
    
    public void LoadResources()
    {
        Raylib.TraceLog(TraceLogLevel.LOG_INFO, "Fake loading resources...");
    }

    public void Construct()
    {
        var myEntity = new Entity();
        myEntity.AddComponent<DemoComponent>(10, 10, 5.0f, Color.RED);
    }
}
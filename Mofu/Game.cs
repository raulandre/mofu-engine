using Mofu.ECS;
using Mofu.Scene;

namespace Mofu;

public static class Game
{
    public static Window? Window { get; private set; } = null;

    // TODO: create config class instead of passing individual params
    public static void Configure(int width, int height, string title)
    {
        Window = new Window(width, height, title);
    }

    public static int Run()
    {
        if (!SceneManager.Initialized)
            throw new Exception("Please initialize SceneManager by loading scenes from the appropriate assembly. SceneManager found no scenes to run.");
        
        Window?.Present();
        
        EntityManager.HookScene(SceneManager.CurrentScene!);
        EntityManager.Initialize();
        
        while (Window?.IsRunning() ?? false)
        {
            EntityManager.Update();
            
            Window?.Draw();
        }
        
        return 0;
    }
}

internal class FpsCounter : Component
{
    private readonly int _x;
    private readonly int _y;

    public FpsCounter(Entity owner, int x, int y) : base(owner)
    {
        _x = x;
        _y = y;
    }

    public override void Initialize()
    { }

    public override void Update()
    { }

    public override void Draw2D()
    {
        R.DrawFPS(_x, _y);
    }
}
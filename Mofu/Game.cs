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
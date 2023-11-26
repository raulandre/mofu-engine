using Mofu.ECS;
using Mofu.Scene;

namespace Mofu;

public static class Game
{
    private static Window? _window;

    // TODO: create config class instead of passing individual params
    public static void Configure(int width, int height, string title)
    {
        _window = new Window(width, height, title);
    }

    public static int Run()
    {
        if (!SceneManager.Initialized)
            throw new Exception("Please initialize SceneManager by loading scenes from the appropriate assembly. SceneManager found no scenes to run.");
        
        _window?.Present();
        
        EntityManager.HookScene(SceneManager.CurrentScene!);
        EntityManager.Initialize();
        
        while (_window?.IsRunning() ?? false)
        {
            EntityManager.Update();
            
            _window?.Draw();
        }
        
        return 0;
    }
}
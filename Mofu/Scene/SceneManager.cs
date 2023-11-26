using System.Reflection;

namespace Mofu.Scene;

public static class SceneManager
{
    private static List<IScene?> _scenes = new();
    public static bool Initialized { get; private set; } = false;
    
    public static IReadOnlyCollection<IScene?> Scenes() => _scenes;

    public static IScene? CurrentScene { get; private set; }

    public static void LoadScenesFromAssembly(Assembly assembly)
    {
        _scenes = assembly.GetTypes()
            .Where(t => t.GetInterfaces().Contains(typeof(IScene)))
            .Select(t => Activator.CreateInstance(t) as IScene)
            .OrderBy(s => s?.SceneIndex)
            .ToList();

        CurrentScene = _scenes.FirstOrDefault();
        Initialized = _scenes.Count > 0;
    }
}
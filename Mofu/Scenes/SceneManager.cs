using System.Reflection;
using Mofu.ECS;
using Mofu.Scenes;

namespace Mofu.Scene;

public static class SceneManager
{
    private static List<IScene?> _scenes = new();
    public static IReadOnlyCollection<IScene?> Scenes() => _scenes;
    public static bool Initialized { get; private set; } = false;
    public static IScene? CurrentScene { get; private set; }

    public static bool HasScheduledSceneChange { get; private set; } = false;
    public static IScene? NextScene { get; private set; }

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

    public static void LoadSceneByIndex(uint sceneIndex)
    {
        var scene = _scenes.FirstOrDefault(s => s!.SceneIndex == sceneIndex);

        if (scene is null)
            R.TraceLog(TraceLogLevel.LOG_ERROR, $"Failed to load scene with index {sceneIndex}.");
        else
        {
            ScheduleSceneChange(scene);
        }
    }

    private static void ScheduleSceneChange(IScene? scene)
    {
        HasScheduledSceneChange = true;
        NextScene = scene;
    }

    public static void NotifySceneChangeComplete()
    {
        if (!HasScheduledSceneChange) return;

        HasScheduledSceneChange = false;
        CurrentScene = NextScene;
        NextScene = null;
    }
}
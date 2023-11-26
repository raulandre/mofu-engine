using Mofu.Scene;
using Mofu.Scenes;

namespace Mofu.ECS;

public static class EntityManager
{
    private static readonly List<Entity> _entities = new();
    public static IReadOnlyCollection<Entity> Entities => _entities;

    public static void Register(Entity entity)
    {
        _entities.Add(entity);
    }

    public static void HookScene(IScene scene)
    {
        _entities.Clear();
        scene.LoadResources();
        scene.Construct();
        Initialize();
    }

    public static void Initialize()
    {
        foreach (var entity in _entities)
            entity.Initialize();
    }

    public static void Update()
    {
        if (SceneManager.HasScheduledSceneChange)
        {
            HookScene(SceneManager.NextScene!);
            SceneManager.NotifySceneChangeComplete();
        }
        
        foreach (var entity in _entities)
            entity.Update();
    }

    public static void Draw2D()
    {
        foreach (var entity in _entities)
            entity.Draw2D();
    }
}
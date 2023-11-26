using Mofu.Scene;

namespace Mofu.ECS;

public static class EntityManager
{
    private static List<Entity> _entities = new();
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
    }

    public static void Initialize()
    {
        foreach (var entity in _entities)
            entity.Initialize();
    }

    public static void Update()
    {
        foreach (var entity in _entities)
            entity.Update();
    }

    public static void Draw2D()
    {
        foreach (var entity in _entities)
            entity.Draw2D();
    }
}
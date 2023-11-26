namespace Mofu.ECS;

public class Entity
{
    private readonly List<Component> _components = new();
    public IReadOnlyCollection<Component> Components => _components;

    public Entity()
    {
        EntityManager.Register(this);
    }

    public virtual void Initialize()
    {
        foreach (var component in _components)
            component.Initialize();
    }

    public virtual void Update()
    {
        foreach (var component in _components)
            component.Update();
    }

    public virtual void Draw2D()
    {
        foreach (var component in _components)
            component.Draw2D();
    }

    public T? GetComponent<T>() where T : Component
        => _components.FirstOrDefault(c => c.GetType() == typeof(T)) as T;

    public T? AddComponent<T>(params object?[] args) where T : Component
    {
        var paramPack = new object[] { this }.Concat(args).ToArray();

        try
        {
            if (Activator.CreateInstance(typeof(T), args: paramPack) is not T createdComponent) return null;
            _components.Add(createdComponent);
            return createdComponent;
        }
        catch (MissingMethodException)
        {
            #if DEBUG
            var passing = string.Join(", ", paramPack.Select(p => p?.GetType().Name));
            var expected = string.Join(", ",
                typeof(T).GetConstructors().FirstOrDefault()?.GetParameters().Select(p => p.ParameterType.Name) ??
                Array.Empty<string>());
            
            R.TraceLog(TraceLogLevel.LOG_ERROR, $"Malformed parameter pack to component {typeof(T).Name} on AddComponent call. Passing: ({passing}) | Expected: ({expected})");
            #endif
            return null;
        }
    }
}
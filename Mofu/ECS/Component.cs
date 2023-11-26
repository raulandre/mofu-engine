namespace Mofu.ECS;

public abstract class Component
{
    private Entity _owner;
    
    protected Component(Entity owner)
    {
        _owner = owner;
    }
    
    public abstract void Initialize();
    public abstract void Update();
    public abstract void Draw2D();
}
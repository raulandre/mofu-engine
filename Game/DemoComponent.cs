using System.Numerics;
using Mofu.ECS;
using Raylib_cs;

namespace GameDemo;

public class DemoComponent : Component
{
    private readonly int _x;
    private readonly int _y;
    private Vector2 _mousePos;
    private readonly float _radius;
    private readonly Color _color;
    
    public DemoComponent(Entity owner, int x, int y, float radius, Color color) 
        : base(owner)
    {
        _x = x;
        _y = y;
        _radius = radius;
        _color = color;
    }

    public override void Initialize()
    { }

    public override void Update()
    {
        _mousePos = Raylib.GetMousePosition();
    }

    public override void Draw2D()
    {
        Raylib.DrawFPS(_x, _y);
        Raylib.DrawCircle((int)_mousePos.X, (int)_mousePos.Y, _radius, _color);
    }
}
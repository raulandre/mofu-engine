using Mofu.ECS;

namespace Mofu.Tests.Fixtures;

class SampleComponent : Component
{
    public int N { get; set; }
    public string S { get; set; }
    public object O { get; set; }
    
    public SampleComponent(Entity owner, int n, string s, object o) : base(owner)
    {
        N = n;
        S = s;
        O = o;
    }

    public override void Initialize()
    { }

    public override void Update()
    { }

    public override void Draw2D()
    { }
}
using Mofu.Scene;
using Mofu.Scenes;

namespace Mofu.Tests.Fixtures;

public class SampleScene : IScene
{
    public SampleScene() {}
    public uint SceneIndex { get; init; } = 1;
    
    public void LoadResources()
    {
    }

    public void Construct()
    {
    }
}

public class OtherSampleScene : IScene
{
    public OtherSampleScene() {}
    public uint SceneIndex { get; init; } = 2;
    
    public void LoadResources()
    {
    }

    public void Construct()
    {
    }
}
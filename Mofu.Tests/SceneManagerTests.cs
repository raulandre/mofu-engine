using System.Reflection;
using Mofu.Scene;
using Mofu.Tests.Fixtures;

namespace Mofu.Tests;

public class SceneManagerTests
{
    [Fact]
    public void SceneManager_ShouldLoadScenesFromAssembly()
    {
        SceneManager.LoadScenesFromAssembly(Assembly.GetExecutingAssembly());
        
        Assert.NotEmpty(SceneManager.Scenes());
        Assert.Contains(SceneManager.Scenes(), s => s?.GetType() == typeof(SampleScene));
    }

    [Fact]
    public void SceneManager_ShouldSetCurrentSceneIndex_OrderByAscending()
    {
        SceneManager.LoadScenesFromAssembly(Assembly.GetExecutingAssembly());
        
        Assert.NotEmpty(SceneManager.Scenes());
        Assert.Equal(SceneManager.CurrentScene?.SceneIndex, 69420u);
    }
}
using System.Reflection;
using Mofu.ECS;
using Mofu.Scene;
using Mofu.Tests.Fixtures;

namespace Mofu.Tests;

public class SceneManagerTests
{
    [Fact]
    public void SceneManager_ShouldLoadScenesFromAssembly()
    {
        SceneManager.LoadScenesFromAssembly(Assembly.GetExecutingAssembly());
        
        Assert.True(SceneManager.Initialized);
        Assert.NotEmpty(SceneManager.Scenes());
        Assert.Contains(SceneManager.Scenes(), s => s?.GetType() == typeof(SampleScene));
    }

    [Fact]
    public void SceneManager_ShouldSetCurrentSceneIndex_OrderByAscending()
    {
        SceneManager.LoadScenesFromAssembly(Assembly.GetExecutingAssembly());
        
        Assert.NotEmpty(SceneManager.Scenes());
        Assert.Equal(SceneManager.CurrentScene?.SceneIndex, new SampleScene().SceneIndex);
    }

    [Fact]
    public void SceneManager_ShouldScheduleSceneChange_OnLoadSceneCalled()
    {
        SceneManager.LoadScenesFromAssembly(Assembly.GetExecutingAssembly());
        SceneManager.LoadSceneByIndex(new OtherSampleScene().SceneIndex);
        
        Assert.True(SceneManager.HasScheduledSceneChange);
        Assert.NotNull(SceneManager.NextScene);
    }

    [Fact]
    public void SceneManager_ShouldUnscheduleSceneChange_OnSceneChangeComplete()
    {
        SceneManager.LoadScenesFromAssembly(Assembly.GetExecutingAssembly());
        SceneManager.LoadSceneByIndex(new OtherSampleScene().SceneIndex);
        SceneManager.NotifySceneChangeComplete();
        
        Assert.False(SceneManager.HasScheduledSceneChange);
        Assert.Null(SceneManager.NextScene);
    }
}
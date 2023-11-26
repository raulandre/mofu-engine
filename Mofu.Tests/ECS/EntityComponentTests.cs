using Mofu.ECS;
using Mofu.Tests.Fixtures;

namespace Mofu.Tests.ECS;

public class EntityComponentTests
{
    [Fact]
    public void AddComponent_ShouldForwardArgsProperly()
    {
        var entity = new Entity();
        var n = 69;
        var s = "mofu";
        var o = new { n, s };

        var component = entity.AddComponent<SampleComponent>(n, s, o);
        
        Assert.NotNull(component);
        Assert.Equal(component.N, n);
        Assert.Equal(component.S, s);
        Assert.Equal(component.O, o);
    }

    [Fact]
    public void GetComponent_ShouldReturnTComponent()
    {
        var entity = new Entity();

        entity.AddComponent<SampleComponent>(0, string.Empty, null);
        var component = entity.GetComponent<SampleComponent>();
        
        Assert.NotNull(component);
        Assert.IsType<SampleComponent>(component);
    }

    [Fact]
    public void OnEntityCreated_ShouldRegisterOnEntityManager()
    {
        var entities = EntityManager.Entities;

        var entity = new Entity();

        Assert.NotEmpty(entities);
        Assert.Contains(entities, e => e.Equals(entity));
    }
}
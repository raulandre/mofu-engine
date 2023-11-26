# Mofu Engine
![build](https://github.com/raulandre/mofu-engine/actions/workflows/dotnet.yml/badge.svg)     
Simple game engine library written in C# using Raylib-cs
## Basic functionality
```
// Specify basic window creation params
Game.Configure(1366, 768, "Nimotsu");

// Load scenes from game assembly (uses reflection)
SceneManager.LoadScenesFromAssembly(Assembly.GetExecutingAssembly());

// Present window and start from scene with lowest index
return Game.Run(); 
```
Mofu will automatically load scenes (through the IScene interface) and get them ready to run:
```
public class Scene : IScene
{
    // Specify scene index
    public uint SceneIndex { get; init; } = 0;
    
    public void LoadResources()
    {
        // Load all resources required by the scene, Mofu will call this internally when the time comes for it to run
    }

    public void Construct()
    {
        // Describe the scene entities and their components (can also be done separately by inheriting from Entity class)

        var myEntity = new Entity();
        myEntity.AddComponent<MyComponent>(10, "x", 5.0f, Color.RED);
    }
}
```

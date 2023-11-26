namespace Mofu.Scenes;

public interface IScene
{
    public uint SceneIndex { get; init; }

    public void LoadResources();
    public void Construct();
}
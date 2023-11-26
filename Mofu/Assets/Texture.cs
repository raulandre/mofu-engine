namespace Mofu.Assets;

public class Texture : IAsset
{
    private Texture2D _texture2D;

    public Texture(string path)
    {
        Type = AssetType.Texture;
        Path = path;

        Load(path);
    }

    public AssetType Type { get; set; }
    public string Path { get; set; }

    public void Load(string fullPath)
    {
        _texture2D = R.LoadTexture(fullPath);
    }

    public void Dispose()
    {
        R.UnloadTexture(_texture2D);
    }

    public static implicit operator Texture2D(Texture texture)
        => texture._texture2D;
}
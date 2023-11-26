namespace Mofu.Assets;

public interface IAsset : IDisposable
{
    public AssetType Type { get; set; }
    public string Path { get; set; }
    
    public void Load(string fullPath);
    public new void Dispose();
}
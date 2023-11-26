using Mofu.ECS;

namespace Mofu;

public sealed class Window : IDisposable
{
    public int Width { get; init; }
    public int Height { get; init; }
    public string Title { get; init; }
    private int TargetFps { get; set; }

    internal bool IsRunning() => !R.WindowShouldClose();
    
    private bool _presented = false;

    public Window(int width, int height, string title, int targetFps = 60)
    {
        Width = width;
        Height = height;
        Title = title;
        TargetFps = targetFps;
    }

    public void Present()
    {
        R.InitWindow(Width, Height, Title);
        R.InitAudioDevice();
        R.SetTargetFPS(TargetFps);
        
        #if DEBUG
        R.SetTraceLogLevel(TraceLogLevel.LOG_DEBUG);
        #else
        R.SetTraceLogLevel(TraceLogLevel.LOG_NONE);
        #endif
        
        _presented = true;
    }

    public void Draw()
    {
        R.BeginDrawing();
            R.ClearBackground(Color.BLACK);
            EntityManager.Draw2D();
        R.EndDrawing();
    }

    public void Dispose()
    {
        if (!_presented) return;
        R.CloseAudioDevice();
        R.CloseWindow();
    }
}
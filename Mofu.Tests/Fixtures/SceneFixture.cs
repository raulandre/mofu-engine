﻿using Mofu.Scene;
using Mofu.Scenes;

namespace Mofu.Tests.Fixtures;

public class SampleScene : IScene
{
    public SampleScene() {}
    public uint SceneIndex { get; init; } = 69420;
    
    public void LoadResources()
    {
    }

    public void Construct()
    {
    }
}
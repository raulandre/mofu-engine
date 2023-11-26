using System.Reflection;
using Mofu;
using Mofu.Scene;

Game.Configure(1366, 768, "Nimotsu");

SceneManager.LoadScenesFromAssembly(Assembly.GetExecutingAssembly());

return Game.Run();
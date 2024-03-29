// In PlayScreen.cs
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Paradox;

public class PlayScreen : Screen
{
    private World _world;
    private Camera _camera;
    private GraphicsDevice _graphicsDevice;

    public PlayScreen(GraphicsDevice graphicsDevice)
    {
        _graphicsDevice = graphicsDevice;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _world = new World();
        _camera = new Camera(Singleton.Instance.GraphicsDevice.Viewport);
        // Perform any additional setup for _world and _camera
    }

    public override void Load()
    {
        _world.Load();
        // Load other resources specific to PlayScreen
    }

    public override void Update(GameTime gameTime)
    {
        _world.Update(gameTime);
        _camera.Follow(_world.GetPlayerPosition());
        // Add additional update logic for PlayScreen
    }

    public override void Draw(GameTime gameTime)
    {
        _world.Draw(gameTime);
    }
}
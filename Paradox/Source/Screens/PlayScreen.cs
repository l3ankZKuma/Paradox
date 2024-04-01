// In PlayScreen.cs

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Paradox;

public class PlayScreen : Screen
{
    private World _world;
    private Camera _camera;
    private GraphicsDevice _graphicsDevice;
    private Vector2 _mousePositionInWorld;
    private UI _ui;

    public PlayScreen()
    {
        _world = new World();
        _camera = new Camera(Singleton.Instance.GraphicsDevice.Viewport);
        _ui = new UI();
        
    }
    

    public override void Load()
    {
        _world.Load();
        _ui.Load();
        // Load other resources specific to PlayScreen
    }

    public override void Update(GameTime gameTime)
    {
        

        
        // Existing camera and world updates
        _camera.Follow(Singleton.Instance.PlayerPos);
        _world.Update(gameTime);

        // Get mouse state
        var mouseState = Mouse.GetState();

        // Transform the mouse position from screen to world coordinates
        _mousePositionInWorld = Vector2.Transform(new Vector2(mouseState.X, mouseState.Y), Matrix.Invert(_camera.ViewMatrix));
        
        Console.WriteLine(_mousePositionInWorld);

    }

    public override void Draw(GameTime gameTime)
    {
        
        //dynamic
        Singleton.Instance.SpriteBatch.Begin(transformMatrix: _camera.ViewMatrix);
        
        _world.Draw(gameTime);
        
        
        Singleton.Instance.SpriteBatch.End();
        
        //static
        
        Singleton.Instance.SpriteBatch.Begin();
        
        _ui.Draw(gameTime);
        
        Singleton.Instance.SpriteBatch.End();
    }
}
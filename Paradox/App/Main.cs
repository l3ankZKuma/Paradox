using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Paradox;

public class Main : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private World _world;
    private Camera _camera;

    public Main()
    {
        _world = new World();
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _camera = new Camera(GraphicsDevice.Viewport);
        
        
        // TODO: Add your initialization logic here
        Singleton.Instance.UISize = new Vector2(1280, 720);
        
        _graphics.PreferredBackBufferWidth = (int)Singleton.Instance.UISize.X;
        _graphics.PreferredBackBufferHeight = (int)Singleton.Instance.UISize.Y;
        
        _graphics.ApplyChanges();
        

        base.Initialize();
    }

    protected override void LoadContent()
    {
        Singleton.Instance.SpriteBatch = new SpriteBatch(GraphicsDevice);
        Singleton.Instance.Content = Content;
        
        _world.Load();

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        Console.WriteLine("({0} , {1} ) ", Mouse.GetState().X, Mouse.GetState().Y);
        
        _world.Update(gameTime);
        _camera.Follow(_world.GetPlayerPosition());
        

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        Singleton.Instance.SpriteBatch.Begin();
        

        // TODO: Add your drawing code here
        
        
        
        _world.Draw(gameTime);
        
        
        
        Singleton.Instance.SpriteBatch.End();

        base.Draw(gameTime);
    }
}
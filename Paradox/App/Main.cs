using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Paradox
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private World _world;
        private Camera _camera;
        private Vector2 _mousePositionInWorld;


        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _world = new World();
            _camera = new Camera(GraphicsDevice.Viewport);
            Singleton.Instance.GameTime = new GameTime();

            Singleton.Instance.UISize = new Vector2(1280, 720);
            _graphics.PreferredBackBufferWidth = (int)Singleton.Instance.UISize.X;
            _graphics.PreferredBackBufferHeight = (int)Singleton.Instance.UISize.Y;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Singleton.Instance.SpriteBatch = _spriteBatch;
            Singleton.Instance.Content = Content;

            _world.Load();
        }

        protected override void Update(GameTime gameTime)
        {
            // Check for game exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Singleton.Instance.PlayerPos = _world.GetPlayerPosition();
            // Existing camera and world updates
            _camera.Follow(_world.GetPlayerPosition());
            _world.Update(gameTime);

            // Get mouse state
            var mouseState = Mouse.GetState();

            // Transform the mouse position from screen to world coordinates
            _mousePositionInWorld = Vector2.Transform(new Vector2(mouseState.X, mouseState.Y), Matrix.Invert(_camera.ViewMatrix));
            
            Console.WriteLine(_mousePositionInWorld);

            // Use _mousePositionInWorld as needed in your game logic

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(transformMatrix: _camera.ViewMatrix);
            _world.Draw(gameTime);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
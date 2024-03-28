using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;

namespace Paradox
{
    public class Singleton
    {
        private static Singleton instance;
        private GraphicsDevice _graphicsDevice;
        private SpriteBatch _spriteBatch;
        private ContentManager _content;
        private GameTime _gameTime;

        // Static property to get the instance
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }

                return instance;
            }
        }

        // Private constructor to prevent instance creation
        private Singleton()
        {
        }

        public SpriteBatch SpriteBatch
        {
            get { return _spriteBatch; }
            set { _spriteBatch = value; }
        }

        public ContentManager Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public GameTime GameTime
        {
            get { return _gameTime; }
            set { _gameTime = value; }
        }

        public GraphicsDevice GraphicsDevice
        {
            get { return _graphicsDevice; }
            set { _graphicsDevice = value; }
        }

        // Static property for UI Size if you need it to be part of the singleton
        public Vector2 UISize { get; set; }


    }
}
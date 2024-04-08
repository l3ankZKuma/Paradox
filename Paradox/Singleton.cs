using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace Paradox
{
    // Singleton class to manage global game state and resources
    public class Singleton
    {
        // Declare variables
        private static Singleton instance;
        private GraphicsDevice _graphicsDevice;
        private SpriteBatch _spriteBatch;
        private ContentManager _content;
        private GameTime _gameTime;
        private ScreenManager _screenManager;
        private Song _bgm;
        private List<Enemy> _enemies;

        // Player variables
        private int _playerHP = 5;
        private float _playerSpeed = 0.015f;
        private int _playerAtk = 1;
        private int _playerCoin = 0;
        private Rectangle _playerCollisionBox;

        private Game _game { get; set; }

        // Mouse state
        private MouseState _mouseState;

        private Vector2 _playerPos;
        
        


        // Static property to get the instance
        public static Singleton Instance
        {
            get
            {
                // If instance is null, create a new Singleton instance
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

        // Properties to get and set game resources and state
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

        public Vector2 PlayerPos
        {
            get { return _playerPos; }
            set { _playerPos = value; }
        }

        public ScreenManager ScreenManager
        {
            get { return _screenManager; }
            set { _screenManager = value; }
        }

        public int PlayerAtk
        {
            get { return _playerAtk; }
            set { _playerAtk = value; }
        }

        public MouseState MouseState
        {
            get { return _mouseState; }
            set { _mouseState = value; }
        }

        // Static property for UI Size if you need it to be part of the singleton
        public Vector2 UISize { get; set; }

        public int PlayerHP
        {
            get { return _playerHP; }
            set { _playerHP = value; }
        }

        public float PlayerSpeed
        {
            get { return _playerSpeed; }
            set { _playerSpeed = value; }
        }

        public int PlayerCoin
        {
            get { return _playerCoin; }
            set { _playerCoin = value; }
        }

        // Method to exit the game
        public void ExitGame()
        {
            _game.Exit();
        }

        // Property to get and set the list of enemies
        public List<Enemy> Enemies
        {
            get { return _enemies; }
            set { _enemies = value; }
        }

        // Property to get and set the player's collision box
        public Rectangle PlayerCollisionBox
        {
            get { return _playerCollisionBox; }
            set { _playerCollisionBox = value; }
        }

        // Property to get and set the background music
        public Song BGM
        {
            get { return _bgm; }
            set { _bgm = value; }
        }
        
  
    }
}
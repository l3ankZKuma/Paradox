using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Paradox
{
    public class MenuScreen : Screen
    {
        private Texture2D _background;
        private Texture2D _startButton, _optionButton, _exitButton;
        private Vector2 _startButtonPosition, _optionButtonPosition, _exitButtonPosition;
        private MouseState _previousMouseState;
        
        private bool _isHoverStart = false, _isHoverOption = false, _isHoverExit = false;
        
        

        public MenuScreen()
        {
            _startButtonPosition = new Vector2(503, 284); // Example positions, adjust as needed
            _optionButtonPosition = new Vector2(487, 393);
            _exitButtonPosition = new Vector2(552, 522);
        }

        public override void Load()
        {
            _background = Singleton.Instance.Content.Load<Texture2D>("Menu/Menu_BG3");
            _startButton = Singleton.Instance.Content.Load<Texture2D>("Menu/Menu_BG_Start");
            _optionButton = Singleton.Instance.Content.Load<Texture2D>("Menu/Menu_BG_Option");
            _exitButton = Singleton.Instance.Content.Load<Texture2D>("Menu/Menu_BG_Exit");
            Singleton.Instance.BGM = Singleton.Instance.Content.Load<Song>("Sound/Menu_BGM");

        }

        public override void Update(GameTime gameTime)
        {

            if (Singleton.Instance.BGM != null && MediaPlayer.State != MediaState.Playing)
            {
                MediaPlayer.Play(Singleton.Instance.BGM);
            }

            
            
            MouseState currentMouseState = Mouse.GetState();

            // Reset hover states
            _isHoverStart = _isHoverOption = _isHoverExit = false;

            // Start button hover detection
            if (currentMouseState.X >= _startButtonPosition.X && currentMouseState.X <= _startButtonPosition.X + _startButton.Width &&
                currentMouseState.Y >= _startButtonPosition.Y && currentMouseState.Y <= _startButtonPosition.Y + _startButton.Height)
            {
                _isHoverStart = true;
                if (currentMouseState.LeftButton == ButtonState.Released && _previousMouseState.LeftButton == ButtonState.Pressed)
                {
                    Singleton.Instance.ScreenManager.LoadScreen(ScreenManager.GameScreenName.PlayScreen);
                }
            }

            // Option button hover detection
            if (currentMouseState.X >= _optionButtonPosition.X && currentMouseState.X <= _optionButtonPosition.X + _optionButton.Width &&
                currentMouseState.Y >= _optionButtonPosition.Y && currentMouseState.Y <= _optionButtonPosition.Y + _optionButton.Height)
            {
                _isHoverOption = true;
                if (currentMouseState.LeftButton == ButtonState.Released && _previousMouseState.LeftButton == ButtonState.Pressed)
                {
                    // Option button clicked
                    Console.WriteLine("Option Button Clicked");
                    // Switch to options screen
                }
            }

            // Exit button hover detection
            if (currentMouseState.X >= _exitButtonPosition.X && currentMouseState.X <= _exitButtonPosition.X + _exitButton.Width &&
                currentMouseState.Y >= _exitButtonPosition.Y && currentMouseState.Y <= _exitButtonPosition.Y + _exitButton.Height)
            {
                _isHoverExit = true;
                if (currentMouseState.LeftButton == ButtonState.Released && _previousMouseState.LeftButton == ButtonState.Pressed)
                {
                    // Exit button clicked
                    Console.WriteLine("Exit Button Clicked");
                    // Exit the game or go back to the main screen
                    Singleton.Instance.ExitGame();
                }
            }

            _previousMouseState = currentMouseState; // Save the current state as the previous state for the next cycle
        }

        public override void Draw(GameTime gameTime)
        {
            Singleton.Instance.SpriteBatch.Begin();

            // Always draw the background first
            Singleton.Instance.SpriteBatch.Draw(_background, new Vector2(0, 0), Color.White);

            // Optionally overlay buttons based on hover state for visual feedback (if desired)
            if (_isHoverStart)
            {
                Singleton.Instance.SpriteBatch.Draw(_startButton, new Vector2(0,0), Color.White);
            }
            if (_isHoverOption)
            {
               Singleton.Instance.SpriteBatch.Draw(_optionButton, new Vector2(0, 0), Color.White);
            }
            if (_isHoverExit)
            {
               Singleton.Instance.SpriteBatch.Draw(_exitButton, new Vector2(0, 0), Color.White);
            }

            Singleton.Instance.SpriteBatch.End();
        }
    }
}
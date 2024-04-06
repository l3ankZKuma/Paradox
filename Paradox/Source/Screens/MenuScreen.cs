using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Paradox
{
    // The MenuScreen class inherits from the Screen class and represents the game's menu screen
    public class MenuScreen : Screen
    {
        // Declare variables for the background and button textures, button positions, and mouse state
        private Texture2D _background;
        private Texture2D _startButton, _optionButton, _exitButton;
        private Vector2 _startButtonPosition, _optionButtonPosition, _exitButtonPosition;
        private MouseState _previousMouseState;
        
        // Booleans to check if the mouse is hovering over the buttons
        private bool _isHoverStart = false, _isHoverOption = false, _isHoverExit = false;
        
        // Constructor for the MenuScreen class
        public MenuScreen()
        {
            // Initialize the button positions
            _startButtonPosition = new Vector2(503, 284); // Example positions, adjust as needed
            _optionButtonPosition = new Vector2(487, 393);
            _exitButtonPosition = new Vector2(552, 522);
        }

        // Load method for the MenuScreen class
        public override void Load()
        {
            // Load the background and button textures and the background music
            _background = Singleton.Instance.Content.Load<Texture2D>("Menu/Menu_BG3");
            _startButton = Singleton.Instance.Content.Load<Texture2D>("Menu/Menu_BG_Start");
            _optionButton = Singleton.Instance.Content.Load<Texture2D>("Menu/Menu_BG_Option");
            _exitButton = Singleton.Instance.Content.Load<Texture2D>("Menu/Menu_BG_Exit");
            Singleton.Instance.BGM = Singleton.Instance.Content.Load<Song>("Sound/Menu_BGM");
        }

        // Update method for the MenuScreen class
        public override void Update(GameTime gameTime)
        {
            // Play the background music if it's not already playing
            if (Singleton.Instance.BGM != null && MediaPlayer.State != MediaState.Playing)
            {
                MediaPlayer.Play(Singleton.Instance.BGM);
            }

            // Get the current mouse state
            MouseState currentMouseState = Mouse.GetState();

            // Reset hover states
            _isHoverStart = _isHoverOption = _isHoverExit = false;

            // Check if the mouse is hovering over the start button and if it was clicked
            if (currentMouseState.X >= _startButtonPosition.X && currentMouseState.X <= _startButtonPosition.X + _startButton.Width &&
                currentMouseState.Y >= _startButtonPosition.Y && currentMouseState.Y <= _startButtonPosition.Y + _startButton.Height)
            {
                _isHoverStart = true;
                if (currentMouseState.LeftButton == ButtonState.Released && _previousMouseState.LeftButton == ButtonState.Pressed)
                {
                    // If the start button was clicked, load the play screen
                    Singleton.Instance.ScreenManager.LoadScreen(ScreenManager.GameScreenName.PlayScreen);
                }
            }

            // Check if the mouse is hovering over the option button and if it was clicked
            if (currentMouseState.X >= _optionButtonPosition.X && currentMouseState.X <= _optionButtonPosition.X + _optionButton.Width &&
                currentMouseState.Y >= _optionButtonPosition.Y && currentMouseState.Y <= _optionButtonPosition.Y + _optionButton.Height)
            {
                _isHoverOption = true;
                if (currentMouseState.LeftButton == ButtonState.Released && _previousMouseState.LeftButton == ButtonState.Pressed)
                {
                    // If the option button was clicked, print a message to the console
                    // You can replace this with code to switch to the options screen
                    Console.WriteLine("Option Button Clicked");
                }
            }

            // Check if the mouse is hovering over the exit button and if it was clicked
            if (currentMouseState.X >= _exitButtonPosition.X && currentMouseState.X <= _exitButtonPosition.X + _exitButton.Width &&
                currentMouseState.Y >= _exitButtonPosition.Y && currentMouseState.Y <= _exitButtonPosition.Y + _exitButton.Height)
            {
                _isHoverExit = true;
                if (currentMouseState.LeftButton == ButtonState.Released && _previousMouseState.LeftButton == ButtonState.Pressed)
                {
                    // If the exit button was clicked, exit the game
                    Singleton.Instance.ExitGame();
                }
            }

            // Save the current mouse state for the next update cycle
            _previousMouseState = currentMouseState;
        }

        // Draw method for the MenuScreen class
        public override void Draw(GameTime gameTime)
        {
            Singleton.Instance.SpriteBatch.Begin();

            // Draw the background
            Singleton.Instance.SpriteBatch.Draw(_background, new Vector2(0, 0), Color.White);

            // Draw the buttons if the mouse is hovering over them
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
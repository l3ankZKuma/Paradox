using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Paradox
{
    public class Player : Entity
    {

        private Vector2 _velocity;
        private string[] PATH;
        private Animation[] _playerAnimation;
        private _state _currentState;


        public Player()
        {
            // Correct array initialization with one element
            PATH = new string[]
            {
                "Unit/Player/Samurai/Idle", "Unit/Player/Samurai/Walk", "Unit/Player/Samurai/Jump",
                "Unit/Player/Samurai/Shield", "Unit/Player/Samurai/Attack_1", "Unit/Player/Samurai/Dead",
                "Unit/Player/Samurai/Hurt"
            };
        }


        public override void Load()
        {
            // Initialize the _sprite array to the same length as PATH array
            _sprite = new Texture2D[PATH.Length];

            // Loop through each path in the PATH array to load each texture
            for (int i = 0; i < PATH.Length; i++)
            {
                _sprite[i] = Singleton.Instance.Content.Load<Texture2D>(PATH[i]);
            }


            // Initialize _animation correctly
            _playerAnimation = new Animation[]
            {
                new Animation(_sprite[0], 768 / 6, 128),
                new Animation(_sprite[1], 1024 / 8, 128),
                new Animation(_sprite[2], 1536 / 12, 128),
                new Animation(_sprite[3], 256 / 2, 128),
                new Animation(_sprite[4], 768 / 6, 128),
                new Animation(_sprite[5], 384 / 2, 128),
                new Animation(_sprite[6], 256 / 2, 128)
            };
        }
        private float _timeSinceLastStateChange = 0.0f; // Timer for state changes
        private const float AnimationDuration = 1.0f; // Duration of one animation loop in seconds
        private GamePadState _previousGamePadState;

public override void Update(GameTime gameTime)
{
    
    // Update the timer with the elapsed game time since last update
    _timeSinceLastStateChange += (float)gameTime.ElapsedGameTime.TotalSeconds;

    // Get the state of the first connected gamepad
    var gamePadState = GamePad.GetState(PlayerIndex.One);

    // Check if the gamepad is connected before attempting to read it
    if (gamePadState.IsConnected)
    {
        // Existing logic for handling movement with deadzone implementation
        float speed = 5.0f; // Adjust the speed as needed
        float deadzone = 0.0001f; // Define a deadzone threshold
        float deltaX = gamePadState.ThumbSticks.Left.X * speed;
        float deltaY = gamePadState.ThumbSticks.Left.Y * speed;

        // Check for deadzone
        if (Math.Abs(deltaX) > deadzone || Math.Abs(deltaY) > deadzone)
        {
            // Update the player's position with valid input
            _position.X += deltaX;
            _position.Y -= deltaY; // Inverting Y axis

            _currentState = _state.walk;
            _timeSinceLastStateChange = 0.0f; // Reset timer for walk state
            //Console.WriteLine("Walk");
        }

        // Handle button presses with animation delay
        if (gamePadState.Buttons.X == ButtonState.Pressed && _timeSinceLastStateChange >= AnimationDuration)
        {
            _currentState = _state.attack;
            _timeSinceLastStateChange = 0.0f;
            //Console.WriteLine("Attack");
        }
        else if (gamePadState.Buttons.B == ButtonState.Pressed && _timeSinceLastStateChange >= AnimationDuration)
        {
            _currentState = _state.shield;
            _timeSinceLastStateChange = 0.0f;
        }
        else if (gamePadState.Buttons.A == ButtonState.Pressed && _timeSinceLastStateChange >= AnimationDuration)
        {
            _currentState = _state.jump;
            _timeSinceLastStateChange = 0.0f;
            //Console.WriteLine("Jump");
        }
    }

    // If no valid input is detected and enough time has passed, return to idle state
    if ((_currentState != _state.walk && _timeSinceLastStateChange >= AnimationDuration) || !gamePadState.IsConnected)
    {
        _currentState = _state.idle;
        // Consider whether to reset the timer here based on your animation and state transition needs
    }
}




        public override void Draw(GameTime gameTime)
        {
            // Use the current state to determine which animation to draw
            switch (_currentState)
            {
                case _state.idle:
                    _playerAnimation[0].Draw(_position, gameTime); // Idle animation
                    break;
                case _state.walk:
                    _playerAnimation[1].Draw(_position, gameTime); // Walk animation
                    break;
                case _state.jump:
                    _playerAnimation[2].Draw(_position, gameTime); // Jump animation
                    break;
                case _state.shield:
                    _playerAnimation[3].Draw(_position, gameTime); // Shield animation
                    break;
                case _state.attack:
                    _playerAnimation[4].Draw(_position, gameTime); // Attack animation
                    break;
                case _state.dead:
                    _playerAnimation[5].Draw(_position, gameTime); // Dead animation
                    break;
                case _state.hurt:
                    _playerAnimation[6].Draw(_position, gameTime); // Hurt animation
                    break;
                default:
                    // Consider logging an error or providing a default case action
                    break;
            }
        }
        
        
        public Vector2 Position
        {
            get { return _position; }
        }

    }
}
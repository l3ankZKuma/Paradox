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
        private Rectangle _playerRectangle;
        
        
        //sprite
        private bool _facingRight = true; // Tracks the direction the player is facing

        
        //physics
        private bool _isOnGround;
        private const float Gravity = 200.0f; // Adjust as necessary
        private const float JumpStrength = -200.0f; // Adjust as necessary
        private CollisionManager _collisionManager;



        public Player()
        {
            // Correct array initialization with one element
            PATH = new string[]
            {
                "Unit/Player/Samurai/Idle", "Unit/Player/Samurai/Walk", "Unit/Player/Samurai/Jump",
                "Unit/Player/Samurai/Shield", "Unit/Player/Samurai/Attack_1", "Unit/Player/Samurai/Dead",
                "Unit/Player/Samurai/Hurt"
            };
            
            _collisionManager = new CollisionManager();
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
            _playerRectangle = new Rectangle((int)_position.X, (int)_position.Y, 64, 128);
            
            // Update the timer with the elapsed game time since last update
            _timeSinceLastStateChange += (float)gameTime.ElapsedGameTime.TotalSeconds;
            HandleInput();
            ApplyPhysics((float)gameTime.ElapsedGameTime.TotalSeconds);
            CheckCollisions();

            
        }

        private void HandleInput()
        {
            // Get the state of the first connected gamepad
            var gamePadState = GamePad.GetState(PlayerIndex.One);

            // Ensure the gamepad is connected
            if (!gamePadState.IsConnected) return;

            float speed = 5.0f; // Movement speed
            float deadzone = 0.05f; // Increased deadzone for clearer intent
            float deltaX = gamePadState.ThumbSticks.Left.X * speed;
            float deltaY = gamePadState.ThumbSticks.Left.Y * speed;

            // Movement input
            if (Math.Abs(deltaX) > deadzone || Math.Abs(deltaY) > deadzone)
            {
                _position.X += deltaX;
                _position.Y -= deltaY; // Inverting Y axis

                if (!_currentState.Equals(_state.attack) && !_currentState.Equals(_state.jump))
                {
                    _currentState = _state.walk;
                }
            }
            else if (!gamePadState.Buttons.X.Equals(ButtonState.Pressed) && !_isOnGround)
            {
                // If no movement or attack, and not in the air (jumping), set to idle
                _currentState = _state.idle;
            }

            // Attack input
            if (gamePadState.Buttons.X.Equals(ButtonState.Pressed) && _timeSinceLastStateChange >= AnimationDuration)
            {
                _currentState = _state.attack;
                _timeSinceLastStateChange = 0f; // Reset timer for attack animation
            }

            // Jump input, allowing jump while moving or attacking
            if (gamePadState.Buttons.A.Equals(ButtonState.Pressed) && _isOnGround)
            {
                _velocity.Y = JumpStrength;
                _currentState = _state.jump;
                _isOnGround = false; // The player is no longer on the ground
                _timeSinceLastStateChange = 0f; // Reset timer for jump animation
            }

            // Optionally, reset to idle state if no input is detected
            if (Math.Abs(deltaX) <= deadzone && Math.Abs(deltaY) <= deadzone && !_currentState.Equals(_state.jump) && !_currentState.Equals(_state.attack))
            {
                _currentState = _state.idle;
            }
        }

        private void ApplyPhysics(float deltaTime)
        {
            // Apply gravity if not on the ground
            if (!_isOnGround)
            {
                _velocity.Y += Gravity * deltaTime;
            }

            // Update player position based on velocity
            _position += _velocity * deltaTime;

            // Ensure the player doesn't go below the ground/platform
            if (_isOnGround)
            {
                _velocity.Y = 0;
            }
        }


        private void CheckCollisions()
        {
            _isOnGround = false; // Assume not on the ground until a collision says otherwise

            foreach (var rect in _collisionManager.CollisionRectangles)
            {
                if (_playerRectangle.Intersects(rect))
                {
                    _isOnGround = true; // Player is on the ground
                    _position.Y = rect.Top - _playerRectangle.Height; // Adjust player position to stand on top of the platform
                    _velocity.Y = 0; // Stop vertical movement
                    break; // Assuming only one collision is relevant per update; remove if not applicable
                }
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
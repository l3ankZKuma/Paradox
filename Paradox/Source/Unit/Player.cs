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
        
        private bool _facingRight = true;
        
        private bool _isOnGround;
        private const float Gravity = 1000.0f; // Increased gravity for a more natural fall
        private const float JumpStrength = -500.0f; // Adjusted for ~160 pixels jump height
        private CollisionManager _collisionManager;

        public Player()
        {
            //_position.X = 12000;
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
            _sprite = new Texture2D[PATH.Length];
            for (int i = 0; i < PATH.Length; i++)
            {
                _sprite[i] = Singleton.Instance.Content.Load<Texture2D>(PATH[i]);
            }

            _playerAnimation = new Animation[]
            {
                new Animation(_sprite[0], 768 / 6, 128,0.1f),
                new Animation(_sprite[1], 1024 / 8, 128,0.1f),
                new Animation(_sprite[2], 1536 / 12, 128,0.1f),
                new Animation(_sprite[3], 256 / 2, 128,0.1f),
                new Animation(_sprite[4], 768 / 6, 128,0.1f),
                new Animation(_sprite[5], 384 / 2, 128,0.1f),
                new Animation(_sprite[6], 256 / 2, 128,0.1f)
            };
        }

        private float _timeSinceLastStateChange = 0.0f;
        private const float AnimationDuration = 1.0f;
        private GamePadState _previousGamePadState;

        public override void Update(GameTime gameTime)
        {
            _playerRectangle = new Rectangle((int)_position.X, (int)_position.Y, 64, 128);
            _timeSinceLastStateChange += (float)gameTime.ElapsedGameTime.TotalSeconds;
            HandleInput();
            ApplyPhysics((float)gameTime.ElapsedGameTime.TotalSeconds);
            CheckCollisions();
        }

        private void HandleInput()
        {
            var gamePadState = GamePad.GetState(PlayerIndex.One);
            if (!gamePadState.IsConnected) return;

            float speed = 200.0f; // Adjusted speed for quicker movement
            float deadzone = 0.25f; // Increased deadzone for more deliberate movements
            float deltaX = gamePadState.ThumbSticks.Left.X * speed;

            if (Math.Abs(deltaX) > deadzone)
            {
                _position.X += deltaX * 0.02f; // Ensures frame rate independence
                _facingRight = deltaX > 0;
                if (!_currentState.Equals(_state.attack) && !_currentState.Equals(_state.jump))
                {
                    _currentState = _state.walk;
                }
            }
            else if (!gamePadState.Buttons.X.Equals(ButtonState.Pressed) && !_isOnGround)
            {
                _currentState = _state.idle;
            }

            if (gamePadState.Buttons.X.Equals(ButtonState.Pressed) && _timeSinceLastStateChange >= AnimationDuration)
            {
                _currentState = _state.attack;
                _timeSinceLastStateChange = 0f;
            }

            if (gamePadState.Buttons.A.Equals(ButtonState.Pressed) && _isOnGround)
            {
                _velocity.Y = JumpStrength;
                _currentState = _state.jump;
                _isOnGround = false;
                _timeSinceLastStateChange = 0f;
            }

            if (Math.Abs(deltaX) <= deadzone && !_currentState.Equals(_state.jump) && !_currentState.Equals(_state.attack))
            {
                _currentState = _state.idle;
            }
        }

        private void ApplyPhysics(float deltaTime)
        {
            if (!_isOnGround)
            {
                _velocity.Y += Gravity * deltaTime;
            }

            _position+= _velocity * deltaTime; // Update position based on velocity

            // Ground check
            if (_isOnGround)
            {
                _velocity.Y = 0; // Stop falling when on the ground
            }
        }

        private void CheckCollisions()
        {
            _isOnGround = false; // Assume player is not on the ground until proven otherwise

            foreach (var rect in _collisionManager.CollisionRectangles)
            {
                if (_playerRectangle.Intersects(rect))
                {
                    _isOnGround = true; // Player has landed on the ground
                    _position.Y = rect.Top - _playerRectangle.Height; // Adjust Y position to land on the surface
                    _velocity.Y = 0; // Reset Y velocity
                    break; // Exit loop after finding ground collision
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            // Draw the current animation frame. Adjust parameters as necessary.
            if (_playerAnimation != null)
            {
                _playerAnimation[(int)_currentState].Draw(_facingRight, _position, gameTime,1.0f);
            }
        }
        
        // Properties
        public Vector2 Position
        {
            get { return _position; }
        }
    }
}


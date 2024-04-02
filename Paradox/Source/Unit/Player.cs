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
        
        private bool isAlive = true;

        // Status point
        private int _hp = 0;
        private bool _facingRight = true;
        private bool _isOnGround;
        private const float Gravity = 1000.0f;
        private const float JumpStrength = -500.0f;
        private CollisionManager _collisionManager;

        private float _timeSinceLastStateChange = 0.0f;
        private const float AnimationDuration = 1.0f;
        private GamePadState _previousGamePadState;

        public Player()
        {
            //_position.X = 5191;
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
                new Animation(_sprite[0], 768 / 6, 128, 0.5f),
                new Animation(_sprite[1], 1024 / 8, 128, 0.1f),
                new Animation(_sprite[2], 1536 / 12, 128, 0.05f),
                new Animation(_sprite[3], 256 / 2, 128, 0.05f),
                new Animation(_sprite[4], 768 / 6, 128, 0.05f),
                new Animation(_sprite[5], 384 / 3, 128, 0.1f),
                new Animation(_sprite[6], 256 / 2, 128, 0.1f)
            };
        }

        public override void Update(GameTime gameTime)
        {
            _playerRectangle = new Rectangle((int)_position.X, (int)_position.Y, 64, 128);
            
            Singleton.Instance.PlayerCollisionBox = _playerRectangle;
            
            _timeSinceLastStateChange += (float)gameTime.ElapsedGameTime.TotalSeconds;
            HandleInput();
            ApplyPhysics((float)gameTime.ElapsedGameTime.TotalSeconds);
            CheckCollisions();
            
            
            
            
            if (Singleton.Instance.PlayerHP <= 0  || Singleton.Instance.PlayerPos.Y >750)
            {
                Singleton.Instance.PlayerHP = 0;
                _currentState = _state.dead;
                Singleton.Instance.PlayerSpeed = 0;
            }
        }

        private void HandleInput()
        {
            var gamePadState = GamePad.GetState(PlayerIndex.One);
            if (!gamePadState.IsConnected) return;

            float speed = 200.0f;
            float deadzone = 0.25f;
            float deltaX = gamePadState.ThumbSticks.Left.X * speed;

            if (Math.Abs(deltaX) > deadzone)
            {
                _position.X += deltaX * Singleton.Instance.PlayerSpeed;
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
                Attack();
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

        private void Attack()
        {
            // Define the attack range
            Rectangle attackRange = new Rectangle(
                _facingRight ? (int)_position.X + _playerRectangle.Width : (int)_position.X - 100,
                (int)_position.Y,
                100,
                _playerRectangle.Height
            );

            foreach (var enemy in Singleton.Instance.Enemies) // Assuming Singleton.Instance.Enemies holds all enemy instances
            {
                if (attackRange.Intersects(enemy.HitBox)) // Assuming enemy has a public HitBox property
                {
                    enemy.TakeDamage(); // Assuming enemy has a TakeDamage method
                }
            }
        }

        private void ApplyPhysics(float deltaTime)
        {
            if (!_isOnGround)
            {
                _velocity.Y += Gravity * deltaTime;
            }

            _position += _velocity * deltaTime;

            if (_isOnGround)
            {
                _velocity.Y = 0;
            }
        }

        private void CheckCollisions()
        {
            _isOnGround = false;

            foreach (var rect in _collisionManager.CollisionRectangles)
            {
                if (_playerRectangle.Intersects(rect))
                {
                    _isOnGround = true;
                    _position.Y = rect.Top - _playerRectangle.Height;
                    _velocity.Y = 0;
                    break;
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (_playerAnimation != null )
            {
                _playerAnimation[(int)_currentState].Draw(_facingRight, _position, gameTime, 1.0f, Color.White);
            }
        }
        
        
        
        
        //Singleton
        public Vector2 PlayerPos
        {
            get { return _position; }
            set { _position = value; }
        }
        
        // Additional Properties and Methods as needed
    }
}

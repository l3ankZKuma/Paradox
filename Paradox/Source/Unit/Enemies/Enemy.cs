using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;

namespace Paradox
{
    public class Enemy : Entity
    {
        protected enum _enemyState
        {
            Idle,
            Walk,
            Attack
        }

        protected Vector2 _velocity;
        protected string[] PATH;
        protected Animation[] _enemyAnimation;
        protected _enemyState _currentState;
        protected Rectangle _enemyRectangle;
        private bool _isAlive = true;
        protected float _detectionRange = 250f;
        protected float _attackRange = 50f;
        protected Vector2 _patrolFrom;
        protected Vector2 _patrolTo;
        protected float _patrolSpeed = 60f;
        protected bool _patrollingTo = true;
        protected Color _color = Color.White;

        // Color change upon damage
        protected Color _currentColor;
        protected float _colorFadeDuration = 0.5f;
        protected float _currentFadeTime;

        protected CollisionManager _collisionManager;

        protected float _attackCooldown =3.0f;
        protected float _currentAttackCooldown;

        public bool IsAlive => _isAlive;

        public Enemy(Vector2 patrolFrom, Vector2 patrolTo)
        {
            _patrolFrom = patrolFrom;
            _patrolTo = patrolTo;
            Random rd = new Random();
            _hp = rd.Next(7, 10);
            _damage = 0;

            _currentColor = Color.White;
            _currentFadeTime = 0;

            _currentAttackCooldown = _attackCooldown;
        }

        public override void Load()
        {
            _collisionManager = new CollisionManager();
            _currentState = _enemyState.Idle;
            // Initialize animations and other resources here
        }

        public override void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_currentAttackCooldown > 0)
            {
                _currentAttackCooldown -= deltaTime;
            }

            if (_currentFadeTime > 0)
            {
                _currentFadeTime -= deltaTime;
                float fadeAmount = _currentFadeTime / _colorFadeDuration;
                _currentColor = Color.Lerp(Color.White, Color.Red, fadeAmount);
            }

            switch (_currentState)
            {
                case _enemyState.Idle:
                    UpdateIdleState(deltaTime);
                    break;
                case _enemyState.Walk:
                    UpdateWalkState(deltaTime);
                    break;
                case _enemyState.Attack:
                    UpdateAttackState(deltaTime);
                    break;
            }

            // Gravity and collision logic can be implemented here
            _enemyRectangle = new Rectangle((int)_position.X, (int)_position.Y, 128, 64);
        }

         protected void UpdateIdleState(float deltaTime)
        {
            // Checks if the player is within detection range to switch to Walk state
            if (Vector2.Distance(_position, Singleton.Instance.PlayerPos) <= _detectionRange)
            {
                _currentState = _enemyState.Walk;
            }
            else
            {
                // Simple patrol logic when idle
                if (_patrollingTo)
                {
                    if (_position.X < _patrolTo.X)
                    {
                        _position.X += _patrolSpeed * deltaTime;
                        _isFacingRight = true; // Assuming this indicates direction for animation
                    }
                    else
                    {
                        _patrollingTo = false;
                    }
                }
                else
                {
                    if (_position.X > _patrolFrom.X)
                    {
                        _position.X -= _patrolSpeed * deltaTime;
                        _isFacingRight = false;
                    }
                    else
                    {
                        _patrollingTo = true;
                    }
                }
            }
        }

        protected void UpdateWalkState(float deltaTime)
        {
            // Calculates distance to player and adjusts state accordingly
            float distanceToPlayer = Vector2.Distance(_position, Singleton.Instance.PlayerPos);
            if (distanceToPlayer > _detectionRange)
            {
                _currentState = _enemyState.Idle;
            }
            else if (distanceToPlayer <= _attackRange)
            {
                _currentState = _enemyState.Attack;
            }
            else
            {
                // Move towards the player along the X-axis only
                Vector2 direction = Vector2.Normalize(Singleton.Instance.PlayerPos - _position);
                _position.X += direction.X * _patrolSpeed * deltaTime;
                _isFacingRight = direction.X > 0;
            }
        }
        protected void UpdateAttackState(float deltaTime)
        {
            if (Vector2.Distance(_position, Singleton.Instance.PlayerPos) <= _attackRange)
            {
                if (_currentAttackCooldown <= 0)
                {
                    Singleton.Instance.PlayerHP -= _damage;
                    _currentAttackCooldown = _attackCooldown;
                }
            }
            else
            {
                _currentState = _enemyState.Walk;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (_enemyAnimation != null && _isAlive)
            {
                _enemyAnimation[(int)_currentState].Draw(_isFacingRight, _position, gameTime, 1.0f, _currentColor);
            }
        }

        public void TakeDamage()
        {
            _hp -= Singleton.Instance.PlayerAtk;
            if (_hp <= 0)
            {
                _isAlive = false;
            }
            _currentColor = Color.Red;
            _currentFadeTime = _colorFadeDuration;
        }

        public Rectangle HitBox => _enemyRectangle;
        
        
        //gravity
        // private void ApplyPhysics(float deltaTime)
        // {
        //     if (!_isOnGround)
        //     {
        //         _velocity.Y += Gravity * deltaTime;
        //     }
        //     else
        //     {
        //         _velocity.Y = 0;
        //     }
        // }
    }
}

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

        // Adding more properties for AI behavior
        protected Player _player; // Assuming there's a Player class to interact with
        protected float _detectionRange = 250f; // Range within which enemy detects the player
        protected float _attackRange = 50f; // Range within which enemy can attack
        protected Vector2 _patrolFrom;
        protected Vector2 _patrolTo;
        protected float _patrolSpeed = 60f;
        protected bool _patrollingTo = true; // Direction of patrol

        // Physics
        protected bool _isOnGround;
        protected const float Gravity = 200.0f;
        protected const float JumpStrength = -200.0f;
        protected CollisionManager _collisionManager;

        public Enemy(Vector2 patrolFrom, Vector2 patrolTo)
        {
            _patrolFrom = patrolFrom;
            _patrolTo = patrolTo;
        }

        public override void Load()
        {
            _collisionManager = new CollisionManager();
            _currentState = _enemyState.Idle;
            // Initialize animations and other loading logic here
        }

        public override void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

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

            // Basic gravity implementation
            _velocity.Y += Gravity * deltaTime;
            _position += _velocity * deltaTime;
            _enemyRectangle = new Rectangle((int)_position.X, (int)_position.Y, 128,128); // Assuming _texture represents current sprite

            // Implement collision detection with the ground here to update _isOnGround
        }

        protected void UpdateIdleState(float deltaTime)
        {
            if (Vector2.Distance(_position, _player.Position) <= _detectionRange)
            {
                _currentState = _enemyState.Walk;
            }
            else
            {
                // Simple patrol logic when idle
                if (_patrollingTo)
                {
                    if (_position.X < _patrolTo.X)
                        _position.X += _patrolSpeed * deltaTime;
                    else
                        _patrollingTo = false;
                }
                else
                {
                    if (_position.X > _patrolFrom.X)
                        _position.X -= _patrolSpeed * deltaTime;
                    else
                        _patrollingTo = true;
                }
            }
        }

        protected void UpdateWalkState(float deltaTime)
        {
            if (Vector2.Distance(_position, _player.Position) > _detectionRange)
            {
                _currentState = _enemyState.Idle;
            }
            else if (Vector2.Distance(_position, _player.Position) <= _attackRange)
            {
                _currentState = _enemyState.Attack;
            }
            else
            {
                // Move towards player
                Vector2 direction = Vector2.Normalize(_player.Position - _position);
                _position += direction * _patrolSpeed * deltaTime;
            }
        }

        protected void UpdateAttackState(float deltaTime)
        {
            // Implement attack logic here, could be an animation trigger and damage logic
            if (Vector2.Distance(_position, _player.Position) > _attackRange)
            {
                _currentState = _enemyState.Walk;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (_enemyAnimation != null && _enemyAnimation[(int)_currentState] != null)
            {
                
                _enemyAnimation[(int)_currentState].Draw(_position, gameTime);
            }
        }

    }
}

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
        protected float _detectionRange = 250f; // Range within which enemy detects the player
        protected float _attackRange = 50f; // Range within which enemy can attack
        protected Vector2 _patrolFrom;
        protected Vector2 _patrolTo;
        protected float _patrolSpeed = 60f;
        protected bool _patrollingTo = true; // Direction of patrol

        protected CollisionManager _collisionManager;
        
        //cooldown
        protected float _attackCooldown = 2.5f; // Time between attacks
        protected float _currentAttackCooldown;

        public Enemy(Vector2 patrolFrom, Vector2 patrolTo)
        {
            rd = new();
            
            _patrolFrom = patrolFrom;
            _patrolTo = patrolTo;
            
            
            //generate hp
            _hp = rd.Next(3,5);
            _damage = rd.Next(1,3);
            
            
            //Cool down
            _currentAttackCooldown = 2.5f;
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
            
            if (_currentAttackCooldown > 0)
            {
                _currentAttackCooldown -= deltaTime;
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

            // Basic gravity implementation
            _enemyRectangle = new Rectangle((int)_position.X, (int)_position.Y, 128,64); // Assuming _texture represents current sprite

            // Implement collision detection with the ground here to update _isOnGround
        }

        protected void UpdateIdleState(float deltaTime)
        {
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
                        _isFacingRight = true; // Facing towards patrolTo
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
                        _isFacingRight = false; // Facing towards patrolFrom
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
                Vector2 direction = Vector2.Normalize(Singleton.Instance.PlayerPos - _position);
                _position.X += direction.X * _patrolSpeed * deltaTime;

                // Update facing direction based on player's position
                _isFacingRight = direction.X > 0;
            }
        }



        protected void UpdateAttackState(float deltaTime)
        {
            float distanceToPlayer = Vector2.Distance(_position, Singleton.Instance.PlayerPos);

            // Check if the player is still within attack range
            if (distanceToPlayer <= _attackRange)
            {
                if (_currentAttackCooldown <= 0)
                {
                    // Attack logic
                    Singleton.Instance.PlayerHP -= _damage;

                    // Reset cooldown timer
                    _currentAttackCooldown = _attackCooldown;
                }
            }
            else
            {
                // If the player has moved out of attack range, switch back to walking state to follow the player
                _currentState = _enemyState.Walk;
            }
        }


        public override void Draw(GameTime gameTime)
        {
            //I want handel null
            if (_enemyAnimation != null)
            {
                _enemyAnimation[(int)_currentState].Draw(_isFacingRight,_position,gameTime,1.0f);
            }
        }

    }
}

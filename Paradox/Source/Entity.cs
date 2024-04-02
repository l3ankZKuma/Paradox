using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Paradox
{
    public abstract class Entity
    {
        protected enum _state
        {
            idle,
            walk,
            jump,
            shield,
            attack,
            dead,
            hurt
        }
        
        protected Texture2D[] _sprite;
        protected Vector2 _position;

        
        protected Random rd;
        protected int _hp;
        protected int _damage;

        protected bool _isOnGround = true;
        protected bool _isFacingRight=true;
        
        
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
        
        public abstract void Load();

    }
}
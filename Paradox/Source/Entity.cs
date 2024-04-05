using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Paradox
{
    // The Entity class is an abstract base class for all game entities
    public abstract class Entity
    {
        // Enum for the different states an entity can be in
        protected enum _state
        {
            idle,   // The entity is idle
            walk,   // The entity is walking
            jump,   // The entity is jumping
            shield, // The entity is shielding
            attack, // The entity is attacking
            dead,   // The entity is dead
            hurt    // The entity is hurt
        }
        
        // Array of sprites for the entity
        protected Texture2D[] _sprite;
        // Position of the entity
        protected Vector2 _position;

        // Random number generator
        protected Random rd;
        // Health points of the entity
        protected int _hp;
        // Damage the entity can cause
        protected int _damage;

        // Boolean to check if the entity is on the ground
        protected bool _isOnGround = true;
        // Boolean to check if the entity is facing right
        protected bool _isFacingRight = true;
        
        // Abstract method to update the entity
        public abstract void Update(GameTime gameTime);
        // Abstract method to draw the entity
        public abstract void Draw(GameTime gameTime);
        
        // Abstract method to load the entity
        public abstract void Load();
    }
}
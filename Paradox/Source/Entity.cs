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
        
        
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);

        public abstract void Load();

    }
}
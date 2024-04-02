using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace Paradox
{
    public abstract class Items
    {
        protected Vector2 _position;
        
        protected bool _isCollected=false;
        
        protected Animation _animation;
        protected Texture2D _sprite;
        
        public abstract void Load();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
    }
}

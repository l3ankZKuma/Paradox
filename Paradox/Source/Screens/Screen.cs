using Microsoft.Xna.Framework;

namespace Paradox
{
    public abstract class Screen
    {
        public abstract void Load();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
    }
}


using Microsoft.Xna.Framework;

namespace Paradox
{
    public interface IController
    {
        void Update(GameTime gameTime, Player player);
    }
}

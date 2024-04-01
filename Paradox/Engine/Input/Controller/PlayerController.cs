using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Paradox
{
    public class PlayerController : IController
    {
        private float _speed = 200f; // Movement speed
        private float _jumpStrength = 350f; // Jump strength

        public void Update(GameTime gameTime, Player player)
        {
            var gamePadState = GamePad.GetState(PlayerIndex.One);
            var thumbstick = gamePadState.ThumbSticks.Left;
            var velocity = new Vector2(thumbstick.X, -thumbstick.Y) * _speed; // Y inverted due to MonoGame's coordinate system

            // Apply movement based on left thumbstick
            //player.Position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

        }
    }
}
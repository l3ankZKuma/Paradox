using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;



namespace Paradox
{

    public class Button
    {
        public Texture2D Texture { get; private set; }
        public Vector2 Position { get; set; }
        private Rectangle bounds;

        public event Action Clicked;

        public Button(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
            bounds = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public void Update(MouseState currentMouseState, MouseState previousMouseState)
        {
            if (bounds.Contains(currentMouseState.Position))
            {
                if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
                {
                    Clicked?.Invoke();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }

}
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Paradox
{
    public class Animation
    {
        private Texture2D _spriteSheet;
        private int _frames;
        private int _currentFrame;
        private float _frameWidth;
        private float _frameHeight;

        private float _timePerFrame; // Time per frame in seconds
        private float _timer; // Accumulates elapsed time

        public Animation(Texture2D spriteSheet, float frameWidth, float frameHeight , float animationSpeed = 0.1f)
        {
            _spriteSheet = spriteSheet;
            _frameWidth = frameWidth;
            _frameHeight = frameHeight;
            _frames = (int)(_spriteSheet.Width / frameWidth);
            _currentFrame = 0;

            // Set the time each frame is displayed
            _timePerFrame = animationSpeed; // Adjust this value to make the animation faster or slower
            _timer = 0;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(Vector2 position,GameTime gameTime)
        {
            // Increment the timer by the elapsed game time
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Check if the timer exceeds the time per frame
            if (_timer >= _timePerFrame)
            {
                _currentFrame++; // Move to the next frame
                _timer = 0; // Reset the timer

                // Reset the frame index if it exceeds the number of frames
                if (_currentFrame >= _frames)
                {
                    _currentFrame = 0;
                }
            }
            
            // Calculate the source rectangle of the current frame
            var rect = new Rectangle((int)(_frameWidth * _currentFrame), 0, (int)_frameWidth, (int)_frameHeight);

            // Draw the current frame
            Singleton.Instance.SpriteBatch.Draw(_spriteSheet, position, rect, Color.White);
        }
    }
}
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Code references : https://github.com/PePoDev/egypt-bubble/blob/master/Screen/SplashScreen.cs
namespace Paradox
{
    public class TitleScreen : Screen
    {
        private Texture2D _titleScreen;
        private Vector2 _titleScreenPosition;
        private float _timer;
        private float _timerMax = 3f;
        private bool _isTimerFinished;
        public TitleScreen()
        {
            _titleScreenPosition = new Vector2(0, 0);
            _timer = 0;
            _isTimerFinished = false;
        }
        public override void Load()
        {
            
        }
        public override void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_timer >= _timerMax)
            {
                _isTimerFinished = true;
            }
        }
        public override void Draw(GameTime gameTime)
        {
            Singleton.Instance.SpriteBatch.Begin();
            
            
            Singleton.Instance.SpriteBatch.Draw(_titleScreen, _titleScreenPosition, Color.White);
            
            
            Singleton.Instance.SpriteBatch.End();
        }
        public bool IsTimerFinished()
        {
            return _isTimerFinished;
        }
    }
}
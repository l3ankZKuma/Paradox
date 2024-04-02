using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;


namespace Paradox
{
    
    public class Coin : Items
    {
        
        SoundEffect _coinSound;
        
        public Coin(Vector2 POS)
        {
            _position = POS;
            _sprite= Singleton.Instance.Content.Load<Texture2D>("Items/coin_b");
            _coinSound = Singleton.Instance.Content.Load<SoundEffect>("SoundEffect/Coin");
        }


        public override void Load()
        {
            _animation = new Animation(_sprite, 256/8, 32, 0.1f);
        }


        public override void Update(GameTime gameTime)
        {
            if (!_isCollected)
            {
                if (Singleton.Instance.PlayerCollisionBox.Intersects(new Rectangle((int)_position.X, (int)_position.Y, 32, 32)))
                {
                    _coinSound.Play();
                    Singleton.Instance.PlayerCoin++;
                    _isCollected = true;
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (!_isCollected)
            {
                _animation.Draw(true, _position, gameTime, 1.0f, Color.White);
            }
            
        }
        
        
    }
}
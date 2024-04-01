using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Paradox
{
    
    public class Coin : Items
    {
        
        
        
        public Coin(Vector2 POS)
        {
            _position = POS;
            _sprite= Singleton.Instance.Content.Load<Texture2D>("Items/coin_b");
        }


        public override void Load()
        {
            _animation = new Animation(_sprite, 256/8, 32, 0.1f);
        }


        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(GameTime gameTime)
        {
            if (!_isCollected)
            {
                _animation.Draw(true, _position, gameTime, 1.0f);
            }
            
        }
        
        
    }
}
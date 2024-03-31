using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace Paradox
{
    public class HP
    {
        private Texture2D _sprite;
        private Animation _animation;
        
        
        public HP()
        {
            _sprite = Singleton.Instance.Content.Load<Texture2D>("Items/heart_b");
        }


        public void Load()
        {

            _animation = new Animation(_sprite, 193/6, 32, 0.5f);


        }


        public void Update()
        {
            
            
        }
        
        public void Draw(GameTime gameTime)
        {
            for(int i=0;i<Singleton.Instance.PlayerHP;i++)
            {
                _animation.Draw(true, new Vector2(10 + i * 32, 10), gameTime, 1.0f);
                
                
            }
            
        }
    }
}


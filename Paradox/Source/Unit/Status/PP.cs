using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace Paradox
{
    public class PP
    {
        private Texture2D _sprite;
        private Animation _animation;
        
        
        public PP()
        {
            _sprite = Singleton.Instance.Content.Load<Texture2D>("Items/star_b");
        }


        public void Load()
        {

            _animation = new Animation(_sprite, 256/8, 33, 0.5f);


        }


        public void Update()
        {
            
            
        }
        
        public void Draw(GameTime gameTime)
        {
            for(int i=0;i<Singleton.Instance.PlayerPP;i++)
            {
                _animation.Draw(true, new Vector2(10 + i * 40, 50), gameTime, 1.5f);
                
                
            }
            
        }
    }
}
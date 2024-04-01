using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Paradox
{
    public class Merchant : Entity
    {
        private Animation _merchantAnimation;
        private Texture2D _sprite;
        private Vector2 _position;
        
        
        public Merchant(Vector2 position)
        {
            _position = position;
            _sprite = Singleton.Instance.Content.Load<Texture2D>("NPC/Merchant");
        }
        

        public override void Load()
        {
            _merchantAnimation = new Animation(_sprite, 512/4, 128, 0.1f);
        }

        public override void Update(GameTime gameTime)
        {
            
        }
        
        public override void Draw(GameTime gametime)
        {
            _merchantAnimation.Draw(true,_position,gametime,0.75f);
        }
    }
}
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Paradox
{
    class Enemy_2 : Enemy
    {

        public Enemy_2(Vector2 patrolFrom, Vector2 patrolTo) : base(patrolFrom,patrolTo)
        {
            PATH = new string[]
            {
                "2/Walk_2", "2/Walk_2","2/Attack_2 "
            };
            _position=patrolFrom;
            
        }
        
        public override void Load()
        {
            
            
            //From entity
            _sprite= new Texture2D[PATH.Length];
            
            for (int i = 0; i < PATH.Length; i++)
            {
                _sprite[i] = Singleton.Instance.Content.Load<Texture2D>(PATH[i]);
            }
            
            _enemyAnimation = new Animation[]
            {
                new Animation(_sprite[0], 128, 128),
                new Animation(_sprite[1], 128, 128),
                new Animation(_sprite[2], 128, 128),
            };
            
            
        }
        
        public override void Update(GameTime gameTime)
        {
            _enemyRectangle = new Rectangle((int)_position.X, (int)_position.Y, 128, 128);
            
            base.Update(gameTime);
        }
        

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
        
        
    }
}
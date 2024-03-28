using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Paradox
{
    class Enemy_4 : Enemy
    {

        public Enemy_4(Vector2 patrolFrom, Vector2 patrolTo) : base(patrolFrom,patrolTo)
        {
            PATH = new string[]
            {
                "4/Walk_4", "4/Walk_4","4/Attack_4"
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
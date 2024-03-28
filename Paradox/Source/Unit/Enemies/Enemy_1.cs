using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Paradox
{
    class Enemy_1 : Enemy
    {

        public Enemy_1(Vector2 patrolFrom, Vector2 patrolTo) : base(patrolFrom,patrolTo)
        {
            PATH = new string[]
            {
                "1/Idle", "1/Walk"
            };
            
        }
        
        public override void Load()
        {
            //From entity
            _sprite= new Texture2D[PATH.Length];
            
            for (int i = 0; i < PATH.Length; i++)
            {
                _sprite[i] = Singleton.Instance.Content.Load<Texture2D>(PATH[i]);
            }
            
            
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
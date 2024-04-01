using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace Paradox
{
    
    
    public class UI
    {
        private HP _hp;
        private PP _pp;
        
        
        public UI()
        {
            _hp = new();
            _pp = new();
        }
        
        
        public void Load()
        {
            _hp.Load();
            _pp.Load();
        }
    
        public void Update()
        {
            _hp.Update();
            _pp.Update();
        }

        public void Draw(GameTime gameTime)
        {
            _hp.Draw(gameTime);
            _pp.Draw(gameTime);
        }
    }
    
}


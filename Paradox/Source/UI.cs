using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace Paradox
{
    
    
    public class UI
    {
        private HP _hp;
        
        
        public UI()
        {
            _hp = new();
        }
        
        
        public void Load()
        {
            _hp.Load();
        }
    
        public void Update()
        {
            _hp.Update();
        }

        public void Draw(GameTime gameTime)
        {
            _hp.Draw(gameTime);
        }
    }
    
}


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace Paradox
{
    
    
    public class UI
    {
        private HP _hp;
        private Texture2D _deathScreen;
        private Upgrade _upgrade;
        //private PP _pp;
        
        
        public UI()
        {
            _deathScreen = Singleton.Instance.Content.Load<Texture2D>("Unit/Player/Samurai/Death_screen");
            _hp = new();
            _upgrade = new();
            //_pp = new();
        }
        
        
        public void Load()
        {
            _deathScreen = Singleton.Instance.Content.Load<Texture2D>("Unit/Player/Samurai/Death_screen");
            _hp.Load();
            _upgrade.Load();
            //_pp.Load();
        }
    
        public void Update()
        {
            _hp.Update();
            _upgrade.Update();
            //_pp.Update();
        }

        public void Draw(GameTime gameTime)
        {
            _hp.Draw(gameTime);
            _upgrade.Draw();
            if(Singleton.Instance.PlayerHP <= 0 /*|| Singleton.Instance.PlayerPos.Y >750*/)
            {
                Singleton.Instance.SpriteBatch.Draw(_deathScreen, new Rectangle(1280/2-250, 720/2-250, 500, 500), Color.White);

            }
            
            //_pp.Draw(gameTime);
        }
    }
    
}


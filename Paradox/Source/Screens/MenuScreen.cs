using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;




namespace Paradox
{
    public class MenuScreen : Screen
    {
        
        //BG
        private Texture2D _background;
        
        
        
        //button
        private Texture2D playButton,quitButton,settingsButton;
        private Vector2 playButtonPosition, quitButtonPosition, settingsButtonPosition;
        private MouseState previousMouseState;
        
 
        public MenuScreen()
        {
            
            
        
        }
 
        public override void Load()
        {

            _background=Singleton.Instance.Content.Load<Texture2D>("Menu/Menu_BG_rz ");



        }
    
        public override void Update(GameTime gameTime)
        {
        
        }
        
        public override void Draw(GameTime gameTime)
        {
            Singleton.Instance.SpriteBatch.Begin();
            
            Singleton.Instance.SpriteBatch.Draw(_background, new Vector2(0, 0), Color.White);
            
            
            Singleton.Instance.SpriteBatch.End();
        
        }
    
    }
}


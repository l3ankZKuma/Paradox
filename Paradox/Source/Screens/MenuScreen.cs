using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;




namespace Paradox
{
    public class MenuScreen : Screen
    {
        
        //BG
        private Texture2D _background;
        private MouseState _mouseState;
        
        
        
        //button
        private Texture2D _playButton,_optionButton,_exitButton;
        private Vector2 playButtonPosition, quitButtonPosition, settingsButtonPosition;
        private MouseState previousMouseState;
        
        
        //check
        private bool _isMainScreen;
        
        
 
        public MenuScreen()
        {
        
        }
 
        public override void Load()
        {

            _background=Singleton.Instance.Content.Load<Texture2D>("Menu/Menu_BG3");
            _playButton = Singleton.Instance.Content.Load<Texture2D>("Menu/Menu_BG_Start");
            _optionButton = Singleton.Instance.Content.Load<Texture2D>("Menu/Menu_BG_Option");
            _exitButton = Singleton.Instance.Content.Load<Texture2D>("Menu/Menu_BG_Exit");



        }
    
        public override void Update(GameTime gameTime)
        {
            Singleton.Instance.MouseState = Mouse.GetState();
            
        }
        
        public override void Draw(GameTime gameTime)
        {
            Singleton.Instance.SpriteBatch.Begin();
            
            Singleton.Instance.SpriteBatch.Draw(_background, new Vector2(0, 0), Color.White);
            
            
            Singleton.Instance.SpriteBatch.End();
        
        }
    
    }
}


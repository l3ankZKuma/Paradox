using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Paradox
{
    public class ScreenManager
    {

        //Create enum state
        public enum GameScreenName
        {
            MenuScreen,
            PlayScreen,
            PauseScreen,
            ExitScreen,
            DeadScreen
        }
        private Screen _currentGameScreen;

        public ScreenManager()
        {
            _currentGameScreen = new MenuScreen();
        }
        public void LoadScreen(GameScreenName _ScreenName)
        {
            switch (_ScreenName)
            {
                
                case GameScreenName.MenuScreen:
                    _currentGameScreen = new MenuScreen();
                    break;
                case GameScreenName.PlayScreen:
                    _currentGameScreen = new PlayScreen();
                    break;
                case GameScreenName.PauseScreen:
                    _currentGameScreen = new PauseScreen();
                    break;
                
                case GameScreenName.DeadScreen:
                    _currentGameScreen = new DeadScreen();
                    break;
                
            }
            _currentGameScreen.Load();
        }

        public void Load()
        {
            _currentGameScreen.Load();
        }
        
        public void Update(GameTime gameTime)
        {
            
            _currentGameScreen.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            _currentGameScreen.Draw(gameTime);
        }
        

    }
}
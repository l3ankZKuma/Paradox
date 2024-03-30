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
            PlayScreen
        }
        private Screen _currentGameScreen;

        public ScreenManager()
        {
            _currentGameScreen = new PlayScreen();
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
        private static ScreenManager instance;
        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScreenManager();
                return instance;
            }
        }
    }
}
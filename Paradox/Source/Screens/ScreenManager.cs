using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

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
                    MediaPlayer.Stop();
                    _currentGameScreen = new MenuScreen();
                    break;
                case GameScreenName.PlayScreen:
                    //i want to close old song
                    MediaPlayer.Stop();
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
        

    }
}
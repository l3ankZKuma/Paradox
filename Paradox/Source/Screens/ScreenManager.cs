using Microsoft.Xna.Framework;


namespace Paradox;

public class ScreenManager
{
    private Screen _screen;

    public ScreenManager()
    {
        _screen = new MenuScreen();

    }

    public void Load()
    {
        
        _screen.Load();


    }

    public void Update(GameTime gameTime)
    {
        _screen.Update(gameTime);
    }

    public void Draw(GameTime gameTime)
    {
        _screen.Draw(gameTime);
    }

}
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Paradox;

public class ScreenManager
{
    private Stack<Screen> _screens = new Stack<Screen>();

    public ScreenManager()
    {
        _screens = new Stack<Screen>();
    }
    public void ChangeScreen(Screen screen)
    {
        if (_screens.Count > 0)
        {
            _screens.Peek().OnExit();
            _screens.Pop();
        }

        _screens.Push(screen);
        screen.OnEnter();
        screen.Load();
    }

    public void PushScreen(Screen screen)
    {
        if (_screens.Count > 0)
        {
            _screens.Peek().OnExit();
        }

        _screens.Push(screen);
        screen.OnEnter();
        screen.Load();
    }

    public void PopScreen()
    {
        if (_screens.Count > 0)
        {
            _screens.Peek().OnExit();
            _screens.Pop();
        }

        if (_screens.Count > 0)
        {
            _screens.Peek().OnEnter();
        }
    }

    public void Update(GameTime gameTime)
    {
        if (_screens.Count > 0)
        {
            _screens.Peek().Update(gameTime);
        }
    }

    public void Draw(GameTime gameTime)
    {
        if (_screens.Count > 0)
        {
            _screens.Peek().Draw(gameTime);
        }
    }

}
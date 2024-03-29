// Base class remains mostly unchanged, consider adding OnEnter and OnExit for initialization and cleanup.

using Microsoft.Xna.Framework;

namespace Paradox;

public abstract class Screen
{
    public virtual void OnEnter()
    {
        
    }

    public virtual void OnExit()
    {
        
    }

    public abstract void Load();
    public abstract void Update(GameTime gameTime);
    public abstract void Draw(GameTime gameTime);
}
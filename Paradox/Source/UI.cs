using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Paradox
{
    // The UI class manages the user interface elements of the game
    public class UI
    {
        // Declare variables for the health points, death screen texture, and upgrade system
        private HP _hp;
        private Texture2D _deathScreen;
        private Upgrade _upgrade;
        //private PP _pp; // This line is commented out, it seems to be a placeholder for a future feature

        // Constructor for the UI class
        public UI()
        {
            // Load the death screen texture and initialize the health points and upgrade system
            _deathScreen = Singleton.Instance.Content.Load<Texture2D>("Unit/Player/Samurai/Death_screen");
            _hp = new();
            _upgrade = new();
            //_pp = new(); // This line is commented out, it seems to be a placeholder for a future feature
        }

        // Load method for the UI class
        public void Load()
        {
            // Load the death screen texture and call the Load methods of the health points and upgrade system
            _deathScreen = Singleton.Instance.Content.Load<Texture2D>("Unit/Player/Samurai/Death_screen");
            _hp.Load();
            _upgrade.Load();
            //_pp.Load(); // This line is commented out, it seems to be a placeholder for a future feature
        }

        // Update method for the UI class
        public void Update()
        {
            // Call the Update methods of the health points and upgrade system
            _hp.Update();
            _upgrade.Update();
            //_pp.Update(); // This line is commented out, it seems to be a placeholder for a future feature
        }

        // Draw method for the UI class
        public void Draw(GameTime gameTime)
        {
            // Call the Draw methods of the health points and upgrade system
            _hp.Draw(gameTime);
            _upgrade.Draw();

            // If the player's health points are 0 or the player's position is below a certain point, draw the death screen
            if(Singleton.Instance.PlayerHP <= 0 || Singleton.Instance.PlayerPos.Y >750)
            {
                Singleton.Instance.SpriteBatch.Draw(_deathScreen, new Rectangle(1280/2-250, 720/2-250, 500, 500), Color.White);
            }

            //_pp.Draw(gameTime); // This line is commented out, it seems to be a placeholder for a future feature
        }
    }
}
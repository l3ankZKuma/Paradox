using System;
using System.Collections.Generic; // Use Generic Collections
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Paradox
{
    public class Upgrade
    {
        private Dictionary<string, Texture2D> _textures; // Use Dictionary instead of Hashtable
        private string _key;

        public Upgrade()
        {
            _textures = new Dictionary<string, Texture2D>();
            _key = "";
        }

        public void Load()
        {
            _textures.Add("Upgrade", Singleton.Instance.Content.Load<Texture2D>("Upgrade/Upgrade")); // Use _key instead of "Upgrade"
            _textures.Add("Upgrade_atk", Singleton.Instance.Content.Load<Texture2D>("Upgrade/Upgrade_atk")); // Use _key instead of "Upgrade"
            _textures.Add("Upgrade_spd", Singleton.Instance.Content.Load<Texture2D>("Upgrade/Upgrade_spd")); // Use _key instead of "Upgrade"
        }

        public void Update()
        {
            var mouseState = Mouse.GetState();
            var gamePadState = GamePad.GetState(PlayerIndex.One); // Assuming player one's controller
            // Console.WriteLine(mouseState.X + " " + mouseState.Y);
            Console.WriteLine(Singleton.Instance.PlayerPos.X + " " + Singleton.Instance.PlayerPos.Y);

            // Check if within upgrade area and either mouse clicked or Y button pressed
            if ((Singleton.Instance.PlayerPos.X >= 1659 && Singleton.Instance.PlayerPos.X <= 1756 && Singleton.Instance.PlayerPos.Y >= 277 && Singleton.Instance.PlayerPos.Y <= 300) )
            {
                if (mouseState.X >= 503 && mouseState.X <= 503 + 274 && mouseState.Y >= 284 && mouseState.Y <= 284 + 74)
                {
                    _key = "Upgrade_atk";
                    // Check for mouse release or gamepad Y button press for the upgrade action
                    if (mouseState.LeftButton == ButtonState.Released || gamePadState.Buttons.Y == ButtonState.Pressed)
                    {
                        Singleton.Instance.PlayerAtk++;
                        Singleton.Instance.PlayerCoin -= 1;
                    }
                }
                else if (mouseState.X >= 503 && mouseState.X <= 503 + 274 && mouseState.Y >= 393 && mouseState.Y <= 393 + 74)
                {
                    _key = "Upgrade_spd";
                    // Check for mouse release or gamepad Y button press for the upgrade action
                    if (mouseState.LeftButton == ButtonState.Released || gamePadState.Buttons.Y == ButtonState.Pressed)
                    {
                        Singleton.Instance.PlayerSpeed += 0.01f;
                        Singleton.Instance.PlayerCoin -= 1;
                    }
                }
                else
                {
                    _key = "Upgrade";
                }
            }
        }

        
        public void Draw() // Added textureKey parameter
        {
            if (_textures.ContainsKey(_key)) // Check if the texture exists
            {
                Singleton.Instance.SpriteBatch.Draw(_textures[_key],new Rectangle(1280/2-250, 720/2-250, 500, 500), Color.White);
            }
        }
    }
}
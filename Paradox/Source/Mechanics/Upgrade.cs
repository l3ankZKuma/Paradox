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
        private MouseState _previousMouseState;

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
            var currentMouseState = Mouse.GetState();
            var gamePadState = GamePad.GetState(PlayerIndex.One); // Assuming player one's controller


            Console.WriteLine(Singleton.Instance.PlayerPos.Y);

            // Check if within upgrade area and either mouse clicked or Y button pressed
            if (Singleton.Instance.PlayerCoin > 0 &&

                ((Singleton.Instance.PlayerPos.X >= 1659 && Singleton.Instance.PlayerPos.X <= 1800) &&
                 (Singleton.Instance.PlayerPos.Y >= 225 && Singleton.Instance.PlayerPos.Y <= 230))

                ||

                ((Singleton.Instance.PlayerPos.X >= 4680 && Singleton.Instance.PlayerPos.X <= 4680 + 128) &&

                 (Singleton.Instance.PlayerPos.Y >= 285 && Singleton.Instance.PlayerPos.Y <= 295))
                
                ||

                ((Singleton.Instance.PlayerPos.X >= 11740 && Singleton.Instance.PlayerPos.X <= 11740 + 128)  &&

                 (Singleton.Instance.PlayerPos.Y >= 320 && Singleton.Instance.PlayerPos.Y <= 327))

               )

            {

                if (currentMouseState.X >= 503 && currentMouseState.X <= 503 + 274 && currentMouseState.Y >= 284 &&
                    currentMouseState.Y <= 284 + 74)
                {
                    _key = "Upgrade_atk";
                    if (_previousMouseState.LeftButton == ButtonState.Pressed &&
                        currentMouseState.LeftButton == ButtonState.Released)
                    {
                        // Increment player attack only on a single click
                        Singleton.Instance.PlayerAtk++;
                    }
                }
                // Check for a single click on the speed upgrade button
                else if (currentMouseState.X >= 503 && currentMouseState.X <= 503 + 274 && currentMouseState.Y >= 393 &&
                         currentMouseState.Y <= 393 + 74)
                {
                    _key = "Upgrade_spd";
                    if (_previousMouseState.LeftButton == ButtonState.Pressed &&
                        currentMouseState.LeftButton == ButtonState.Released)
                    {
                        // Increment player speed only on a single click
                        Singleton.Instance.PlayerSpeed+=0.001f;
                    }
                }
                else
                {
                    _key = "Upgrade";
                }
            }
            else
            {
                _key = "";
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
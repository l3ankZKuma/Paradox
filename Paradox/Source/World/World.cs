using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Paradox
{
    class World
    {
        private Player _player;
        private Map _map;


        public World()
        {
            _player = new Player();
            _map = new Map();
        }

        public void Load()
        {
            // Assuming you have a TMX map named "map.tmx" in your Content folder
            _map.Load();
            _player.Load();
        }

        public void Update(GameTime gameTime)
        {
            _player.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {


            // Draw the player on top of the map
            _map.Draw();
            _player.Draw(gameTime);

        }
        
        
        public Vector2 GetPlayerPosition()
        {
            return _player.Position;
        }

    
    }
}
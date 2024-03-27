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
            _map.Load();
            _player.Load();


        }

        public void Update(GameTime gameTime)
        {
            _player.Update(gameTime);
            
        }

        private void HandlePlayerCollision()
        {
            Console.WriteLine("Player collided with something!");
        }

        public void Draw(GameTime gameTime)
        {
            _map.Draw();
            _player.Draw(gameTime);
        }

        public Vector2 GetPlayerPosition()
        {
            return _player.Position;
        }
    }
}
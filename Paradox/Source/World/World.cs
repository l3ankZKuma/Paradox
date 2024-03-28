using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Paradox
{
    class World
    {
        private Player _player;
        private List<Enemy> _enemies;
        private Map _map;
        

        public World()
        {
            _player = new Player();
            _map = new Map();
            _enemies= new List<Enemy>();
            
            _enemies.Add(new Enemy_1(new Vector2(180,578),new Vector2(250,578)));
        }

        public void Load()
        {
            _map.Load();
            _player.Load();
            
            for(int i=0;i<_enemies.Count;i++)
            {
                _enemies[i].Load();
            }


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
            
            for(int i=0;i<_enemies.Count;i++)
            {
                Console.WriteLine("Draw Enemy");
                _enemies[i].Draw(gameTime);
            }

        }

        public Vector2 GetPlayerPosition()
        {
            return _player.Position;
        }
    }
}
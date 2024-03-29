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
            
            
            addEnemies();

            
        }

        public void Load()
        {
            _map.Load();

            
            for(int i=0;i<_enemies.Count;i++)
            {
                _enemies[i].Load();
            }
            
            
            _player.Load();
            
            


        }

        public void Update(GameTime gameTime)
        {
            for(int i=0;i<_enemies.Count;i++)
            {
                _enemies[i].Update(gameTime);
            }
            
            _player.Update(gameTime);
            

            
        }

        private void HandlePlayerCollision()
        {
            Console.WriteLine("Player collided with something!");
        }

        public void Draw(GameTime gameTime)
        {
            _map.Draw();

            
            
            for(int i=0;i<_enemies.Count;i++)
            {
                _enemies[i].Draw(gameTime);
            }
            
            _player.Draw(gameTime);
            
 

        }

        public void addEnemies()
        {
            _enemies.Add(new Enemy_1(new Vector2(190,578-110),new Vector2(300,578-110)));
            _enemies.Add(new Enemy_2(new Vector2(254,276),new Vector2(270,276)));
            _enemies.Add(new Enemy_3(new Vector2(1000,583-120),new Vector2(1200,583-120)));
            _enemies.Add(new Enemy_4(new Vector2(1600, 482-60), new Vector2(1720, 482-70)));
            
            
            _enemies.Add(new Boss(new Vector2(12200,485),new Vector2(12500,485)));

        }

        public Vector2 GetPlayerPosition()
        {
            return _player.Position;
        }
    }
}
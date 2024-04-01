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
        private List<Items> _items;
        private List<Merchant> _merchants;
        

        public World()
        {
            _player = new Player();
            _map = new Map();
            _enemies= new List<Enemy>();
            _items = new List<Items>();
            _merchants = new List<Merchant>();
            //Ememies position
            addEnemies();
            
            //Items position
            addItems();
            
            
            //NPC position 
            addNPC();
            
        }

        public void Load()
        {
            _map.Load();
            
            //Load NPC
            for(int i=0;i<_merchants.Count;i++)
            {
                _merchants[i].Load();
            }
            
            
            //Load items
            for(int i=0;i<_items.Count;i++)
            {
                _items[i].Load();
            }

            //Load enemies
            for(int i=0;i<_enemies.Count;i++)
            {
                _enemies[i].Load();
            }
            
            
            _player.Load();
            
            


        }

        public void Update(GameTime gameTime)
        {
            Singleton.Instance.PlayerPos = _player.Position;
            
            
            for(int i=0;i<_merchants.Count;i++)
            {
                _merchants[i].Update(gameTime);
            }   
            
            
            
            for(int i=0;i<_enemies.Count;i++)
            {
                _enemies[i].Update(gameTime);
            }
            
            
            _player.Update(gameTime);
            

            
        }


        public void Draw(GameTime gameTime)
        {
            _map.Draw();

            //NPC
            for(int i=0;i<_merchants.Count;i++)
            {
                
                _merchants[i].Draw(gameTime);
                
            }
            
            
            
            //Draw items
            for(int i=0;i<_items.Count;i++)
            {
                
                _items[i].Draw(gameTime);
                
            }
            
            
            
            //Draw enemies
            for(int i=0;i<_enemies.Count;i++)
            {
                
                _enemies[i].Draw(gameTime);
                
            }
            
            
            
            _player.Draw(gameTime);
            
 

        }

        public void addNPC()
        {
            _merchants.Add(new Merchant(new Vector2(1725,270)));
            _merchants.Add(new Merchant(new Vector2(4701,335)));
            _merchants.Add(new Merchant(new Vector2(11750,363)));
        }
        
        
        public void addItems()
        {
            
            _items.Add(new Coin(new Vector2(423,374)));
            _items.Add(new Coin(new Vector2(678,280)));
            _items.Add(new Potion(new Vector2(698,430)));
            _items.Add(new Coin(new Vector2(1667,325)));
            _items.Add(new Potion(new Vector2(2280,420)));
            
        }

        public void addEnemies()
        {
            _enemies.Add(new Enemy_1(new Vector2(190,578-110),new Vector2(300,578-110)));
            _enemies.Add(new Enemy_2(new Vector2(254,276),new Vector2(270,276)));
            _enemies.Add(new Enemy_3(new Vector2(1000,583-120),new Vector2(1200,583-120)));
            _enemies.Add(new Enemy_4(new Vector2(1600, 482-60), new Vector2(1720, 482-70)));
            
            _enemies.Add(new Enemy_1(new Vector2(2047,409-64),new Vector2(2300,409-64)));
            _enemies.Add(new Enemy_2(new Vector2(2500,377-60),new Vector2(3000,377-60)));
            _enemies.Add(new Enemy_3(new Vector2(3470,377-60),new Vector2(3800,377-60)));
            _enemies.Add(new Enemy_4(new Vector2(5490,219-90),new Vector2(5600,219-90)));
            
            _enemies.Add(new Enemy_3(new Vector2(6178,141-64),new Vector2(6300,141-64)));
            _enemies.Add(new Enemy_1(new Vector2(7258,460),new Vector2(7500,460)));
            _enemies.Add(new Enemy_4(new Vector2(8000,492-64),new Vector2(9000,492-64)));
            _enemies.Add(new Enemy_3(new Vector2(9200,492-64),new Vector2(9500,492-64)));
            _enemies.Add(new Enemy_3(new Vector2(11000,456-128),new Vector2(11500,456-128)));
            _enemies.Add(new Enemy_2(new Vector2(10170,590-64),new Vector2(10300,590-64)));
            
            
            
            _enemies.Add(new Boss(new Vector2(12200,485),new Vector2(12500,485)));
        }


    }
}
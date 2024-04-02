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
            Singleton.Instance.Enemies = _enemies;
            
            
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
            Singleton.Instance.PlayerPos = _player.PlayerPos;
            
            //Items
            for(int i=0;i<_items.Count;i++)
            {
                _items[i].Update(gameTime);
            }

            //NPC
            for(int i=0;i<_merchants.Count;i++)
            {
                _merchants[i].Update(gameTime);
            }   
            
            //Enemies
            for (int i = _enemies.Count - 1; i >= 0; i--)
            {
                if (_enemies[i].IsAlive)
                {
                    _enemies[i].Update(gameTime);
                }
                else
                {
                    _enemies.RemoveAt(i);
                }
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
            
            _items.Add(ItemFactory.CreateItem("Coin", new Vector2(423,374)));
            _items.Add(ItemFactory.CreateItem("Coin", new Vector2(678,280)));
            _items.Add(ItemFactory.CreateItem("Potion", new Vector2(698,430)));
            _items.Add(ItemFactory.CreateItem("Coin", new Vector2(1667,325)));
            _items.Add(ItemFactory.CreateItem("Potion", new Vector2(2280,420)));
            _items.Add(ItemFactory.CreateItem("Potion", new Vector2(3275,311)));
            _items.Add(ItemFactory.CreateItem("Potion", new Vector2(5191,312)));
            _items.Add(ItemFactory.CreateItem("Coin", new Vector2(5902,215)));
            _items.Add(ItemFactory.CreateItem("Potion", new Vector2(6674,184)));
            _items.Add(ItemFactory.CreateItem("Coin", new Vector2(4319,435)));
            _items.Add(ItemFactory.CreateItem("Coin", new Vector2(7816,211)));
            _items.Add(ItemFactory.CreateItem("Potion", new Vector2(7900,211)));
            _items.Add(ItemFactory.CreateItem("Coin", new Vector2(10090,229)));
            _items.Add(ItemFactory.CreateItem("Coin", new Vector2(3035,85)));

        }

        private void addEnemies()
        {
            // Create Enemy_2 instances
            _enemies.Add(EnemyFactory.CreateEnemy("Enemy_2", new Vector2(250, 276), new Vector2(270, 276)));
            _enemies.Add(EnemyFactory.CreateEnemy("Enemy_2", new Vector2(2500, 377 - 60), new Vector2(3000, 377 - 60)));
            _enemies.Add(EnemyFactory.CreateEnemy("Enemy_2", new Vector2(10170, 590 - 64), new Vector2(10300, 590 - 64)));

            // Create Enemy_3 instances
            _enemies.Add(EnemyFactory.CreateEnemy("Enemy_3", new Vector2(1000, 583 - 120), new Vector2(1200, 583 - 120)));
            _enemies.Add(EnemyFactory.CreateEnemy("Enemy_3", new Vector2(3470, 377 - 60), new Vector2(3800, 377 - 60)));
            _enemies.Add(EnemyFactory.CreateEnemy("Enemy_3", new Vector2(6178, 141 - 64), new Vector2(6300, 141 - 64)));
            // Additional Enemy_3 instances...
            _enemies.Add(EnemyFactory.CreateEnemy("Enemy_3", new Vector2(9200, 492 - 64), new Vector2(9500, 492 - 64)));
            _enemies.Add(EnemyFactory.CreateEnemy("Enemy_3", new Vector2(11000, 456 - 128), new Vector2(11500, 456 - 128)));

            // Create Enemy_4 instances
            _enemies.Add(EnemyFactory.CreateEnemy("Enemy_4", new Vector2(1600, 482 - 60), new Vector2(1720, 482 - 70)));
            _enemies.Add(EnemyFactory.CreateEnemy("Enemy_4", new Vector2(5490, 219 - 90), new Vector2(5600, 219 - 90)));
            _enemies.Add(EnemyFactory.CreateEnemy("Enemy_4", new Vector2(8000, 492 - 64), new Vector2(9000, 492 - 64)));

            // Create Enemy_1 instances
            _enemies.Add(EnemyFactory.CreateEnemy("Enemy_1", new Vector2(2047, 409 - 64), new Vector2(2000, 409 - 64)));
            _enemies.Add(EnemyFactory.CreateEnemy("Enemy_1", new Vector2(7258, 460), new Vector2(7500, 460)));

            // Add the Boss instance
            _enemies.Add(EnemyFactory.CreateEnemy("Boss", new Vector2(12200, 485), new Vector2(12500, 485)));
        }


    }
}
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Paradox
{
    
    class World
    {
        private Player _player;


        
        
        public World()
        {

            
            _player = new Player();
        }
        
        public void Load()
        {
            _player.Load();
        }
        
        
        public void Update(GameTime gameTime)
        {
            _player.Update( gameTime);
        }
        
        
        public void Draw(GameTime gameTime)
        {
            _player.Draw( gameTime);
        }
        
        
    }
}
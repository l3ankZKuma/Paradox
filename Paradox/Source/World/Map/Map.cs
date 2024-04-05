using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Paradox
{
    // The Map class manages the game map
    class Map
    {
        // List to store the textures for the map
        List<Texture2D> _mapList;
        
        // Constructor for the Map class
        public Map()
        {
            // Initialize the list of map textures
            _mapList = new List<Texture2D>();
        }

        // Load method for the Map class
        public void Load()
        {
            // Load the textures for the map
            for(int i=1; i<=10; i++)
            {
                _mapList.Add(Singleton.Instance.Content.Load<Texture2D>("Map/Map" + i));
            }
        }

        // Update method for the Map class
        public void Update()
        {
            // Currently empty, can be used to update the map state if needed
        }

        // Draw method for the Map class
        public void Draw()
        {
            // Draw each map texture at the appropriate position
            for(int i=0; i<_mapList.Count; i++)
            {
                Singleton.Instance.SpriteBatch.Draw(_mapList[i], new Vector2(i*1280, 0), Color.White);
            }
        }
    }
}
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Paradox

{
    class Map
    {
        List<Texture2D> _mapList;
        
        public Map()
        {
            _mapList = new List<Texture2D>();
        }

        public void Load()
        {
            _mapList.Add(Singleton.Instance.Content.Load<Texture2D>("Map/Map1"));

        }

        
        public void Update()
        {
            
        }
        public void Draw()
        {
            for(int i=0;i<_mapList.Count;i++)
            {
                Singleton.Instance.SpriteBatch.Draw(_mapList[i], new Vector2(0, 0), Color.White);
            }
        }
    }





}
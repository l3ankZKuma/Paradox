using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Paradox
{
    public class CollisionManager
    {
        // A list to hold all collision rectangles (platforms, walls, etc.)
        public List<Rectangle> CollisionRectangles { get; private set; }

        public CollisionManager()
        {
            CollisionRectangles = new List<Rectangle>();
            
            //Box
            CollisionRectangles.Add(new Rectangle(0, 579, 450, 720-579));
            CollisionRectangles.Add(new Rectangle(242,401,467-242-64,419-401));
            CollisionRectangles.Add(new Rectangle(450,598,1537-514,720-598));
            CollisionRectangles.Add(new Rectangle(548,322,944-570-64,338-322));
            CollisionRectangles.Add(new Rectangle(1582,542,1888-1582-64,565-542));
            CollisionRectangles.Add(new Rectangle(1650,355,1840-1650-64,368-355));
            CollisionRectangles.Add(new Rectangle(1951,451,2352-1951-64,465-451));
            CollisionRectangles.Add(new Rectangle(2066,594,2224-2066-64,625-594));
            CollisionRectangles.Add(new Rectangle(2459,452,3840-2459-64,720-452));
            
        }

        // Call this method to add a new rectangle to the list
        public void AddCollisionRectangle(int x, int y, int width, int height)
        {
            CollisionRectangles.Add(new Rectangle(x, y, width, height));
        }

        // Check if the rectangle collides with any of the collision rectangles
        public bool CheckCollision(Rectangle rectangleToCheck)
        {
            foreach (var rect in CollisionRectangles)
            {
                if (rect.Intersects(rectangleToCheck))
                {
                    return true; // Collision detected
                    
                }
            }
            return false; // No collision detected
        }

        // You can add more methods here for different types of collision responses
    }
}
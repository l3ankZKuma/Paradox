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
            CollisionRectangles.Add(new Rectangle(560,309,944-570-128-64,338-322-10));
            CollisionRectangles.Add(new Rectangle(1582,542,1888-1582-64,565-542));
            CollisionRectangles.Add(new Rectangle(1650,355,1840-1650-64,368-355-10));
            CollisionRectangles.Add(new Rectangle(1951,451,2352-1951-64,465-451));
            CollisionRectangles.Add(new Rectangle(2066,594,2224-2066-64,625-594));
            CollisionRectangles.Add(new Rectangle(2459,452,4064-2459-64,720-452));
            CollisionRectangles.Add(new Rectangle(623,467,864-623-64,480-467-10));
            CollisionRectangles.Add(new Rectangle(3187,342,3376-3187-128,720-342));
            CollisionRectangles.Add(new Rectangle(4177,466,4433-4177,720-466));
            CollisionRectangles.Add(new Rectangle(4497,419,4944-4497-20,720-419));
            CollisionRectangles.Add(new Rectangle(5010,340,250,720-340));
            CollisionRectangles.Add(new Rectangle(5440,260,5690-5440-50,288-260));
            CollisionRectangles.Add(new Rectangle(5760,210,50,720-210));
            
            CollisionRectangles.Add(new Rectangle(5589,244,5933-5589,288-244));
            CollisionRectangles.Add(new Rectangle(6000,211,40,256-211));
            
            
            
            
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
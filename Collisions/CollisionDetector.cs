using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

public class CollisionDetector
{
    public static bool[] DetectCollision(Rectangle obj1, Rectangle obj2)
    {
        //default to be not collided
        bool top = false;
        bool bot = false;
        bool left = false;
        bool right = false;

        Rectangle intersection = Rectangle.Intersect(obj1, obj2);
        if (!intersection.IsEmpty)
        {
            top = obj1.Bottom >= obj2.Top; // Collision on the top side of obj2 
            bot = obj1.Top <= obj2.Bottom; // Collision on the bottom side of obj2
            left = obj1.Right >= obj2.Left; // Collision on the left side of obj2
            right = obj1.Left <= obj2.Right; // Collision on the right side of obj2
        }

        bool[] collision = new bool[] { top, bot, left, right };
        return collision;
    }
}

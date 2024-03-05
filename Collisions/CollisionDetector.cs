using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

public class CollisionDetector
{
    public static CollisionDirection DetectCollision(Rectangle obj1, Rectangle obj2)
    {
        //default to be not collided
        bool top = false;
        bool bot = false;
        bool left = false;
        bool right = false;

        Rectangle intersection = Rectangle.Intersect(obj1, obj2);
        if (!intersection.IsEmpty)
        {
            if (intersection.Width >= intersection.Height)
            {
                if (obj1.X > obj2.X)
                {
                    return Left;
                }
                    return Right;
            }
            else
            {
                if (obj1.Y > obj2.Y)
                {
                    return Bottom;
                }
                    return Top;
            }
        }
        return NoCollision;
    }
}

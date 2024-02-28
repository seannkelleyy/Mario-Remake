using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;

public class CollisionDetector
{
    public static Direction DetectCollisionDirection(Rectangle obj1, Rectangle obj2){
        Rectangle intersection = Rectangle.Intersect(obj1, obj2);
        if (!intersection.IsEmpty)
        {
            if(intersection.Height > intersection.Width)
            {
                if(obj1.X > obj2.X)
                {
                    return Right;
                }
                else
                {
                    return Left;
                }
            }
            else
            {
                if (obj1.Y > obj2.Y)
                {
                    return Bottom;
                }
                else
                {
                    return Top;
                }
            }
        }
    }
}

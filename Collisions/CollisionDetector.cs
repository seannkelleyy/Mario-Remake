using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;

public class CollisionDetector
{
    public static CollisionDirection DetectCollision(Rectangle obj1, Rectangle obj2){
        Rectangle intersection = Rectangle.Intersect(obj1, obj2);
        if (!intersection.IsEmpty)
        {
            if(intersection.Height > intersection.Width)
            {
                if(obj1.X > obj2.X)
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

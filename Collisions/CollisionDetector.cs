using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using static Mario.Global.CollisionVariables;

public class CollisionDetector
{
    public static CollisionDirection DetectCollision(Rectangle obj1, Rectangle obj2)
    {

        Rectangle intersection = Rectangle.Intersect(obj1, obj2);
        if (!intersection.IsEmpty)
        {
            if (intersection.Width >= intersection.Height)
            {
                if (obj1.X > obj2.X)
                {
                    return CollisionDirection.Left;
                }
                    return CollisionDirection.Right;
            }
            else
            {
                if (obj1.Y > obj2.Y)
                {
                    return CollisionDirection.Bottom;
                }
                    return CollisionDirection.Top;
            }
        }
        return CollisionDirection.None;
    }
}

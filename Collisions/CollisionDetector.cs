using Microsoft.Xna.Framework;
using static Mario.Global.CollisionVariables;

public class CollisionDetector
{
    public static CollisionDirection DetectCollision(Rectangle entity1, Rectangle entity2)
    {
        Rectangle intersection = Rectangle.Intersect(entity1, entity2);
        if (!intersection.IsEmpty)
        {
            if (intersection.Width >= intersection.Height)
            {
                if (entity1.X > entity2.X)
                {
                    return CollisionDirection.Left;
                }
                return CollisionDirection.Right;
            }
            else
            {
                if (entity1.Y > entity2.Y)
                {
                    return CollisionDirection.Bottom;
                }
                return CollisionDirection.Top;
            }
        }
        return CollisionDirection.None;
    }
}

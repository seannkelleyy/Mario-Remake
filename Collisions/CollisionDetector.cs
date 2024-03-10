using Microsoft.Xna.Framework;
using static Mario.Global.CollisionVariables;

public class CollisionDetector
{
    public static CollisionDirection DetectCollision(Vector2 entity1Velocity, Rectangle entity1, Rectangle entity2)
    {
        Rectangle intersection = Rectangle.Intersect(entity1, entity2);

        if (intersection.Height < 3 || intersection.Width < 3) {
            return CollisionDirection.None;
        }


        if (!intersection.IsEmpty)
        {
            if (intersection.Height >= intersection.Width)
            {
                if (entity2.Left <= entity1.Left)
                {
                    return CollisionDirection.Left;
                }
                else
                {
                    return CollisionDirection.Right;
                }
            }
            else
            {
                if (entity2.Bottom >= entity1.Bottom)
                {
                    return CollisionDirection.Bottom;
                }
                else
                {
                    return CollisionDirection.Top;
                }
            }
        }
        return CollisionDirection.None;
    }
}

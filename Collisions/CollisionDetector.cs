using Microsoft.Xna.Framework;
using static Mario.Global.CollisionVariables;

public class CollisionDetector
{
    public static CollisionDirection DetectCollision(Vector2 entity1Velocity, Rectangle entity1, Rectangle entity2)
    {
        Rectangle intersection = Rectangle.Intersect(entity1, entity2);

        if (!intersection.IsEmpty)
        {

            // Check for vertical collision
            if (entity1.Top + entity1Velocity.Y < entity2.Bottom && entity1.Bottom > entity2.Bottom)
            {
                return CollisionDirection.Top;
            }
            else if (entity1.Bottom + entity1Velocity.Y > entity2.Top && entity1.Top < entity2.Top)
            {
                return CollisionDirection.Bottom;
            }
            // Check for horizontal collision
            else if (entity1.Right + entity1Velocity.X > entity2.Left && entity1.Left < entity2.Left)
            {
                return CollisionDirection.Top;
            }

            else if (entity1.Bottom + entity1Velocity.Y > entity2.Top && entity1.Top < entity2.Top &&
                   entity1.Right > entity2.Left && entity1.Left < entity2.Right)
            {
                return CollisionDirection.Bottom;
            }
        }
        return CollisionDirection.None;
    }

}

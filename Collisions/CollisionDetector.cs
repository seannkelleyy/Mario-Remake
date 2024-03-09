using Microsoft.Xna.Framework;
using static Mario.Global.CollisionVariables;

public class CollisionDetector
{
    public static CollisionDirection DetectCollision(Vector2 entity1Velocity, Rectangle entity1, Rectangle entity2)
    {
        Logger.Instance.LogInformation("Collision detecter ------");
        Logger.Instance.LogInformation($"Entity1: loc: {entity1.Location}, Entity2: loc: {entity2.Location}");
        Logger.Instance.LogInformation($"Entity1: X: {entity1.X}, Entity2: X: {entity2.X}");
        Logger.Instance.LogInformation($"Entity1: y: {entity1.Y}, Entity2: Y: {entity2.Y}");


        Rectangle intersection = Rectangle.Intersect(entity1, entity2);
        Logger.Instance.LogInformation($"Intersection: {intersection}");

        if (!intersection.IsEmpty)
        {
            if (entity1.Right + entity1Velocity.X > entity2.Left && entity1.Left < entity2.Left &&
                entity1.Bottom > entity2.Top && entity1.Top < entity2.Bottom)
            {

                return CollisionDirection.Left;
            }

            else if (entity1.Left + entity1Velocity.X < entity2.Right && entity1.Right > entity2.Right &&
              entity1.Bottom > entity2.Top && entity1.Top < entity2.Bottom)
            {
                return CollisionDirection.Right;
            }

            else if (entity1.Bottom + entity1Velocity.Y > entity2.Top && entity1.Top < entity2.Top &&
              entity1.Right > entity2.Left && entity1.Left < entity2.Right)
            {
                return CollisionDirection.Top;
            }

            else if (entity1.Top + entity1Velocity.Y < entity2.Bottom && entity1.Bottom > entity2.Bottom &&
               entity1.Right > entity2.Left && entity1.Left < entity2.Right)
            {
                return CollisionDirection.Bottom;
            }
        }
        return CollisionDirection.None;
    }
}

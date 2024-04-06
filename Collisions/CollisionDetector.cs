using Microsoft.Xna.Framework;
using static Mario.Global.GlobalVariables;

public class CollisionDetector
{
    public static CollisionDirection DetectCollision(Rectangle entity1, Rectangle entity2, Vector2 velocity)
    {
        Rectangle predictedEntity1 = new Rectangle(
            entity1.X + (int)velocity.X,
            entity1.Y + (int)velocity.Y,
            entity1.Width,
            entity1.Height 
        );

        Rectangle intersection = Rectangle.Intersect(predictedEntity1, entity2);

        if (intersection.Width < CollisionSettings.Buffer)
            return CollisionDirection.None;
        else if (!intersection.IsEmpty)
        {
            if (intersection.Height > intersection.Width)
            {
                if (entity2.Left < predictedEntity1.Left)
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
                if (entity2.Bottom > predictedEntity1.Bottom)
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

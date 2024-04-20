using Mario.Collisions;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using static Mario.Global.GlobalVariables;

namespace Mario.Entities
{
    public class PiranhaPlant : AbstractCollideable, IEnemy
    {
        public EntityPhysics physics { get; }
        public VerticalEntityPhysics verticalPhysics { get; }
        private bool isAlive = true;

        public PiranhaPlant(Vector2 position)
        {
            verticalPhysics = new VerticalEntityPhysics(this);
            this.position = position;
        }

        public override void Update(GameTime gameTime)
        {
            if (isAlive)
            {
                verticalPhysics.Update(gameTime); // Ensure GameTime is passed here
            }
        }

        public void Stomp()
        {
            isAlive = false;
            MediaManager.Instance.PlayEffect(EffectNames.stomp);
        }

        public void Flip()
        {
            isAlive = false;
            MediaManager.Instance.PlayEffect(EffectNames.kick);
            GameContentManager.Instance.RemoveEntity(this);
        }

        public void ChangeDirection()
        {
            verticalPhysics.velocity.Y = -verticalPhysics.velocity.Y; // Reverse the direction
        }

        public bool ReportIsAlive()
        {
            return isAlive;
        }

        public Vector2 GetVelocity()
        {
            return verticalPhysics.GetVelocity();
        }
    }
}

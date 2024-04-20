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
        private double deadTimer = 0.0f;

        public PiranhaPlant(Vector2 position)
        {
            verticalPhysics = new VerticalEntityPhysics(this);
            this.position = position;
            currentState = new DefaultPiranhaState();
        }

        public override void Update(GameTime gameTime)
        {
            ClearCollisions();

            CollisionManager.Instance.Run(this);
            currentState.Update(gameTime);
            if (deadTimer > 0)
            {
                deadTimer += gameTime.ElapsedGameTime.TotalSeconds;
                if (deadTimer > EntitySettings.EnemyDespawnTime)
                {
                    GameContentManager.Instance.RemoveEntity(this);
                }
            }
            else
            {
                verticalPhysics.Update(gameTime);
            }
        }

        public void Bite()
        {
            if (deadTimer > 0) return;
            MediaManager.Instance.PlayEffect(EffectNames.bite);
            currentState = new BitingPiranhaState();
        }

        public void Stomp()
        {
            if (deadTimer > 0) return;
            MediaManager.Instance.PlayEffect(EffectNames.stomp);
            currentState = new DefaultPiranhaState();
            deadTimer = 1;
        }

        public void Flip()
        {
            MediaManager.Instance.PlayEffect(EffectNames.kick);
            GameContentManager.Instance.RemoveEntity(this);
        }

        public void ChangeDirection()
        {
            if (verticalPhysics.currentVerticalDirection == VerticalDirection.up)
            {
                verticalPhysics.currentVerticalDirection = VerticalDirection.down;
            }
            else
            {
                verticalPhysics.currentVerticalDirection = VerticalDirection.up;
            }
        }

        public bool ReportIsAlive()
        {
            return deadTimer < 1;
        }

        public Vector2 GetVelocity()
        {
            return verticalPhysics.GetVelocity();
        }
    }
}

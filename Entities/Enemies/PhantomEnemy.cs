using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Mario.Singletons;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using static Mario.Global.GlobalVariables;

namespace Mario.Entities.Enemies
{
    public class PhantomEnemy : IEnemy
    {
        private IEnemy decoratorEnemy;
        public EntityPhysics physics { get; }
        public Dictionary<string, IAI>? EnemyAI { get; set; }
        private float phantomTimer = EntitySettings.EnemyPhantomTimer;
        private bool isBig = false;
        public bool teamMario { get; }

        public VerticalEntityPhysics verticalPhysics { get; }

        public ISprite phantomSprite;

        public PhantomEnemy(IEnemy decoratorEnemy)
        {
            physics = new EntityPhysics(this);
            this.decoratorEnemy = decoratorEnemy;
            if (decoratorEnemy.ReportHealth() == EnemyHealth.Normal)
            {
                isBig = false;
            }
            phantomSprite = SpriteFactory.Instance.CreateSprite(decoratorEnemy.GetCurrentDirection() + "Phantom" + decoratorEnemy.GetType().Name);
            teamMario = false;
        }

        public void Update(GameTime gameTime)
        {
            phantomSprite.Update(gameTime);
            decoratorEnemy.Update(gameTime);
            phantomTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (phantomTimer <= 0)
            {
                RemovePhantom();
            }
        }

        private void RemovePhantom()
        {
            GameContentManager.Instance.RemoveEntity(this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            decoratorEnemy.Draw(spriteBatch);
            phantomSprite.Draw(spriteBatch, decoratorEnemy.GetPosition());
        }
        public void ChangeDirection()
        {
            decoratorEnemy.ChangeDirection();
            phantomSprite = SpriteFactory.Instance.CreateSprite(decoratorEnemy.GetCurrentDirection() + "Phantom" + decoratorEnemy.GetType().Name);
        }
        public void Stomp()
        {
            // Phantom cannot be killed.
        }
        public void Flip()
        {
            // Phantom cannot be flipped.
        }

        public void Collect(IItem item)
        {
            // Phantom cannot collect items.

        }
        public void TakeDamage()
        {
            // Phantom cannot take damage.
        }

        public void Attack()
        {
            // Phantom cannot attack.
        }
        public EnemyHealth ReportHealth()
        {
            return decoratorEnemy.ReportHealth();
        }

        public bool ReportIsAlive()
        {
            return true;
        }
        public Rectangle GetRectangle()
        {
            return decoratorEnemy.GetRectangle();
        }

        public Vector2 GetVelocity()
        {
            return decoratorEnemy.GetVelocity();
        }

        public Vector2 GetPosition()
        {
            return decoratorEnemy.GetPosition();
        }

        public void SetPosition(Vector2 position)
        {
            decoratorEnemy.SetPosition(position);
        }

        public bool GetCollisionState(CollisionDirection direction)
        {
            return decoratorEnemy.GetCollisionState(direction);
        }

        public void SetCollisionState(CollisionDirection direction, bool state)
        {
            decoratorEnemy.SetCollisionState(direction, state);
        }

        public HorizontalDirection GetCurrentDirection()
        {
            return decoratorEnemy.GetCurrentDirection();
        }
    }
}

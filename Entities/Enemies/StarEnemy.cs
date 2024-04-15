using Mario.Entities.Abstract;
using Mario.Entities.Hero;
using Mario.Entities.Items;
using Mario.Global;
using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Mario.Singletons;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using static Mario.Global.GlobalVariables;

namespace Mario.Entities.Enemies
{
    public class StarEnemy : IEnemy
    {
        private IEnemy decoratorEnemy;
        public EntityPhysics physics { get; }
        private float starTimer = EntitySettings.HeroStarTimer;
        private bool isBig = true;
        public ISprite starParticleSprite;

        //HeroState IHero.currentState { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public StarEnemy(IEnemy decoratorEnemy)
        {
            physics = new EntityPhysics(this);
            this.decoratorEnemy = decoratorEnemy;
            if (decoratorEnemy.ReportHealth() == EnemyHealth.Normal)
            {
                isBig = false;
            }
            starParticleSprite = SpriteFactory.Instance.CreateSprite(isBig.ToString() + GetType().Name);
        }

        public void Update(GameTime gameTime)
        {
            starParticleSprite.Update(gameTime);
            decoratorEnemy.Update(gameTime);
            starTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (starTimer <= 0)
            {
                RemoveStar();
            }
        }

        private void RemoveStar()
        {
            GameContentManager.Instance.RemoveEntity(this);
            GameContentManager.Instance.AddEntity(decoratorEnemy);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            decoratorEnemy.Draw(spriteBatch);
            starParticleSprite.Draw(spriteBatch, decoratorEnemy.GetPosition());
        }
        public void ChangeDirection()
        {
            decoratorEnemy.ChangeDirection();
        }
        public void Stomp()
        {
            // Star Enemy cannot be killed.
        }
        public void Flip()
        {
            // Star Enemy cannot be flipped.
        }

        public void Collect(IItem item)
        {
            if (item is Star)
            {
                starTimer = EntitySettings.HeroStarTimer;
            }
            else
            {
                if (!isBig && (item is Mushroom && !((Mushroom)item).IsOneUp() || item is FireFlower))
                {
                    isBig = true;
                    starParticleSprite = SpriteFactory.Instance.CreateSprite(isBig.ToString() + GetType().Name);
                }
                decoratorEnemy.Collect(item);
            }

        }
        public void TakeDamage()
        {
            // Star Enemy does not take damage
        }

        public void Attack()
        {
            decoratorEnemy.Attack();
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
    }
}

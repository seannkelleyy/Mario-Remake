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
using Microsoft.Xna.Framework.Graphics;
using static Mario.Global.GlobalVariables;

namespace Mario.Entities.Character
{
    public class StarHero : IHero
    {
        private IHero decoratorHero;
        private float starTimer = 10.6f;
        private bool isBig = true;
        public ISprite starParticleSprite;

        HeroState IHero.currentState { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public StarHero(IHero decoratorHero)
        {
            this.decoratorHero = decoratorHero;
            if (decoratorHero.ReportHealth() == GlobalVariables.HeroHealth.Mario)
            {
                isBig = false;
            }
            starParticleSprite = SpriteFactory.Instance.CreateSprite(isBig.ToString() + this.GetType().Name);
        }

        public void Update(GameTime gameTime)
        {
            starParticleSprite.Update(gameTime);
            decoratorHero.Update(gameTime);
            starTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (starTimer <= 0)
            {
                this.RemoveStar();
            }
        }

        private void RemoveStar()
        {
            //MediaManager.Instance.PlayDefaultTheme(); (need invincibility theme)
            GameContentManager.Instance.RemoveEntity(this);
            GameContentManager.Instance.AddEntity(decoratorHero);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            decoratorHero.Draw(spriteBatch);
            starParticleSprite.Draw(spriteBatch, decoratorHero.GetPosition());
        }

        public void WalkLeft()
        {
            decoratorHero.WalkLeft();
        }
        public void WalkRight()
        {
            decoratorHero.WalkRight();
        }
        public void Stand()
        {
            decoratorHero.Stand();
        }

        public void StopHorizontal()
        {
            decoratorHero.StopHorizontal();
        }

        public void StopVertical()
        {
            decoratorHero.StopVertical();
        }
        public void Jump()
        {
            decoratorHero.Jump();
        }

        public void SmallJump()
        {
            decoratorHero.SmallJump();
        }
        public void StopJump()
        {
            decoratorHero.StopJump();
        }

        public void Crouch()
        {
            decoratorHero.Crouch();
        }
        public void Collect(IItem item)
        {
            if (item.GetType().Name.Equals("Star"))
            {
                starTimer = 10.6f;
                decoratorHero.GetStats().AddScore(1000);
            }
            else
            {
                if (!isBig && ((item.GetType().Name.Equals("Mushroom") && !((Mushroom)item).Is1up()) || item.GetType().Name.Equals("FireFlower")))
                {
                    isBig = true;
                    starParticleSprite = SpriteFactory.Instance.CreateSprite(isBig.ToString() + this.GetType().Name);
                }
                decoratorHero.Collect(item);
            }

        }
        public void TakeDamage()
        {
            //StarHero does not take damage
        }

        public void Attack()
        {
            decoratorHero.Attack();
        }
        public void Die()
        {
            decoratorHero.Die();
        }
        public HeroHealth ReportHealth()
        {
            return decoratorHero.ReportHealth();
        }
        public Rectangle GetRectangle()
        {
            return decoratorHero.GetRectangle();
        }

        public int GetStartingLives()
        {
            return decoratorHero.GetStartingLives();
        }

        public Vector2 GetVelocity()
        {
            return decoratorHero.GetVelocity();
        }
        public HorizontalDirection GetHorizontalDirection()
        {
            return decoratorHero.GetHorizontalDirection();
        }
        public HeroPhysics GetPhysics()
        {
            return decoratorHero.GetPhysics();
        }

        public Vector2 GetPosition()
        {
            return decoratorHero.GetPosition();
        }

        public void SetPosition(Vector2 position)
        {
            decoratorHero.SetPosition(position);
        }

        public bool GetCollisionState(CollisionDirection direction)
        {
            return decoratorHero.GetCollisionState(direction);
        }

        public void SetCollisionState(CollisionDirection direction, bool state)
        {
            decoratorHero.SetCollisionState(direction, state);
        }

        public HeroStatTracker GetStats()
        {
            return decoratorHero.GetStats();
        }
    }
}

using Mario.Global;
using Mario.Interfaces.Entities;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Entities.Abstract
{
    public abstract class HeroState : AbstractEntityState
    {
        protected IHero hero;

        public HeroState(IHero hero)
        {
            this.hero = hero;
            spriteFactory = SpriteFactory.Instance;
            sprite = spriteFactory.CreateSprite(hero.GetHorizontalDirection().ToString() + this.GetType().Name + hero.ReportHealth().ToString());
        }
        public virtual void Jump()
        {
            hero.GetPhysics().Jump();
            hero.currentState = new JumpState(hero);
        }
        public virtual void Crouch()
        {
            if (hero.ReportHealth() != GlobalVariables.HeroHealth.Mario)
            {
                hero.currentState = new CrouchState(hero);
            }
        }
        public virtual void WalkLeft()
        {
            hero.GetPhysics().WalkLeft();
            hero.currentState = new RunState(hero);
        }
        public virtual void Stand()
        {
            if (hero.GetVelocity().X == 0)
            {
                hero.currentState = new StandState(hero);
            }
        }
        public virtual void WalkRight()
        {
            hero.GetPhysics().WalkRight();
            hero.currentState = new RunState(hero);
        }
        public virtual void PowerUp(bool wasSmall)
        {
            if (wasSmall)
            {
                hero.SetPosition(hero.GetPosition() - new Vector2(0, 16));
                hero.currentState = new PowerUpState(hero, hero.currentState);
            }
            else
            {
                sprite = spriteFactory.CreateSprite(hero.GetHorizontalDirection().ToString() + GetType().Name + hero.ReportHealth().ToString());
            }
        }
        public virtual void Attack()
        {
            if (hero.ReportHealth() == GlobalVariables.HeroHealth.FireMario)
            {
                hero.currentState = new AttackState(hero, hero.currentState);
            }
        }
        public virtual void TakeDamage()
        {
            sprite = spriteFactory.CreateSprite(hero.GetHorizontalDirection().ToString() + GetType().Name + hero.ReportHealth().ToString());
        }
        public virtual void Die()
        {
            hero.currentState = new DeadState(hero);
        }
        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch, position);
        }
        public override Vector2 GetVector()
        {
            return sprite.GetVector();
        }
    }
}
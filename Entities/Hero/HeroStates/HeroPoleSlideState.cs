using Mario.Entities.Abstract;
using Mario.Global;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Hero.HeroStates
{
    public class PoleSlideState : HeroState
    {
        private float elapsedSeconds = 0;
        public PoleSlideState(IHero mario) : base(mario) { }
        public override void Stand() { }
        public override void WalkRight() { }

        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            if (hero.GetCollisionState(GlobalVariables.CollisionDirection.Bottom))
            {
                elapsedSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (elapsedSeconds >= EntitySettings.HeroAnimationLength)
                {
                    if (hero.GetHorizontalDirection() == GlobalVariables.HorizontalDirection.left)
                    {
                        hero.SetPosition(hero.GetPosition() + new Vector2(GlobalVariables.HalfBlockAdjustment, 0));
                    }
                    base.WalkRight();
                }
            }
            else
            {
                hero.GetPhysics().Update();
            }
        }
    }
}

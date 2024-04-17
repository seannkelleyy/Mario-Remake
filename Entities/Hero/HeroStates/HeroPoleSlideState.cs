using Mario.Entities.Abstract;
using Mario.Global;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Hero.HeroStates
{
    public class PoleSlideState : HeroState
    {
        public PoleSlideState(IHero mario) : base(mario) { }
        public override void WalkRight()
        {
            if (hero.GetCollisionState(GlobalVariables.CollisionDirection.Bottom))
            {
                if (hero.GetHorizontalDirection() == GlobalVariables.HorizontalDirection.left)
                {
                    hero.SetPosition(hero.GetPosition() + new Vector2(GlobalVariables.HalfBlockAdjustment, 0));
                }
                base.WalkRight();
            }
            else
            {
                hero.GetPhysics().Update();
            }
        }
        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}

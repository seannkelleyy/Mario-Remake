using Mario.Entities.Abstract;
using Mario.Interfaces.Entities;


internal class SlideState : HeroState
{
    public SlideState(IHero mario) : base(mario) { }
    public override void WalkLeft()
    {
        hero.GetPhysics().WalkLeft();
        if (hero.GetVelocity().X <= 0)
        {
            hero.currentState = new RunState(hero);
        }
    }
    public override void WalkRight()
    {
        hero.GetPhysics().WalkRight();
        if (hero.GetVelocity().X >= 0)
        {
            hero.currentState = new RunState(hero);
        }
    }

}


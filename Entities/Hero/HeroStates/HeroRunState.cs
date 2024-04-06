using Mario.Entities.Abstract;
using Mario.Interfaces.Entities;
public class RunState : HeroState
{
    public RunState(IHero mario) : base(mario) { }
    public override void WalkLeft()
    {
        hero.GetPhysics().WalkLeft();
        if (hero.GetVelocity().X > 0)
        {
            hero.currentState = new SlideState(hero);
        }
    }
    public override void WalkRight()
    {
        hero.GetPhysics().WalkRight();
        if (hero.GetVelocity().X < 0)
        {
            hero.currentState = new SlideState(hero);
        }
    }

}
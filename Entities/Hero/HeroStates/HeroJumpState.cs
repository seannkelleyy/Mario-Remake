using Mario.Entities.Abstract;
using Mario.Interfaces.Entities;
using static Mario.Global.GlobalVariables;

public class JumpState : HeroState
{
    public JumpState(IHero mario) : base(mario) { }
    public override void Stand()
    {
        if (hero.GetCollisionState(CollisionDirection.Bottom))
        {
            hero.currentState = new StandState(hero);
        }
    }
    public override void WalkLeft()
    {
        hero.GetPhysics().WalkLeft();
    }
    public override void WalkRight()
    {
        hero.GetPhysics().WalkRight();
    }
}
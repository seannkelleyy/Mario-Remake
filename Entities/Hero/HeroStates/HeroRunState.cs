using Mario.Entities.Character;
using Mario.Entities.Character.HeroStates;

public class RunState : HeroState
{
    public RunState(Hero mario) : base(mario) { }
    public override void WalkLeft()
    {
        mario.GetPhysics().WalkLeft();
        if (mario.GetVelocity().X > 0)
        {
            mario.currentState = new SlideState(mario);
        }
    }
    public override void WalkRight()
    {
        mario.GetPhysics().WalkRight();
        if (mario.GetVelocity().X < 0)
        {
            mario.currentState = new SlideState(mario);
        }
    }
}
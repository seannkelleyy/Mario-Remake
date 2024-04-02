using Mario.Entities.Abstract;
using Mario.Entities.Character;


internal class SlideState : HeroState
{
    public SlideState(Hero mario) : base(mario) { }
    public override void WalkLeft()
    {
        mario.GetPhysics().WalkLeft();
        if (mario.GetVelocity().X <= 0)
        {
            mario.currentState = new RunState(mario);
        }
    }
    public override void WalkRight()
    {
        mario.GetPhysics().WalkRight();
        if (mario.GetVelocity().X >= 0)
        {
            mario.currentState = new RunState(mario);
        }
    }

}


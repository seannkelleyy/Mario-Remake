using Mario.Entities.Abstract;
using Mario.Entities.Character;
using static Mario.Global.CollisionVariables;

public class JumpState : HeroState
{
    public JumpState(Hero mario) : base(mario) { }
    public override void Stand()
    {
        if (mario.GetCollisionState(CollisionDirection.Bottom))
        {
            mario.currentState = new StandState(mario);
        }
    }
    public override void WalkLeft()
    {
        mario.GetPhysics().WalkLeft();
    }
    public override void WalkRight()
    {
        mario.GetPhysics().WalkRight();
    }


}
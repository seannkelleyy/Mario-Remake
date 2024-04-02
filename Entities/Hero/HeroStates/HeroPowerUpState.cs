using Mario.Entities.Abstract;
using Mario.Entities.Character;
using Microsoft.Xna.Framework;

public class PowerUpState : HeroState
{
    private float updateInterval = 1.8f;
    private float elapsedSeconds = 0;
    private HeroState previousState;
    public PowerUpState(Hero mario, HeroState previousState) : base(mario)
    {
        this.previousState = previousState;
    }
    public override void Stand()
    {
    }
    public override void WalkRight()
    {
    }
    public override void WalkLeft()
    {
    }
    public override void Jump()
    {
    }
    public override void Attack()
    {
    }
    public override void Crouch() { }
    public override void TakeDamage()
    {
        mario.currentState = new StandState(mario);
        mario.currentState.TakeDamage();
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        elapsedSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (elapsedSeconds >= updateInterval)
        {
            mario.currentState = previousState;
        }
    }
}
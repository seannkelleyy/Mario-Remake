using Mario.Entities.Character;
using Mario.Entities.Character.HeroStates;
using Microsoft.Xna.Framework;


internal class CrouchState : HeroState

{
    private float updateInterval = .25f;
    private float elapsedSeconds = 0;
    public CrouchState(Hero mario) : base(mario) { }
    public override void Stand() { }

    public override void WalkLeft()
    {
    }
    public override void WalkRight()
    {
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        elapsedSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (elapsedSeconds >= updateInterval)
        {
            mario.currentState = new StandState(mario);
        }
    }

}


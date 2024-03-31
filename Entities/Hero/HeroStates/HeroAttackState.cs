using Mario.Entities.Character;
using Mario.Entities.Character.HeroStates;
using Mario.Entities.Projectiles;
using Mario.Singletons;
using Microsoft.Xna.Framework;

internal class AttackState : HeroState
{
    private float updateInterval = .25f;
    private float elapsedSeconds = 0;
    private HeroState previousState;
    public AttackState(Hero mario, HeroState previousState) : base(mario)
    {
        this.previousState = previousState;
        GameContentManager.Instance.AddEntity(new Fireball(mario.GetPosition(), mario.getHorizontalDirection()));
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

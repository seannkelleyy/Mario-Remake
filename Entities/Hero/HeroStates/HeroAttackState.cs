using Mario.Entities.Abstract;
using Mario.Entities.Character;
using Mario.Entities.Projectiles;
using Mario.Singletons;
using Microsoft.Xna.Framework;

internal class AttackState : HeroState
{
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
    public override void TakeDamage()
    {
        mario.currentState = new StandState(mario);
        mario.currentState.TakeDamage();
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        elapsedSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (elapsedSeconds >= EntitySettings.heroAttackTime)
        {
            mario.currentState = previousState;
        }
    }
}

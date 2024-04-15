using Mario.Entities.Abstract;
using Mario.Entities.Projectiles;
using Mario.Interfaces.Entities;
using Mario.Singletons;
using Microsoft.Xna.Framework;

internal class AttackState : HeroState
{
    private float elapsedSeconds = 0;
    private HeroState previousState;
    public AttackState(IHero mario, HeroState previousState) : base(mario)
    {
        this.previousState = previousState;
        GameContentManager.Instance.AddEntity(new Fireball(mario.GetPosition() + new Vector2(0, (mario.GetRectangle().Height / 2)), mario.GetHorizontalDirection()));
    }
    public override void Stand() { }
    public override void WalkRight() { }
    public override void WalkLeft() { }
    public override void Jump() { }
    public override void Attack() { }
    public override void Crouch() { }
    public override void TakeDamage()
    {
        hero.currentState = new StandState(hero);
        hero.currentState.TakeDamage();
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        elapsedSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (elapsedSeconds >= EntitySettings.HeroAttackTime)
        {
            hero.currentState = previousState;
        }
    }
}

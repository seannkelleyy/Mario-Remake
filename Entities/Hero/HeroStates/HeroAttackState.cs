﻿using Mario.Entities.Abstract;
using Mario.Entities.Projectiles;
using Mario.Entities.Projectiles.Rocket;
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
        if (hero.ReportHealth() == Mario.Global.GlobalVariables.HeroHealth.FireMario)
        {
            GameContentManager.Instance.AddEntity(new Fireball(mario.GetPosition() + new Vector2(0, (mario.GetRectangle().Height / 2)), mario.GetHorizontalDirection(), true));
        }
        else if (hero.ReportHealth() == Mario.Global.GlobalVariables.HeroHealth.PistolMario)
        {
            GameContentManager.Instance.AddEntity(new BulletObject(mario.GetPosition() + new Vector2(0, (mario.GetRectangle().Height / 2)), mario.GetHorizontalDirection(), true));
        }
        else if (hero.ReportHealth() == Mario.Global.GlobalVariables.HeroHealth.RocketLauncherMario)
        {
            GameContentManager.Instance.AddEntity(new RocketProjectile(mario.GetPosition() + new Vector2(0, (mario.GetRectangle().Height / 2)), mario.GetHorizontalDirection(), true));
        }
        else
        {
            new ShotgunBurst(mario.GetPosition() + new Vector2(0, (mario.GetRectangle().Height / 2)), mario.GetHorizontalDirection(), true);
        }
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

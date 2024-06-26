﻿using Mario.Entities.Abstract;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;

public class PowerUpState : HeroState
{
    private float elapsedSeconds = 0;
    public PowerUpState(IHero mario, HeroState previousState) : base(mario)
    {
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
        sprite.Update(gameTime);
        elapsedSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (elapsedSeconds >= EntitySettings.HeroAnimationLength)
        {
            hero.currentState = new StandState(hero);
        }
    }
}
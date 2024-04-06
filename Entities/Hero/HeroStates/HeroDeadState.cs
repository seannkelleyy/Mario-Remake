using Mario.Entities.Abstract;
using Mario.Interfaces.Entities;

public class DeadState : HeroState
{
    public DeadState(IHero mario) : base(mario) { }
}
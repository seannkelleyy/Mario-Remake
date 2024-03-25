using Mario.Entities.Enemy.Goomba.GoombaStates;

public class StompedGoombaState : GoombaState
{
    public StompedGoombaState() : base()
    {
        sprite = spriteFactory.CreateSprite("stompedGoomba");
    }

}
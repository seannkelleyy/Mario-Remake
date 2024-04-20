using Mario.Entities.Abstract;

namespace Mario.Entities.Items.ItemStates
{
    public class ShotgunState : AbstractEntityState
    {
        public ShotgunState() : base()
        {
            sprite = spriteFactory.CreateSprite("shotgun");
        }
    }
}

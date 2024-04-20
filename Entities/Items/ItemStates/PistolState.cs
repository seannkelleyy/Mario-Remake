using Mario.Entities.Abstract;

namespace Mario.Entities.Items.ItemStates
{
    public class PistolState : AbstractEntityState
    {
        public PistolState() : base()
        {
            sprite = spriteFactory.CreateSprite("pistol");
        }
    }
}

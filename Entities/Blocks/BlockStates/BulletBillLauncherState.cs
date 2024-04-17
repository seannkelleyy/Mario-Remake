using Mario.Entities.Abstract;

namespace Mario.Entities.Blocks.BlockStates
{
    public class BulletBillLauncherState : AbstractEntityState
    {
        public BulletBillLauncherState() : base()
        {
            sprite = spriteFactory.CreateSprite("bulletLauncher");
        }
    }
}

using Mario.Entities.Abstract;

namespace Mario.Entities.Items.ItemStates
{
    public class RocketLauncherState : AbstractEntityState
    {
        public RocketLauncherState() : base()
        {
            sprite = spriteFactory.CreateSprite("rocketLauncher");
        }
    }
}

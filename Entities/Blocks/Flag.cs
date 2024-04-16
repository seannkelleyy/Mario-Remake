using Mario.Entities.Blocks.BlockStates;
using Mario.Global;
using Mario.Interfaces.Base;
using Mario.Singletons;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Entities.Blocks
{
    public class Flag : AbstractBlock
    {
        private ISprite flagSprite;
        private Vector2 flagPosition;
        public Flag(Vector2 position, bool breakable, bool collidable)
        {
            this.position = position;
            isCollidable = collidable;
            isBreakable = breakable;
            canBeCombined = true;
            currentState = new FlagState();
            flagSprite = SpriteFactory.Instance.CreateSprite("Flag");
            flagPosition = position + new Vector2(-GlobalVariables.HalfBlockAdjustment, GlobalVariables.BlockHeightWidth);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            flagSprite.Draw(spriteBatch, flagPosition);
        }
        public override void GetHit()
        {
            if (isBreakable) GameContentManager.Instance.RemoveEntity(this);
        }
    }
}

using Mario.Entities.Blocks;
using Mario.Singletons;
using Microsoft.Xna.Framework;

public class Block : AbstractBlock
{
    private int width;
    private int height;

    public Block(Vector2 position, int width, int height, bool isBreakable)
    {
        this.position = position;
        this.width = width;
        this.height = height;
        this.isBreakable = isBreakable;
        isCollideable = true;
        canBeCombined = true;
    }

    public override void GetHit()
    {
        if (isBreakable) GameContentManager.Instance.RemoveEntity(this);
    }

    public override Rectangle GetRectangle()
    {
        return new Rectangle((int)position.X, (int)position.Y, width, height);
    }
}

using Mario.Singletons;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Blocks
{
    public class Pipe : AbstractPipe
    {
        public Pipe(Vector2 position, bool collidable)
        {
            this.position = position;
            currentState = new PipeNormalState();
            isCollidable = collidable;
            isTrasnport = false;
        }
    }
}
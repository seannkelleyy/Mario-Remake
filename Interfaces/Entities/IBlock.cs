using Mario.Interfaces;
using Microsoft.Xna.Framework;

namespace GreenGame.Interfaces
{
	public interface IBlock : ISprite
    {
        // Changes block sprite when it is hit etc.
        public void CycleBlock();
	}
}


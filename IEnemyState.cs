using System;
using Mario.Interfaces;
using Microsoft.Xna.Framework;

namespace GreenGame.Interfaces
{
	public interface IEnemyState : IEnemy
	{
        void ChangeDirection();
        void BeStomped();
        void BeFlipped();
        void Update();
    }
}

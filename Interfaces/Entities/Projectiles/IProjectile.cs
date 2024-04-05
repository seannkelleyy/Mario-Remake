using Mario.Interfaces.Base;

namespace Mario.Interfaces.Entities.Projectiles
{
	// nothing here until we have more projectiles, all projectiles will extend
	// this so we can keep track of them in the Game Content Manager
	public interface IProjectile : IEntityBase, ICollideable
    {
	}
}


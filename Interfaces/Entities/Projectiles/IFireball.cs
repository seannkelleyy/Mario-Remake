using Mario.Interfaces.Entities.Projectiles;
using Mario.Physics;

namespace Mario.Entities.Projectiles
{
    public interface IFireball : IProjectile 
    {
        public FireballPhysics physics { get; }
        public void Bounce() { }
    }
}

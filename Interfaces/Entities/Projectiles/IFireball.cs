using Mario.Interfaces.Entities.Projectiles;

namespace Mario.Entities.Projectiles
{
    public interface IFireball : IProjectile 
    {
        public void Bounce() { }
    }
}

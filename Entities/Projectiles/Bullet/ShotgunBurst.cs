using Mario.Singletons;
using Microsoft.Xna.Framework;
using static Mario.Global.GlobalVariables;

namespace Mario.Entities.Projectiles
{
    public class ShotgunBurst
    {
        public ShotgunBurst(Vector2 position, HorizontalDirection currentHorizontalDirection, bool teamMario)
        {
            GameContentManager.Instance.AddEntity(new BulletObject(position, currentHorizontalDirection, teamMario, 0));
            GameContentManager.Instance.AddEntity(new BulletObject(position, currentHorizontalDirection, teamMario, 5));
            GameContentManager.Instance.AddEntity(new BulletObject(position, currentHorizontalDirection, teamMario, 10));
            GameContentManager.Instance.AddEntity(new BulletObject(position, currentHorizontalDirection, teamMario, 15));
            GameContentManager.Instance.AddEntity(new BulletObject(position, currentHorizontalDirection, teamMario, 20));
            GameContentManager.Instance.AddEntity(new BulletObject(position, currentHorizontalDirection, teamMario, -5));
            GameContentManager.Instance.AddEntity(new BulletObject(position, currentHorizontalDirection, teamMario, -10));
            GameContentManager.Instance.AddEntity(new BulletObject(position, currentHorizontalDirection, teamMario, -15));
            GameContentManager.Instance.AddEntity(new BulletObject(position, currentHorizontalDirection, teamMario, -20));
        }
    }
}

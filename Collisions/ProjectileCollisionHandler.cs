using Mario.Entities.Blocks;
using Mario.Entities.Projectiles;
using Mario.Global.Settings;
using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Mario.Interfaces.Entities.Projectiles;
using Mario.Singletons;
using System;
using System.Collections.Generic;
using static Mario.Global.GlobalVariables;
public class ProjectileCollisionHandler
{
    public IProjectile projectile { get; set; }
    public IHero hero { get; set; }
    public IEnemy enemy { get; set; }
    public IBlock block { get; set; }
    public IPipe pipe { get; set; }
    private Dictionary<Type, Dictionary<CollisionDirection, Action>> collisionDictionary;

    public ProjectileCollisionHandler(IProjectile projectile)
    {
        this.projectile = projectile;
        collisionDictionary = new Dictionary<Type, Dictionary<CollisionDirection, Action>>
        {
            { typeof(IBlock), new Dictionary<CollisionDirection, Action>() },
            { typeof(IPipe), new Dictionary<CollisionDirection, Action>() },
            { typeof(IEnemy), new Dictionary<CollisionDirection, Action>() },
            { typeof(IHero), new Dictionary<CollisionDirection, Action>() }
        };

        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Left, new Action(() =>
        {
            projectile.Destroy();
        }));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Right, new Action(() =>
        {
            projectile.Destroy();
        }));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Top, new Action(() =>
        {
            projectile.Destroy();
        }));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Bottom, new Action(() =>
        {
            if (block is DeathBlock)
            {
                GameContentManager.Instance.RemoveEntity(projectile);

            }
            else if (projectile is Fireball)
            {
                projectile.SetCollisionState(CollisionDirection.Bottom, true);
            }
            else
            {
                projectile.Destroy();
            }
        }));

        // Pipe stuff
        collisionDictionary[typeof(IPipe)].Add(CollisionDirection.Left, new Action(() =>
        {
            projectile.Destroy();
        }));
        collisionDictionary[typeof(IPipe)].Add(CollisionDirection.Right, new Action(() =>
        {
            projectile.Destroy();
        }));
        collisionDictionary[typeof(IPipe)].Add(CollisionDirection.Top, new Action(() =>
        {
            projectile.Destroy();
        }));
        collisionDictionary[typeof(IPipe)].Add(CollisionDirection.Bottom, new Action(() =>
        {
            if (projectile is Fireball)
            {
                projectile.SetCollisionState(CollisionDirection.Bottom, true);
            }
            else
            {
                projectile.Destroy();
            }
        }));

        // Enemy Stuff
        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Left, new Action(() =>
        {
            GameContentManager.Instance.GetHero().GetStats().AddScore(ScoreSettings.GetScore(enemy));
            enemy.Flip();
            projectile.Destroy();
        }));
        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Right, new Action(() =>
        {
            GameContentManager.Instance.GetHero().GetStats().AddScore(ScoreSettings.GetScore(enemy));
            GameContentManager.Instance.GetHero().GetStats().AddScore(ScoreSettings.GetScore(enemy));
            enemy.Flip();
            projectile.Destroy();

        }));
        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Top, new Action(() =>
        {
            GameContentManager.Instance.GetHero().GetStats().AddScore(ScoreSettings.GetScore(enemy));
            enemy.Flip();
            projectile.Destroy();

        }));
        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Bottom, new Action(() =>
        {
            GameContentManager.Instance.GetHero().GetStats().AddScore(ScoreSettings.GetScore(enemy));
            enemy.Flip();
            projectile.Destroy();

        }));

        // Hero stuff
        collisionDictionary[typeof(IHero)].Add(CollisionDirection.Left, new Action(() =>
        {
            hero.TakeDamage();
            projectile.Destroy();
        }));
        collisionDictionary[typeof(IHero)].Add(CollisionDirection.Right, new Action(() =>
        {
            hero.TakeDamage();
            projectile.Destroy();

        }));
        collisionDictionary[typeof(IHero)].Add(CollisionDirection.Top, new Action(() =>
        {
            hero.TakeDamage();
            projectile.Destroy();

        }));
        collisionDictionary[typeof(IHero)].Add(CollisionDirection.Bottom, new Action(() =>
        {
            hero.TakeDamage();
            projectile.Destroy();

        }));
    }

    public void ProjectileHeroCollision(IHero hero)
    {
        this.hero = hero;
        if (!(projectile.teamMario == hero.teamMario))
        {
            CollisionDirection direction = CollisionDetector.DetectCollision(projectile.GetRectangle(), hero.GetRectangle(), projectile.GetVelocity());
            if (collisionDictionary[typeof(IHero)].ContainsKey(direction))
            {
                collisionDictionary[typeof(IHero)][direction].Invoke();
            }
        }
    }
    public void ProjectileEnemyCollision(IEnemy enemy)
    {
        this.enemy = enemy;
        if (!(projectile.teamMario == enemy.teamMario))
        {
            CollisionDirection direction = CollisionDetector.DetectCollision(projectile.GetRectangle(), enemy.GetRectangle(), projectile.GetVelocity());
            if (collisionDictionary[typeof(IEnemy)].ContainsKey(direction))
            {
                collisionDictionary[typeof(IEnemy)][direction].Invoke();
            }
        }
    }

    public void ProjectileBlockCollision(IBlock block)
    {
        CollisionDirection direction = CollisionDetector.DetectCollision(projectile.GetRectangle(), block.GetRectangle(), projectile.GetVelocity());
        if (collisionDictionary[typeof(IBlock)].ContainsKey(direction))
        {
            this.block = block;
            collisionDictionary[typeof(IBlock)][direction].Invoke();
        }
    }
    public void ProjectilePipeCollision(IPipe pipe)
    {
        CollisionDirection direction = CollisionDetector.DetectCollision(projectile.GetRectangle(), pipe.GetRectangle(), projectile.GetVelocity());
        if (collisionDictionary[typeof(IBlock)].ContainsKey(direction))
        {
            this.pipe = pipe;
            collisionDictionary[typeof(IPipe)][direction].Invoke();
        }
    }
}

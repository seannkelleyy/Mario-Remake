using Mario.Entities.Character;
using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Mario.Interfaces.Entities.Projectiles;
using Mario.Singletons;
using System;
using System.Collections.Generic;
using static Mario.Global.CollisionVariables;

public class ProjectileCollisionHandler
{
    public IProjectile projectile { get; set; }
    public IEnemy enemy { get; set; }
    public IBlock block { get; set; }
    private Dictionary<Type, Dictionary<CollisionDirection, Action>> collisionDictionary;

    public ProjectileCollisionHandler(IProjectile projectile)
    {
        this.projectile = projectile;
        collisionDictionary = new Dictionary<Type, Dictionary<CollisionDirection, Action>>
        {
            { typeof(IBlock), new Dictionary<CollisionDirection, Action>() },
            { typeof(IEnemy), new Dictionary<CollisionDirection, Action>() }
        };

        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Left, new Action(() => {
            projectile.SetCollisionState(CollisionDirection.Left, true);
            projectile.UpdateHorizontal();
        }));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Right, new Action(() => {
            projectile.SetCollisionState(CollisionDirection.Right, true);
            hero.StopHorizontal();
        }));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Top, new Action(() => {
            hero.SetCollisionState(CollisionDirection.Top, true);
            hero.StopVertical();
            block.GetHit();
        }));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Bottom, new Action(() => {
            projectile.SetCollisionState(CollisionDirection.Bottom, true);
        }));


        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Left, new Action(() => {
            enemy.Flip();
            projectile.Explode();
        }));
        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Right, new Action(() => {
            enemy.Flip();
            projectile.Explode();
        }));
        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Top, new Action(() => {
            enemy.Flip();
            projectile.Explode();
        }));
        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Bottom, new Action(() => {
            enemy.Flip();
            projectile.Explode();
        }));
    }

    public void ProjectileEnemyCollision(IEnemy enemy)
    {
        this.enemy = enemy;

        CollisionDirection direction = CollisionDetector.DetectCollision(projectile.GetRectangle(), enemy.GetRectangle(), hero.GetVelocity());
        if (collisionDictionary[typeof(IEnemy)].ContainsKey(direction))
        {
            collisionDictionary[typeof(IEnemy)][direction].Invoke();
        }
    }

    public void ProjectileBlockCollision(IBlock block)
    {
        CollisionDirection direction = CollisionDetector.DetectCollision(projectile.GetRectangle(), block.GetRectangle(), hero.GetVelocity());
        if (collisionDictionary[typeof(IBlock)].ContainsKey(direction))
        {
            this.block = block;
            collisionDictionary[typeof(IBlock)][direction].Invoke();
        }
    }
}

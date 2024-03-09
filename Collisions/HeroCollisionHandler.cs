using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Mario.Singletons;
using System;
using System.Collections.Generic;
using static Mario.Global.CollisionVariables;

public class HeroCollisionHandler
{
    public IHero hero { get; set; }
    public IEnemy enemy { get; set; }
    private Dictionary<Type, Dictionary<CollisionDirection, Action>> collisionDictionary;

    public HeroCollisionHandler(IHero hero)
    {
        this.hero = hero;
        collisionDictionary = new Dictionary<Type, Dictionary<CollisionDirection, Action>>
        {
            { typeof(IBlock), new Dictionary<CollisionDirection, Action>() },
            { typeof(IEnemy), new Dictionary<CollisionDirection, Action>() },
            { typeof(IItem), new Dictionary<CollisionDirection, Action>() }
        };

        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Left, new Action(() => hero.SetCollisionState(CollisionDirection.Left, true)));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Right, new Action(() => hero.SetCollisionState(CollisionDirection.Right, true)));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Top, new Action(() => hero.SetCollisionState(CollisionDirection.Top, true)));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Bottom, new Action(() => hero.SetCollisionState(CollisionDirection.Bottom, true)));


        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Left, new Action(hero.TakeDamage));
        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Right, new Action(hero.TakeDamage));
        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Bottom, new Action(() =>
        {
            hero.Jump();
            enemy.Stomp();
        }));
    }

    public void HeroEnemyCollision(IEnemy enemy)
    {
        this.enemy = enemy;

        CollisionDirection direction = CollisionDetector.DetectCollision(hero.GetVelocity(), hero.GetRectangle(), enemy.GetRectangle());
        if (collisionDictionary[typeof(IEnemy)].ContainsKey(direction))
        {
            collisionDictionary[typeof(IEnemy)][direction].Invoke();
        }
    }

    public void HeroItemCollision(IItem item)
    {
        CollisionDirection direction = CollisionDetector.DetectCollision(hero.GetVelocity(), hero.GetRectangle(), item.GetRectangle());
        if (direction != CollisionDirection.None)
        {
            hero.Collect(item);
            GameContentManager.Instance.RemoveEntity(item);
        }
    }

    public void HeroBlockCollision(IBlock block)
    {
        CollisionDirection direction = CollisionDetector.DetectCollision(hero.GetVelocity(), hero.GetRectangle(), block.GetRectangle());
        if (collisionDictionary[typeof(IBlock)].ContainsKey(direction))
        {
            collisionDictionary[typeof(IBlock)][direction].Invoke();
            block.GetHit();
        }
        Logger.Instance.LogInformation($"Hero collision enum: {direction} {hero.GetCollisionState(direction)}");
    }
}

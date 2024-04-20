using Mario.Entities;
using Mario.Entities.Character;
using Mario.Global;
using Mario.Global.Settings;
using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Mario.Singletons;
using System;
using System.Collections.Generic;
using static Mario.Global.GlobalVariables;

public class HeroCollisionHandler
{
    public IHero hero { get; set; }
    public IEnemy enemy { get; set; }
    public IBlock block { get; set; }
    public IPipe pipe { get; set; }
    private Dictionary<Type, Dictionary<CollisionDirection, Action>> collisionDictionary;

    public HeroCollisionHandler(IHero hero)
    {
        this.hero = hero;
        collisionDictionary = new Dictionary<Type, Dictionary<CollisionDirection, Action>>
        {
            { typeof(IBlock), new Dictionary<CollisionDirection, Action>() },
            { typeof(IEnemy), new Dictionary<CollisionDirection, Action>() },
            { typeof(IItem), new Dictionary<CollisionDirection, Action>() },
            { typeof(IPipe), new Dictionary<CollisionDirection, Action>() },
        };

        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Left, new Action(() =>
        {
            hero.SetCollisionState(CollisionDirection.Left, true);
            hero.StopHorizontal();
        }));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Right, new Action(() =>
        {
            hero.SetCollisionState(CollisionDirection.Right, true);
            hero.StopHorizontal();
        }));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Top, new Action(() =>
        {
            if (block.isBreakable) GameContentManager.Instance.GetHero().GetStats().AddScore(ScoreSettings.BreakBlockScore);
            hero.SetCollisionState(CollisionDirection.Top, true);
            hero.StopVertical();
            block.GetHit();
        }));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Bottom, new Action(() =>
        {
            hero.SetCollisionState(CollisionDirection.Bottom, true);
        }));
        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Left, new Action(HandleHeroEnemySideCollision));
        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Right, new Action(HandleHeroEnemySideCollision));
        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Bottom, new Action(HandleHeroEnemyBottomCollision));

        // Pipe stuff
        collisionDictionary[typeof(IPipe)].Add(CollisionDirection.Bottom, new Action(() =>
        {
            hero.SetCollisionState(CollisionDirection.Bottom, true);
            if (pipe.GetPipeType() == GlobalVariables.PipeType.vertical)
            {
                pipe.Transport(hero);
            }
        }));
        collisionDictionary[typeof(IPipe)].Add(CollisionDirection.Left, new Action(() =>
        {
            hero.SetCollisionState(CollisionDirection.Left, true);
            hero.StopHorizontal();
        }));
        collisionDictionary[typeof(IPipe)].Add(CollisionDirection.Right, new Action(() =>
        {
            hero.SetCollisionState(CollisionDirection.Right, true);
            if (pipe.GetPipeType() == GlobalVariables.PipeType.horizontal)
            {
                pipe.Transport(hero);
            }
            else
            {
                hero.StopHorizontal();
            }
        }));
        collisionDictionary[typeof(IPipe)].Add(CollisionDirection.Top, new Action(() =>
        {
            hero.SetCollisionState(CollisionDirection.Top, true);
            hero.StopVertical();
        }));
        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Top, new Action(() =>
        {
            if (hero is StarHero)
            {
                enemy.Flip();
            }
            else
            {
                hero.TakeDamage();
            }
        }));
    }

    public void HeroEnemyCollision(IEnemy enemy)
    {
        this.enemy = enemy;
        if (!enemy.ReportIsAlive()) return;
        CollisionDirection direction = CollisionDetector.DetectCollision(hero.GetRectangle(), enemy.GetRectangle(), hero.GetVelocity());
        if (collisionDictionary[typeof(IEnemy)].ContainsKey(direction))
        {
            if(enemy is PiranhaPlant)
            {
                collisionDictionary[typeof(IEnemy)][CollisionDirection.Left].Invoke();
            }
            collisionDictionary[typeof(IEnemy)][direction].Invoke();
        }
    }

    public void HeroItemCollision(IItem item)
    {
        CollisionDirection direction = CollisionDetector.DetectCollision(hero.GetRectangle(), item.GetRectangle(), hero.GetVelocity());
        if (direction != CollisionDirection.None)
        {
            hero.Collect(item);
            hero.GetStats().AddScore(ScoreSettings.GetScore(item));
            GameContentManager.Instance.RemoveEntity(item);
        }
    }

    public void HeroBlockCollision(IBlock block)
    {
        CollisionDirection direction = CollisionDetector.DetectCollision(hero.GetRectangle(), block.GetRectangle(), hero.GetVelocity());
        if (collisionDictionary[typeof(IBlock)].ContainsKey(direction))
        {
            this.block = block;
            collisionDictionary[typeof(IBlock)][direction].Invoke();
        }
    }

    public void HandleHeroEnemySideCollision()
    {
        if (hero is StarHero)
        {
            enemy.Flip();
        }
        else if (enemy is Koopa koopa && koopa.isShell && koopa.physics.IsStationary())
        {
            koopa.physics.currentHorizontalDirection = hero.GetHorizontalDirection();
            koopa.physics.ToggleIsStationary();
        } else
        {
            hero.TakeDamage();
        }
    }

    public void HandleHeroEnemyBottomCollision()
    {
        if (hero is StarHero)
        {
            enemy.Flip();
        }
        else if (hero.GetPhysics().isFalling)
        {
            GameContentManager.Instance.GetHero().GetStats().AddScore(ScoreSettings.GetScore(enemy));
            hero.SetCollisionState(CollisionDirection.Bottom, true);
            hero.SmallJump();
            hero.SetCollisionState(CollisionDirection.Bottom, false);
            enemy.Stomp();
        }
    }

    public void HeroPipeCollision(IPipe pipe)
    {
        CollisionDirection direction = CollisionDetector.DetectCollision(hero.GetRectangle(), pipe.GetRectangle(), hero.GetVelocity());
        if (collisionDictionary[typeof (IPipe)].ContainsKey(direction))
        {
            this.pipe = pipe;
            collisionDictionary[typeof(IPipe)][direction].Invoke();
        }
    }
}

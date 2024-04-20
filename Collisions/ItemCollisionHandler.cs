using Mario.Entities.Blocks;
using Mario.Interfaces;
using Mario.Singletons;
using System;
using System.Collections.Generic;
using static Mario.Global.GlobalVariables;

public class ItemCollisionHandler
{
    public IItem mainItem { get; set; }
    public IItem collidingItem { get; set; }
    public IBlock block { get; set; }

    private Dictionary<Type, Dictionary<CollisionDirection, Action>> collisionDictionary;

    public ItemCollisionHandler(IItem item)
    {
        mainItem = item;

        collisionDictionary = new Dictionary<Type, Dictionary<CollisionDirection, Action>>
        {
            { typeof(IBlock), new Dictionary<CollisionDirection, Action>() },
            { typeof(IPipe), new Dictionary<CollisionDirection, Action>() }
        };

        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Left, new Action(() =>
        {
            mainItem.SetCollisionState(CollisionDirection.Left, true);
            mainItem.ChangeDirection();
        }));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Right, new Action(() =>
        {
            mainItem.SetCollisionState(CollisionDirection.Right, true);
            mainItem.ChangeDirection();
        }));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Top, new Action(() => mainItem.SetCollisionState(CollisionDirection.Top, true)));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Bottom, new Action(() =>
        {
            if (block is DeathBlock)
            {
                GameContentManager.Instance.RemoveEntity(mainItem);

            }
            else
            {
                mainItem.SetCollisionState(CollisionDirection.Bottom, true);
            }
        }));

        // Pipe stuff
        collisionDictionary[typeof(IPipe)].Add(CollisionDirection.Left, new Action(() =>
        {
            mainItem.SetCollisionState(CollisionDirection.Left, true);
            mainItem.ChangeDirection();
        }));
        collisionDictionary[typeof(IPipe)].Add(CollisionDirection.Right, new Action(() =>
        {
            mainItem.SetCollisionState(CollisionDirection.Right, true);
            mainItem.ChangeDirection();
        }));
        collisionDictionary[typeof(IPipe)].Add(CollisionDirection.Top, new Action(() => mainItem.SetCollisionState(CollisionDirection.Top, true)));
        collisionDictionary[typeof(IPipe)].Add(CollisionDirection.Bottom, new Action(() => mainItem.SetCollisionState(CollisionDirection.Bottom, true)));
    }

    public void ItemBlockCollision(IBlock block)
    {
        CollisionDirection direction = CollisionDetector.DetectCollision(mainItem.GetRectangle(), block.GetRectangle(), mainItem.GetVelocity());
        if (collisionDictionary[typeof(IBlock)].ContainsKey(direction))
        {
            this.block = block;
            collisionDictionary[typeof(IBlock)][direction].Invoke();
        }
    }

    public void ItemPipeCollision(IPipe pipe)
    {
        CollisionDirection direction = CollisionDetector.DetectCollision(mainItem.GetRectangle(), pipe.GetRectangle(), mainItem.GetVelocity());
        if (collisionDictionary[typeof(IPipe)].ContainsKey(direction))
        {
            collisionDictionary[typeof(IPipe)][direction].Invoke();
        }
    }
}
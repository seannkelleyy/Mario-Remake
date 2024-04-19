using Mario.Collisions;
using Mario.Entities;
using Mario.Entities.Abstract;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using static Mario.Global.GlobalVariables;

public class PiranhaPlant : AbstractCollideable, IPiranhaPlant
{
    public EntityPhysics physics { get; }
    private double attackCooldown = 0.0f;
    private bool isInPipe = true;

    public PiranhaPlant(Vector2 position)
    {
        physics = new EntityPhysics(this);
        this.position = position;
        currentState = new HiddenPiranhaState();
    }

    public override void Update(GameTime gameTime)
    {
        ClearCollisions();

        CollisionManager.Instance.Run(this);
        currentState.Update(gameTime);

        if (attackCooldown > 0)
        {
            attackCooldown -= gameTime.ElapsedGameTime.TotalSeconds;
        }
        else
        {
            if (isInPipe)
            {
                // Condition to check if Mario is not too close
                if (!MarioIsAbove())
                {
                    Emerge();
                }
            }
            else
            {
                Retract();
            }
        }
    }

    public void Emerge()
    {
        currentState = new EmergingPiranhaState();
        isInPipe = false;
        attackCooldown = EntitySettings.PiranhaCooldownTime; // Reset cooldown timer
    }

    public void Retract()
    {
        currentState = new RetractingPiranhaState();
        isInPipe = true;
    }

    public void Bite()
    {
        if (isInPipe) return;
        //MediaManager.Instance.PlayEffect(EffectNames.bite);
        currentState = new BitingPiranhaState();
    }

    public bool IsHidden()
    {
        return isInPipe;
    }

    public AbstractEntityState CurrentState
    {
        get { return currentState; }
    }

    private bool MarioIsAbove()
    {
        // Retrieve the hero (Mario) using the GameContentManager
        IHero mario = GameContentManager.Instance.GetHero();
        Vector2 marioPosition = mario.GetPosition();

        // Check if Mario's X position aligns with the Piranha Plant's X position
        // and Mario is directly above the Piranha Plant
        return marioPosition.X == this.position.X && marioPosition.Y < this.position.Y;
    }

    public bool ReportIsAlive()
    {
        // Piranha Plant doesn't have a death state in traditional sense, always returns true unless removed from game
        return true;
    }

    public Vector2 GetVelocity()
    {
        return physics.GetVelocity(); // Generally zero since Piranha Plants don't move horizontally
    }
}

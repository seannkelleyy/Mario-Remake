using Mario.Collisions;
using Mario.Entities.Character.HeroStates;
using Mario.Entities.Hero;
using Mario.Entities.Projectiles;
using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using static Mario.Global.CollisionVariables;
using static Mario.Global.HeroVariables;


namespace Mario.Entities.Character
{
    public class Hero : IHero
    {
        private HeroStateManager stateManager; // Strategy Pattern
        private HeroPhysics physics; // Strategy Pattern
        public HeroState currentState { get; set; }
        private Vector2 position;
        private int health = 1;
        private bool isInvunerable;
        private double iFrames;
        private const double invincibleTime = 4.0;
        private Dictionary<CollisionDirection, bool> collisions = new Dictionary<CollisionDirection, bool>()
        {
            { CollisionDirection.Top, false },
            { CollisionDirection.Bottom, false },
            { CollisionDirection.Left, false },
            { CollisionDirection.Right, false },
            { CollisionDirection.None, true }
        };
        public Hero(string startingPower, Vector2 position)
        {
            this.position = position;
            physics = new HeroPhysics(this);
            stateManager = new HeroStateManager(this);

            switch (startingPower)
            {
                case "small":
                    health = 1;
                    break;
                case "big":
                    health = 2;
                    break;
                case "fire":
                    health = 3;
                    break;
            }
            stateManager.SetState(HeroStateType.StandingRight, health);
            isInvunerable = false;
            iFrames = 0;
        }

        public void Update(GameTime gameTime)
        {
            // Reset all collision states to false at the start of each update
            foreach (var direction in Enum.GetValues(typeof(CollisionDirection)))
            {
                SetCollisionState((CollisionDirection)direction, false);
            }
            currentState.Update(gameTime);

            // Check if Mario is invunerable 
            iFrames += gameTime.ElapsedGameTime.TotalSeconds;
            if (isInvunerable && (iFrames > invincibleTime))
            {
                isInvunerable = false;
                iFrames = 0.0;
            }

            CollisionManager.Instance.Run(this);
            physics.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, position);
        }

        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public bool GetCollisionState(CollisionDirection direction)
        {
            return collisions[direction];
        }

        public void SetCollisionState(CollisionDirection direction, bool state)
        {
            collisions[direction] = state;
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, (int)currentState.GetVector().X, (int)currentState.GetVector().Y);
        }

        public Vector2 GetVelocity()
        {
            return physics.GetVelocity();
        }
        public void WalkLeft()
        {
            if (stateManager.GetStateType() == HeroStateType.MovingLeft)
            {
                physics.WalkLeft();
                return;
            }
            physics.setHorizontalDirecion(false);
            stateManager.SetState(HeroStateType.MovingLeft, health);
        }

        public void WalkRight()
        {
            if (stateManager.GetStateType() == HeroStateType.MovingRight)
            {
                physics.WalkRight();
                return;
            }
            physics.setHorizontalDirecion(true);
            stateManager.SetState(HeroStateType.MovingRight, health);

        }

        // Mario collides with wall
        public void Stop()
        {
            physics.Stop();
            if (collisions[CollisionDirection.Left])
            {
                position.X += 2;
            } else if (collisions[CollisionDirection.Right])
            {
                position.X -= 2;
            }
        }

        public void Jump()
        {
            physics.Jump();

            if (physics.horizontalDirection)
            {
                stateManager.SetState(HeroStateType.JumpingRight, health);
            }
            else
            {
                stateManager.SetState(HeroStateType.JumpingLeft, health);
            }
        }

        public void Crouch()
        {
            stateManager.SetState(HeroStateType.Crouching, health);
        }

        void IHero.Collect(IItem item)
        {
            if (health < 3)
            {
                health++;
            }
        }

        void IHero.TakeDamage()
        {
            if (!isInvunerable)
            {
                health--;
                if (health == 0)
                {
                    Die();
                }
                isInvunerable = true;
                stateManager.SetState(stateManager.GetStateType(), health);
            }
        }

        void IHero.Attack()
        {
            GameContentManager.Instance.AddEntity(new Fireball(position, physics.getHorizontalDirecion()));
            stateManager.SetState(HeroStateType.AttackingRight, health);

        }

        public void Die()
        {
            health = 0;
            stateManager.SetState(HeroStateType.Dead, health);
            GameContentManager.Instance.RemoveEntity(this);
        }

        public int ReportHealth()
        {
            return health;
        }
    }
}
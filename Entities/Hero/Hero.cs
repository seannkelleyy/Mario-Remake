using Mario.Collisions;
using Mario.Entities.Hero;
using Mario.Entities.Projectiles;
using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using static Mario.Global.CollisionVariables;
using static Mario.Global.HeroVariables;


namespace Mario.Entities.Character
{
    public class Hero : AbstractCollideable, IHero
    {
        private HeroStateManager stateManager; // Strategy Pattern
        private int health;
        private bool isInvunerable;
        private double iFrames;
        private const double invincibleTime = 3.0;
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

        public override void Update(GameTime gameTime)
        {
            // Reset all collision states to false at the start of each update
            foreach (var direction in Enum.GetValues(typeof(CollisionDirection)))
            {
                SetCollisionState((CollisionDirection)direction, false);
            }
            currentState.Update(gameTime);
            CollisionManager.Instance.Run(this);

            // Check if Mario is invunerable 
            if (isInvunerable)
            {
                iFrames += gameTime.ElapsedGameTime.TotalSeconds;
                if (iFrames > invincibleTime){
                    isInvunerable = false;
                    iFrames = 0.0;
                }
            }

            physics.Update();
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
        public void StopHorizontal()
        {
            physics.StopHorizontal();
            if (collisions[CollisionDirection.Left])
            {
                position.X += 2;
            } else if (collisions[CollisionDirection.Right])
            {
                position.X -= 2;
            }
        }

        // Mario collides with bottom of block
        public void StopVertical()
        {
            physics.StopVertical();
            if (collisions[CollisionDirection.Top])
            {
                position.Y += 5;
            }
        }

        public void Jump()
        {
            physics.Jump();

            if (physics.isRight)
            {
                stateManager.SetState(HeroStateType.JumpingRight, health);
            }
            else
            {
                stateManager.SetState(HeroStateType.JumpingLeft, health);
            }
        }

        public void SmallJump()
        {
            physics.SmallJump();

            if (physics.isRight)
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
                isInvunerable = true;
                health--;
                if (health == 0)
                {
                    Die();
                }
                else if (health == 1)
                {
                    position.Y += 16;
                }
                stateManager.SetState(stateManager.GetStateType(), health);
            }
        }

        void IHero.Attack()
        {
            GameContentManager.Instance.AddEntity(new Fireball(position));
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
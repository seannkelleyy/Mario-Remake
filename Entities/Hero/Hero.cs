using Mario.Entities.Character.HeroStates;
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

namespace Mario.Entities.Character
{
    public class Hero : IHero
    {
        public HeroState currentState { get; set; }
        private Vector2 position;
        private HeroPhysics physics;
        private int health = 1;
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
            currentState = new StandingRightState();

            switch (startingPower)
            {
                case "small":
                    currentState = new StandingRightState();
                    health = 1;
                    break;
                case "big":
                    currentState = new StandingRightBigState();
                    health = 2;
                    break;
                case "fire":
                    currentState = new StandingRightFireState();
                    health = 3;
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            physics.Update();
            currentState.Update(gameTime);

            // Reset all collision states to false at the start of each update
            foreach (var direction in Enum.GetValues(typeof(CollisionDirection)))
            {
                SetCollisionState((CollisionDirection)direction, false);
            }
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
            if (currentState is LeftMovingState)
            {
                physics.WalkLeft();
                return;
            }
            currentState = new LeftMovingState();
        }

        public void WalkRight()
        {
            if (currentState is RightMovingState)
            {
                physics.WalkRight();
                return;
            }
            currentState = new RightMovingState();
        }

        public void Jump()
        {
            physics.Jump();

            if (physics.horizontalDirection)
            {
                currentState = new JumpRightFireState();
            }
            else
            {
                currentState = new JumpLeftFireState();
            }
        }

        public void Crouch()
        {
            currentState = new CrouchFireState();
        }

        void IHero.Collect(IItem item)
        {
            currentState = new CollectState();
            if (health < 3)
            {
                health++;
            }
        }

        void IHero.TakeDamage()
        {
            health--;
            if (health == 0)
            {
                Die();
            }
        }

        void IHero.Attack()
        {
            bool facingLeft = false;
                GameContentManager.Instance.AddEntity(new Fireball(position,facingLeft));
        }

        public void Die()
        {
            currentState = new DeadState();
        }

        public int ReportHealth()
        {
            return health;
        }
    }
}
using Mario.Collisions;
using Mario.Entities.Character.HeroStates;
using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using static Mario.Global.CollisionVariables;
using static Mario.Physics.HeroPhysics;


namespace Mario.Entities.Character
{
    public class Hero : IHero
    {
        private HeroPhysics physics; // Strategy Pattern
        public HeroState currentState { get; set; }
        private Vector2 position;
        public enum health { Mario, BigMario, FireMario };
        public health currentHealth = health.Mario;
        // True is right, false is left
        private Dictionary<CollisionDirection, bool> collisions = new Dictionary<CollisionDirection, bool>()
        {
            { CollisionDirection.Top, false },
            { CollisionDirection.Bottom, false },
            { CollisionDirection.Left, false },
            { CollisionDirection.Right, false },
            { CollisionDirection.None, true }
        };
        public Hero(Vector2 position)
        {
            this.position = position;
            physics = new HeroPhysics(this);
            currentState = new StandState(this);
        }
        public Hero(string startingPower, Vector2 position)
        {
            currentHealth = health.FireMario;
            this.position = position;
            physics = new HeroPhysics(this);
            currentState = new StandState(this);
        }

        public void Update(GameTime gameTime)
        {
            // Reset all collision states to false at the start of each update
            foreach (var direction in Enum.GetValues(typeof(CollisionDirection)))
            {
                SetCollisionState((CollisionDirection)direction, false);
            }
            currentState.Update(gameTime);
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
        public horizontalDirection getHorizontalDirection()
        {
            return physics.getHorizontalDirection();
        }

        public void WalkLeft()
        {
            currentState.WalkLeft();
        }

        public void WalkRight()
        {
            currentState.WalkRight();
        }
        public void Stand()
        {
            currentState.Stand();
        }

        // Mario collides with wall
        public void StopHorizontal()
        {
            physics.StopHorizontal();
            if (collisions[CollisionDirection.Left])
            {
                position.X += 2;
            }
            else if (collisions[CollisionDirection.Right])
            {
                position.X -= 2;
            }
        }

        // Mario collides with bottom of block
        public void StopVertical()
        {
            physics.StopHorizontal();
            if (collisions[CollisionDirection.Top])
            {
                position.Y += 4;
            }
        }

        public void Jump()
        {
            currentState.Jump();
        }

        public void Crouch()
        {
            currentState.Crouch();
        }

        void IHero.PowerUp(IItem item)
        {
            currentState.PowerUp();
        }

        void IHero.TakeDamage()
        {
            currentState.TakeDamage();
        }

        void IHero.Attack()
        {
            currentState.Attack();
        }

        public void Die()
        {
            currentState.Die();
        }
        public health ReportHealth()
        {
            return this.currentHealth;
        }
        public HeroPhysics GetPhysics()
        {
            return physics;
        }
    }
}
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
        private HeroPhysics physics;
        public enum health { Mario, BigMario, FireMario };
        public health currentHealth=health.Mario;
        // True is right, false is left
        public enum direction { left, right };
        public direction currentDirection = direction.left;
        public Hero(Vector2 position)
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
            physics.WalkLeft();
            currentState.WalkLeft();
        }

        public void WalkRight()
        {
            physics.WalkRight();
            currentState.WalkRight();
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
            physics.StopHorizontal();
            if (collisions[CollisionDirection.Top])
            {
                position.Y += 4;
            }
        }

        public void Jump()
        {
            physics.Jump();
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
            GameContentManager.Instance.AddEntity(new Fireball(position, physics.getHorizontalDirecion()));
            stateManager.SetState(HeroStateType.AttackingRight, health);

        }

        public void Die()
        {
            currentState.Die();
        }


    public void HandleCollision(ICollideable collideable, Dictionary<CollisionDirection, bool> collisionDirection)
        {
            // verrryyyyy basic collision response, jsut needed something to get by for this ticket.
            if (collideable is IEnemy)
            {
                if (collisionDirection[CollisionDirection.Bottom])
                {
                    ((IEnemy)collideable).Stomp();
                }
                else
                {
                }
            }
        }

        public health ReportHealth () {
            return this.currentHealth;
        }
    }
}
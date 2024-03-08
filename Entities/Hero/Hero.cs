using Mario.Entities.Character.HeroStates;
using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public Hero(Vector2 position)
        {
            this.position = position;
            physics = new HeroPhysics(this);
            currentState = new StandingRightState();
        }

        public void Update(GameTime gameTime)
        {
            physics.Update();
            currentState.Update(gameTime);
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
            return this.position;
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
                currentState = new JumpStateRight();
            }
            else
            {
                currentState = new JumpStateLeft();
            }
        }

        public void Crouch()
        {
            currentState = new CrouchState();
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
            // Make mario shoot fireball
        }

        public void Die()
        {
            currentState = new DeadState();
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

        public int ReportHealth () {
            return this.health;
        }
    }
}
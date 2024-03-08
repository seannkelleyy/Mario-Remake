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
        public enum health { Mario, BigMario, FireMario };
        public health currentHealth=health.Mario;
        // True is right, false is left
        public enum direction { left, right };
        public direction currentDirection = direction.left;
        public Hero(Vector2 position)
        {
            this.position = position;
            physics = new HeroPhysics(this);
            currentState = new StandState();
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
            return position;
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

        public void Jump()
        {
            physics.Jump();
            currentState.Jump();
        }

        public void Crouch()
        {
            currentState.Crouch();
        }

        void IHero.Collect(IItem item)
        {
            currentState = new CollectState();
        }

        void IHero.TakeDamage()
        {
            currentState.TakeDamage();
        }

        void IHero.Attack()
        {
            // Make mario shoot fireball
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
    }
}
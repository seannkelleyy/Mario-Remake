using Mario.Collisions;
using Mario.Entities.Hero;
using Mario.Entities.Projectiles;
using Mario.Entities.Character.HeroStates;
using Mario.Entities.Projectiles;
using Mario.Entities.Projectiles;
using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Mario.Global.CollisionVariables;
using static Mario.Physics.HeroPhysics;


namespace Mario.Entities.Character
{
        private HeroStateManager stateManager; // Strategy Pattern
        private int health;
        private int lives;
        private bool isInvunerable;
        private double iFrames;
        private const double invincibleTime = 3.0;
        private bool isFlashing = false;
        private double flashIntervalTimer = 0.0;
        private const double flashDuration = 0.05;

        public Hero(string startingPower, int lives, Vector2 position)
        private HeroPhysics physics; // Strategy Pattern
        public HeroState currentState { get; set; }
        private Vector2 position;
        public enum health { Mario, BigMario, FireMario };
        public health currentHealth = health.Mario;
        // True is right, false is left
        private Dictionary<CollisionDirection, bool> collisions = new Dictionary<CollisionDirection, bool>()
        private Dictionary<CollisionDirection, bool> collisions = new Dictionary<CollisionDirection, bool>()
        private Dictionary<CollisionDirection, bool> collisions = new Dictionary<CollisionDirection, bool>()
            { CollisionDirection.Top, false },
            { CollisionDirection.Bottom, false },
            { CollisionDirection.Left, false },
            { CollisionDirection.Right, false },
            { CollisionDirection.None, true }
        };
        public Hero(string startingPower, Vector2 position)
        {
            this.position = position;
            stateManager = new HeroStateManager(this);
            this.position = position;
            this.lives = lives;

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
            this.lives = lives;
        }
            currentState = new StandState(this);
        }
        public Hero(string startingPower, Vector2 position)
        {
            currentHealth = health.FireMario;
            this.position = position;
            physics = new HeroPhysics(this);
            currentState = new StandState(this);
        }
        }
        }

        public override void Update(GameTime gameTime)
        {
            // Reset all collision states to false at the start of each update
            foreach (var direction in Enum.GetValues(typeof(CollisionDirection)))
            {
                SetCollisionState((CollisionDirection)direction, false);
            }
            CollisionManager.Instance.Run(this);
            // Check if Mario is invunerable 
            if (isInvunerable)
            {
                flashIntervalTimer += gameTime.ElapsedGameTime.TotalSeconds;
                if (flashIntervalTimer > flashDuration)
                {
                    isFlashing = !isFlashing;
                    flashIntervalTimer = 0.0;
                }
                iFrames += gameTime.ElapsedGameTime.TotalSeconds;
                if (iFrames > invincibleTime)
                {
                    isInvunerable = false;
                    iFrames = 0.0;
                }
            }


            physics.Update();
        }

        public new virtual void Draw(SpriteBatch spriteBatch)
        {
            if (!isFlashing || !isInvunerable)
            {
                currentState.Draw(spriteBatch, position);
            }
        }
        public horizontalDirection getHorizontalDirection()
        {
            return physics.getHorizontalDirection();
        }

            currentState.WalkLeft();
        }
        }
        }

            currentState.WalkRight();
        }
        public void Stand()
        {
            currentState.Stand();


        }

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

        public void StopVertical()
        {
            physics.StopVertical();
            if (collisions[CollisionDirection.Top])
            {
                position.Y += 5;
            }
        }

            currentState.Jump();
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
            }
        }

        public void Crouch()
        {
            currentState.Crouch();
        void IHero.PowerUp(IItem item)
        {
            currentState.PowerUp();
            }
            }
        }

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
            currentState.TakeDamage();
            }
            }
        void IHero.Attack()
        {
            currentState.Attack();


        }

            lives--;
            stateManager.SetState(HeroStateType.Dead, health);
            LevelLoader.Instance.ChangeMarioLives($"../../../Levels/Sprint3.json", lives);

            // Check if the player still has lives. If so, reset the game but with one less life. Else, game over
            if (lives != 0)
            {
                GameStateManager.Instance.BeginReset();
            }
            else
            {
                lives = 10;
                GameStateManager.Instance.Restart();
            }
            currentState.Die();
        }
        public health ReportHealth()
        {
            return this.currentHealth;
            GameContentManager.Instance.RemoveEntity(this);
            GameContentManager.Instance.RemoveEntity(this);
        }
        public HeroPhysics GetPhysics()
        {
            return physics;
        }
    }
}
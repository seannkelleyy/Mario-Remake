using Mario.Global;
using Mario.Interfaces.Base;
using Microsoft.Xna.Framework;
using static Mario.Global.CollisionVariables;

namespace Mario.Physics
{
    public class StarPhysics : AbstractEntityPhysics
    {
        public StarPhysics(ICollideable entity) : base(entity)
        {
            this.entity = entity;
            velocity = new Vector2(0, 0);
            isFalling = false;
        }

        public override void Update()
        {
            UpdateVertical();
            UpdateHorizontal();
        }

        internal override void UpdateHorizontal()
        {
            if (isRight && !entity.GetCollisionState(CollisionDirection.Right))
            {
                    velocity.X = PhysicsVariables.enemySpeed;
            }
            else if (!isRight && !entity.GetCollisionState(CollisionDirection.Left))
            {
                    velocity.X = -PhysicsVariables.enemySpeed;
            }

            entity.SetPosition(entity.GetPosition() + new Vector2(velocity.X, 0));
        }

        internal override void UpdateVertical()
        {
            if (isFalling)
            {
                HandleDownwardMovement();
            }
            else 
            {
                if (jumpCounter == 0)
                {
                    Jump();
                }
                else
                {
                    HandleUpwardMovement();
                }
            }

            if (isDecelerating)
            {
                velocity.Y += PhysicsVariables.decelerationFactor;
                if (velocity.Y >= 0)
                {
                    // Once upward velocity reaches 0, start falling and stop decelerating
                    velocity.Y = 0;
                    isFalling = true;
                    isDecelerating = false;
                }
            }
            entity.SetPosition(entity.GetPosition() + new Vector2(0, velocity.Y));
            StopVertical();
        }

        public override void WalkLeft()
        {
            Logger.Instance.LogInformation("Walk left not implemented in Entity Physics");
        }

        public override void WalkRight()
        {
            Logger.Instance.LogInformation("Walk right not implemented in Entity Physics");

        }

        public override void Jump()
        {
            isFalling = false;
            velocity.Y = -PhysicsVariables.jumpForce;
            jumpCounter = 1;
        }

        private void HandleUpwardMovement()
        {
            if (entity.GetCollisionState(CollisionDirection.Top) || isMininumJump && jumpCounter >= PhysicsVariables.minimumJump)
            {
                jumpCounter = PhysicsVariables.regularJumpLimit;
                isFalling = true;
                isMininumJump = false;
                isDecelerating = true;
            }
            else if (jumpCounter < PhysicsVariables.regularJumpLimit && jumpCounter > 0 && !entity.GetCollisionState(CollisionDirection.Top))
            {
                velocity.Y = -PhysicsVariables.jumpForce * (1 - jumpCounter / PhysicsVariables.regularJumpLimit);
                jumpCounter++;
            }
            else
            {
                isFalling = true;
            }
        }

        private void HandleDownwardMovement()
        {
            if (!entity.GetCollisionState(CollisionDirection.Bottom))
            {
                velocity.Y += ApplyGravity();
            }
            else
            {
                jumpCounter = 0;
                StopVertical();
                isFalling = false;
            }
        }

        public override void SmallJump()
        {
            Logger.Instance.LogInformation("Small Jump left not implemented in Entity Physics");
        }
    }
}

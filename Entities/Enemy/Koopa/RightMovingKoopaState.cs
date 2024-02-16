using Mario.Interfaces;
using Microsoft.Xna.Framework;

    public class RightMovingKoopaState : IEnemyState
    {
        private Koopa koopa;

        public RightMovingKoopaState(Koopa koopa)
        {
            this.koopa = koopa;
            // construct goomba's sprite here too
        }

        public void ChangeDirection()
        {
            koopa.state = new LeftMovingKoopaState(koopa);
        }

        public void BeStomped()
        {
            koopa.state = new StompedKoopaState(koopa);
        }

        public void BeFlipped()
        {
            koopa.state = new FlippedKoopaState(koopa);
        }

        public void Update(GameTime gameTime)
        {
            koopa.MoveRight();
        }
    }

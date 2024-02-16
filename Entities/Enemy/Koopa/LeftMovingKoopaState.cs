using Mario.Interfaces;
using Microsoft.Xna.Framework;

    public class LeftMovingKoopaState : IEnemyState
    {
        private Koopa koopa;

        public LeftMovingKoopaState(Koopa koopa)
        {
            this.koopa = koopa;
            // construct koopa's sprite here too
        }

        public void ChangeDirection()
        {
            koopa.state = new RightMovingKoopaState(koopa);
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
            koopa.MoveLeft();
        }
    }

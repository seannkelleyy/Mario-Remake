using Mario.Interfaces;
using Microsoft.Xna.Framework;

    public class StompedKoopaState : IEnemyState
    {
        private Koopa koopa;

        public StompedKoopaState(Koopa koopa)
        {
            this.koopa = koopa;
            // construct goomba's sprite here too
        }

        public void ChangeDirection()
        {
            //NO-OP
        }

        public void BeStomped()
        {
            // NO-OP
            // already stomped, do nothing
        }

        public void BeFlipped()
        {
            // NO-OP
            // if stomped, do not respond to being attacked by star mario (assumed but not tested behavior)
        }


        public void Update(GameTime gameTime)
        {
        // call something like koopa.Stomp()
    }
}


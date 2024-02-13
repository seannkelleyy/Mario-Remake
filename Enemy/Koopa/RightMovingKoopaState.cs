using GreenGame.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class RightMovingKoopaState : IEnemy
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

        public void Update()
        {
            // call something like goomba.MoveLeft() or goomba.Move(-x,0);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {

        }
    }

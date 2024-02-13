﻿using GreenGame.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class StompedKoopaState : IEnemy
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

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {

        }
    }


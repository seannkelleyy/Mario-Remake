using GreenGame.Interfaces;
using GreenGame.Interfaces.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Character
{
    public class MarioStandingState : IHeroState
    {
        private Mario mario;
        //true be left, false be right
        private bool direction;


        public MarioStandingState(Mario mario, bool direction)
        {
            this.mario = mario;
            this.direction = direction;
            // construct goomba's sprite here too
        }


        public void ChangeDirection()
        {
            if (this.direction)//turn left
            {
                this.direction = false;
                mario.state = new MarioStandingState(this.mario, this.direction);
            } else
            {
                this.direction = true;
                mario.state = new MarioStandingState(this.mario, this.direction);
            }
        }

        public void Update(GameTime gameTime)
        {
            // call something like goomba.MoveLeft() or goomba.Move(-x,0);
        }

    }
}
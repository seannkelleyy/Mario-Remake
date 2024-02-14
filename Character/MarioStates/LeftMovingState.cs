using GreenGame.Interfaces;
using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenGame.Character.MarioStates
{
    public class LeftMovingState : IHeroState
    {
        private Mario mario;
        //true be left, false be right
        private bool direction;


        public LeftMovingState(Mario mario, ISprite sprite = SpriteFactory.Instance.CreateSprite("marioStandLeft"))
        {
            this.mario = mario;
        }


        public void ChangeDirection()
        {
            if (direction)//turn left
            {
                direction = false;
                mario.currentState = new LeftMovingState(mario, direction);
            }
            else
            {
                direction = true;
                mario.currentState = new LeftMovingState(mario, direction);
            }
        }
                
        public void Update(GameTime gameTime)
        {
            // call something like goomba.MoveLeft() or goomba.Move(-x,0);
        }

    }
}
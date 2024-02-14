using GreenGame.Interfaces;
using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mario.Character;
using Mario.Sprites;

namespace GreenGame.Character.MarioStates
{
    public class StandingState : IHeroState
    {
        private IHero mario;
        //true be left, false be right
        private bool direction;
        private ISprite sprite;
        private Texture2D texture;
        private int[] spriteParams;


        public StandingState(IHero mario, bool direction, ISprite sprite)
        {
            this.mario = mario;
            this.direction = direction;
            // construct goomba's sprite here too
            this.spriteParams;

        }


        public void ChangeDirection()
        {
            if (direction)//turn left
            {
                direction = false;
                //Sprite(Texture2D texture, int[] spriteParams)
                sprite = new Sprite(texture, spriteParams);
                mario.currentState = new StandingState(mario, direction,sprite);
            }
            else
            {
                direction = true;
                mario.currentState = new MarioStandingState(mario, direction);
            }
        }

        public void Update(GameTime gameTime)
        {
            // call something like goomba.MoveLeft() or goomba.Move(-x,0);
        }

    }
}
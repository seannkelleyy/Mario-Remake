using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GreenGame.Character.MarioStates
{
    public class State : IHeroState
    {
        private Dictionary<String, ISprite> Actions;
        private ISprite currentSprite;
        private String nameOfCurrentSprite;

        public State(Dictionary<String, ISprite> actions, ContentManager content)
        {
            this.Actions = actions;
            currentSprite = actions[nameOfCurrentSprite];

            SpriteFactory.Instance.LoadAllTextures(content);
            currentSprite = SpriteFactory.Instance.CreateSprite("marioStandLeft");
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            currentSprite.Draw(spriteBatch, position);
        }

        public void Update(GameTime gameTime)
        {
            //currentSprite = Actions[name];
            currentSprite.Update(gameTime);
        }

    }
}

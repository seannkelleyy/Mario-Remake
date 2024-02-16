using Mario.Interfaces;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Entities.Enemy
{
    public abstract class EnemyState
    {
        private SpriteBatch _spriteBatch;
        private SpriteFactory _spriteFactory;
        public ISprite _sprite;

        public EnemyState(SpriteBatch spriteBatch)
        {
            _spriteFactory = SpriteFactory.Instance;

            _spriteBatch = spriteBatch;
            _sprite = _spriteFactory.CreateSprite("");
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch, Vector2 position);
    }
}

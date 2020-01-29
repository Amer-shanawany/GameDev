using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev
{
    public abstract class State
    {
        protected ContentManager _contentManager;
        protected GraphicsDevice _graphicDevice;
        protected Game1 _game;
        public State(Game1 game1,GraphicsDevice graphicsDevice,ContentManager contentManager)
        {
            _game = game1;
            _contentManager = contentManager;
            _graphicDevice = graphicsDevice;
        }
        public abstract void Draw(GameTime gameTime,SpriteBatch spriteBatch);
        public abstract void Update(GameTime gameTime);
        public abstract void PostUpdate(GameTime gametime);

    }
}

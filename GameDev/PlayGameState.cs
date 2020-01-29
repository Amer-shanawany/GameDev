using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameDev
{
    public enum GameStateEnum
    {
        MainMenu,
        PlayLevelOne,
        PlayLevelTwo,
        GameOver
    }
    public abstract class PlayGameState : State
    {

        public PlayGameState(Game1 game1,GraphicsDevice graphicsDevice,ContentManager contentManager)
            : base(game1,graphicsDevice,contentManager)
        {

        }

        public override void Draw(GameTime gameTime,SpriteBatch spriteBatch)
        {

        }

        public override void PostUpdate(GameTime gametime)
        {
           
        }

        public override void Update(GameTime gameTime)
        {
       
        }
    }

}

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
    public class MenuState : State 
    {
        private List<Component> _components;

        public MenuState(Game1 game1,GraphicsDevice graphicsDevice,ContentManager contentManager) 
            : base(game1,graphicsDevice,contentManager)
        { 
            var buttonTexture = _contentManager.Load<Texture2D>("button");
            var buttonFont = _contentManager.Load<SpriteFont>("font");
            var newGameButton = new Button(buttonTexture,buttonFont)
            {
                Position = new Vector2(GraphicsDeviceManager.DefaultBackBufferWidth / 2,
                GraphicsDeviceManager.DefaultBackBufferHeight / 2),
                Text = "New Game"
            };
            newGameButton.Click += newGameButton_Click;

            var quitGameButton = new Button(buttonTexture,buttonFont)
            {
                Position = new Vector2(GraphicsDeviceManager.DefaultBackBufferWidth / 2,
                (GraphicsDeviceManager.DefaultBackBufferHeight / 2)+ (buttonTexture.Height *1.5f)),
                Text = "Quit"
            };
            quitGameButton.Click += quitGameButton_Click; 

            _components = new List<Component>()
            {
                newGameButton,
                quitGameButton
            };
        }

        private void quitGameButton_Click(object sender,EventArgs e)
        {
            _game.Exit();
        }

        private void newGameButton_Click(object sender,EventArgs e)
        {
            //Start Game Level One! 
            _game.ChangeState(new LevelOneState(_game,_graphicDevice,_contentManager));
            //_game.State = GameState.PlayLevelOne;
        }

        public override void Draw(GameTime gameTime,SpriteBatch spriteBatch)
        {
            foreach(var component in _components)
            {
                component.Draw(spriteBatch);
            }

        }

        public override void PostUpdate(GameTime gametime)
        {
        }

        public override void Update(GameTime gameTime)
        {
         }
    }
}

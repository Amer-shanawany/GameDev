using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace GameDev
{
  

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Hero myHero;

        Level level1;
        Sprite sprite1;
        private List<Sprite> _sprites;
            public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

     

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }



        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var myHeroAnimation = new Dictionary<string,Texture2D>
            {
                {"right",Content.Load<Texture2D>("walkingRight") },
                {"left",Content.Load<Texture2D>("walkingLeft") },
                {"idle",Content.Load<Texture2D>("walkingDown") }
            };
            _sprites = new List<Sprite>();
            myHero = new Hero(myHeroAnimation,new Vector2(250,100),3,50);
            myHero.Input = new ArrowKeys();
            //Texture2D TempTexture = Content.Load<Texture2D>("walkingRight");
            //sprite1 = new Sprite(TempTexture,new Vector2(200,200));
            level1 = new Level(Content.Load<Texture2D>("block"),16,10);
            level1.tileArray = new Byte[,] { 
                { 1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1 },
                { 1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1 },
                { 1,0,0,0,0,0,1,1,1,1,0,0,0,0,0,1 },
                { 1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1 },
                { 1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1 },
                { 1,0,0,0,0,0,1,1,1,0,0,0,0,1,1,1 },
                { 1,0,0,0,1,0,0,0,0,0,1,1,0,0,0,1 },
                { 1,0,0,1,1,0,0,0,0,0,0,0,0,0,0,1 },
                { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 }

            };
            level1.CreateWorld();
            
            foreach(var block in level1.ToArray())
            {
                _sprites.Add(block);
            }
            


            _sprites.Add(myHero);
        }


        protected override void UnloadContent()
        {
          

        }

       

        protected override void Update(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            myHero.Update(gameTime);
            foreach(var sprite in _sprites)
            {
                if(sprite is Hero)
                {
                    sprite.Update(gameTime,_sprites);
                }
            }
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            //Debug mode
            
           //spriteBatch.Begin(SpriteSortMode.Immediate,BlendState.Opaque);
           //RasterizerState state = new RasterizerState();
           //state.FillMode = FillMode.WireFrame;

            //End Debug section 


            spriteBatch.Begin();

            GraphicsDevice.Clear(Color.CornflowerBlue);

            //sprite1.Draw(spriteBatch);
            //block1.Draw(spriteBatch);
            //level1.DrawWorld(spriteBatch);
            //myHero.Draw(spriteBatch);
            foreach(var sprite in _sprites)
            {
                sprite.Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

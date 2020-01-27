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
        public static int ScreenHeight;
        public static int ScreenWidth;
        Camera2D camera;
        Hero myHero;
        SpriteFont _font;

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
            ScreenHeight = graphics.PreferredBackBufferHeight;
            ScreenWidth = graphics.PreferredBackBufferWidth;
            base.Initialize();
        }



        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            camera = new Camera2D();
            var myHeroAnimation = new Dictionary<string,Texture2D>
            {
                {"right",Content.Load<Texture2D>("walkingRight") },
                {"left",Content.Load<Texture2D>("walkingLeft") },
                {"idle",Content.Load<Texture2D>("walkingDown") }
            };
            _sprites = new List<Sprite>();
            myHero = new Hero(myHeroAnimation,new Vector2(250,100),3,50);// {Bullet = new Bullet(Content.Load<Texture2D>("bullet"); };
            myHero.Bullet = new Bullet(Content.Load<Texture2D>("bullet"),myHero._position);
            myHero.Input = new ArrowKeys();
            //Texture2D TempTexture = Content.Load<Texture2D>("walkingRight");
            //sprite1 = new Sprite(TempTexture,new Vector2(200,200));
            level1 = new Level(Content.Load<Texture2D>("block"), new Dictionary<string,Texture2D> { { "idle",Content.Load<Texture2D>("coin_1") } },16,10);
           // level1 = new Level(Content.Load<Texture2D>("block"),myHeroAnimation,16,10);

            level1.tileArray = new Byte[,] { 
                { 1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1 },
                { 1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1 },
                { 1,0,0,0,0,0,1,1,1,1,0,0,0,0,0,1 },
                { 1,0,0,0,0,2,0,0,0,0,1,0,2,0,0,1 },
                { 1,0,2,0,0,0,0,0,0,0,0,1,0,0,0,1 },
                { 1,0,0,0,0,0,1,1,1,0,0,2,0,1,1,1 },
                { 1,0,0,2,1,0,0,0,0,0,1,1,1,0,0,1 },
                { 1,0,0,1,1,2,0,0,0,0,0,0,0,0,0,1 },
                { 1,0,0,0,0,0,2,0,0,0,0,0,0,0,0,1 },
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 }

            };
            level1.CreateWorld();
            
            foreach(var block in level1.ToArray())
            {
                _sprites.Add(block);
            }
            foreach(var coin in level1.ToArrayCoins())
            {
                _sprites.Add(coin);
            }
            
            



            _font = Content.Load<SpriteFont>("Font");
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
            foreach(var sprite in _sprites.ToArray())
            {
                if(sprite is Hero)
                {
                    sprite.Update(gameTime,_sprites);
                    camera.Follow(sprite);
                }
                if(sprite is Coin )
                {
                     
                    sprite.Update(gameTime);
                }
               if(sprite is Bullet)
              {
                  sprite.Update(gameTime,_sprites);
              }
            }
            for(int i = 0; i < _sprites.Count; i++)
            {
                if(_sprites[i].IsRemoved)
                {
                    _sprites.RemoveAt(i);
                    i--;
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


            spriteBatch.Begin(transformMatrix: camera.Transform);

            GraphicsDevice.Clear(Color.TransparentBlack);

            //sprite1.Draw(spriteBatch);
            //block1.Draw(spriteBatch);
            //level1.DrawWorld(spriteBatch);
            //myHero.Draw(spriteBatch);
          
            foreach(var sprite in _sprites)
            {
                 
                 
                    sprite.Draw(spriteBatch);
                 
                 
            }
            spriteBatch.DrawString(_font,string.Format("Score "+ myHero.Score),new Vector2 ( 25 + myHero._position.X - (ScreenWidth/2) ,25 + myHero._position.Y - (ScreenHeight/2)),Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

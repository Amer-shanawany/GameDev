using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace GameDev
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public static int ScreenHeight;
        public static int ScreenWidth;
        public static GameState GameState = GameState.LevelOne;

        private Camera2D camera;
        private Camera2D camera2;
        private Hero myHero;
        private SpriteFont _font;

        private Level level1;
        private Level level2;

        private List<Sprite> MainMenu;
        private Sprite gameOverSprite;
        private List<Sprite> _sprites;
        private List<Sprite> _sprite2;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            ScreenHeight = graphics.PreferredBackBufferHeight;
            ScreenWidth = graphics.PreferredBackBufferWidth;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            camera = new Camera2D();
            camera2 = new Camera2D();
            _font = Content.Load<SpriteFont>("Font");
            var blockTexture = Content.Load<Texture2D>("block");
            var endBlockTexture = Content.Load<Texture2D>("endBlock");
            var myHeroAnimation = new Dictionary<string,Texture2D>
            {
                {"right",Content.Load<Texture2D>("walkingRight") },
                {"left",Content.Load<Texture2D>("walkingLeft") },
                {"idle",Content.Load<Texture2D>("walkingDown") }
            };
            var enemyTexture = Content.Load<Texture2D>("enemy");
            var enemyBulletTexture = Content.Load<Texture2D>("enemy_bullet");
            var coinAnimation = new Dictionary<string,Texture2D> { { "idle",Content.Load<Texture2D>("coin_1") } };
            var gameOverTexture = Content.Load<Texture2D>("gameover");
            gameOverSprite = new Sprite(gameOverTexture,new Vector2(0,0));
            _sprites = new List<Sprite>();
            _sprite2 = new List<Sprite>();
            myHero = new Hero(myHeroAnimation,new Vector2(55,800),3,50);
            myHero.Bullet = new Bullet(Content.Load<Texture2D>("bullet"),myHero.Position);

            myHero.Input = new ArrowKeys();
            level1 = new Level(blockTexture,endBlockTexture,coinAnimation,enemyTexture,enemyBulletTexture,16,20);
            level2 = new Level(blockTexture,endBlockTexture,coinAnimation,enemyTexture,enemyBulletTexture,16,20);

            level1.tileArray = new Byte[,] {
                { 1,0,0,0,6,0,0,0,0,0,0,0,0,0,0,1 },
                { 1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1 },
                { 1,0,0,0,0,0,1,1,1,1,0,0,0,0,0,1 },
                { 1,0,0,0,0,2,0,0,0,0,1,0,2,0,0,1 },
                { 1,0,2,0,0,0,0,0,0,0,0,1,0,0,31,1 },
                { 1,0,0,0,0,0,1,1,1,0,0,2,0,1,1,1 },
                { 1,0,0,2,1,0,0,0,0,0,1,1,1,0,0,1 },
                { 1,0,0,1,1,2,0,0,0,0,0,0,0,0,0,1 },
                { 1,0,0,0,0,0,2,0,0,0,0,0,0,0,0,1 },
                { 1,2,1,1,1,1,2,0,1,1,1,1,1,1,1,1 },
                { 1,2,2,0,1,0,1,2,2,2,0,0,0,0,0,1 },
                { 1,2,0,0,1,0,0,1,2,2,2,0,0,0,0,1 },
                { 1,2,0,0,0,0,1,1,1,1,30,0,0,0,0,1 },
                { 1,2,0,0,2,2,0,0,0,0,1,2,2,0,31,1 },
                { 1,2,2,2,0,0,0,0,0,0,0,1,0,0,1,1 },
                { 1,2,0,0,31,0,1,1,1,2,2,2,0,1,1,1 },
                { 1,0,0,2,1,0,0,0,0,0,1,1,1,0,0,1 },
                { 1,2,0,1,1,2,0,0,02,0,0,0,0,0,0,1 },
                { 1,0,2,2,0,30,2,0,31,2,0,0,0,0,31,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 }
            };

            level1.CreateWorld();
            foreach(var block in level1.ToArrayBlocks())
            {
                _sprites.Add(block);
            }
            foreach(var coin in level1.ToArrayCoins())
            {
                _sprites.Add(coin);
            }
            foreach(var enemy in level1.ToArrayEnemies())
            { _sprites.Add(enemy); }
            foreach(var endBlock in level1.ToArrayEndBlock())
            {
                _sprites.Add(endBlock);
            }

            level2.tileArray = new Byte[,] {
                { 1,1,0,0,2,0,2,2,0,0,0,0,0,0,0,1 },
                { 1,1,0,2,1,0,31,2,2,2,0,0,0,0,0,1 },
                { 1,0,0,0,0,0,1,1,1,1,0,0,2,0,0,1 },
                { 1,0,0,2,0,2,0,0,0,0,1,0,2,0,0,1 },
                { 1,0,2,0,0,0,0,0,31,0,0,1,0,0,31,1 },
                { 1,0,0,0,0,0,1,1,1,0,0,2,0,1,1,1 },
                { 1,2,0,2,1,0,0,0,0,0,1,1,1,0,0,1 },
                { 1,0,0,1,1,2,0,0,0,0,0,0,0,0,0,1 },
                { 1,0,30,0,0,0,2,2,2,0,0,0,0,0,0,1 },
                { 1,0,1,1,1,1,2,0,1,1,1,1,1,1,1,1 },
                { 1,0,0,0,1,0,1,2,2,2,0,0,0,0,0,1 },
                { 1,0,0,0,1,0,0,1,2,2,2,0,0,0,0,1 },
                { 1,0,0,0,0,0,1,1,1,1,2,2,2,0,2,1 },
                { 1,0,0,0,2,2,0,0,0,0,1,2,2,0,2,1 },
                { 1,0,2,2,0,0,0,0,0,0,0,1,0,2,1,1 },
                { 1,0,0,0,30,0,1,1,1,0,0,2,0,1,1,1 },
                { 1,1,0,2,1,0,0,0,0,0,1,1,1,0,0,1 },
                { 1,2,0,1,1,2,0,0,0,0,0,0,0,2,2,1 },
                { 1,0,30,31,0,0,2,0,0,0,2,02,2,2,31,6},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 }
            };

            level2.CreateWorld();
            foreach(var block in level2.ToArrayBlocks())
            {
                _sprite2.Add(block);
            }
            foreach(var coin in level2.ToArrayCoins())
            {
                _sprite2.Add(coin);
            }
            foreach(var enemy in level2.ToArrayEnemies())
            { _sprite2.Add(enemy); }
            foreach(var endBlock in level2.ToArrayEndBlock())
            {
                _sprite2.Add(endBlock);
            }

            _sprites.Add(myHero);

            //myHero._position = new Vector2(250,0);
            //myHero.Position = new Vector2(250,00);
            _sprite2.Add(myHero);
        }

        protected override void UnloadContent()
        {
        }

      //  private void PostUpdate(GameState gameState)
      // {
      //     switch(gameState)
      //     {
      //         case GameState.MainMenu:
      //             break;
      //
      //         case GameState.LevelOne:
      //             myHero.Position = new Vector2(250,0);
      //             break;
      //
      //         case GameState.LevelTwo:
      //             foreach(var sprite in _sprites)
      //             {
      //                 sprite.IsRemoved = true;
      //             }
      //             myHero.Position  = new Vector2(350,0);
      //             break;
      //
      //         case GameState.GameOver:
      //             foreach(var sprite in _sprite2)
      //             {
      //                 sprite.IsRemoved = true;
      //             }
      //             camera.Follow(gameOverSprite);
      //             break;
      //
      //         default:
      //             break;
      //     }
      // }

        protected override void Update(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            myHero.Update(gameTime);
            if(GameState == GameState.LevelOne)
            {
                updateSpritesArray(gameTime,_sprites);
            }
            if(GameState == GameState.LevelTwo)
            {
                //camera2 = new Camera2D();
                //camera2.Follow(_sprite2.IndexOf());
                foreach(var sprite in _sprite2)
                {
                    if(sprite is Hero)
                    {
                        camera.Follow(myHero);
                    }
                }
                updateSpritesArray(gameTime,_sprite2);
            }
            if(GameState == GameState.GameOver)
            {
                //gameOverSprite.Draw(spriteBatch);
                gameOverSprite.Update(gameTime);
                camera.Follow(gameOverSprite);
                if(Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    //TODO : Make the start at the main menu!!!!!
                    GameState = GameState.LevelOne;
                }
            }


            
            base.Update(gameTime);
        }

        private void updateSpritesArray(GameTime gameTime,List<Sprite> sprites)
        {
            foreach(var sprite in sprites.ToArray())
            {
                if(sprite is Hero)
                {
                    sprite.Update(gameTime,sprites);
                    camera.Follow(sprite);
                }
                if(sprite is Coin)
                {
                    sprite.Update(gameTime);
                }
                if(sprite is Enemy)
                {
                    sprite.Update(gameTime,sprites);
                }
                if(sprite is Bullet)
                {
                    sprite.Update(gameTime,sprites);
                }
            }
            for(int i = 0; i < sprites.Count; i++)
            {
                if(sprites[i].IsRemoved)
                {
                    sprites.RemoveAt(i);
                    i--;
                }
            }
        }

        private void drawSpritesArrat(SpriteBatch spriteBatch,List<Sprite> sprites)
        {
            foreach(var sprite in sprites)
            {
                sprite.Draw(spriteBatch);
            }
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

            if(GameState == GameState.LevelOne)
            {
                drawSpritesArrat(spriteBatch,_sprites);
            }
            if(GameState == GameState.LevelTwo)
            {
                drawSpritesArrat(spriteBatch,_sprite2);
            }
            if(GameState == GameState.MainMenu)
            {
                gameOverSprite.Draw(spriteBatch);
            }
            
            writeOnScreen("Score " + myHero.Score,new Vector2(25,25),Color.White);
            writeOnScreen("Health " + myHero.Health,new Vector2(25,50),Color.White);
            writeOnScreen("State " + GameState.ToString(),new Vector2(25,75),Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void writeOnScreen(string text,Vector2 position,Color color)
        {
            Vector2 _position = new Vector2(position.X + (myHero.Position.X - (ScreenWidth / 2)),
                position.Y + (myHero.Position.Y - (ScreenHeight / 2)));
            spriteBatch.DrawString(_font,string.Format(text),_position,color);
        }
    }
}
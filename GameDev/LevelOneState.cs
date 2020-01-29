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

    public class LevelOneState : State
    {

        Level level1;
        Hero myHero;
        SpriteFont _font;
        //Camera2D camera { get; set; }

        private List<Sprite> _sprites;

        public LevelOneState(Game1 game1,GraphicsDevice graphicsDevice,ContentManager Content) : base(game1,graphicsDevice,Content)
        {

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
            _sprites = new List<Sprite>();
            myHero = new Hero(myHeroAnimation,new Vector2(55,800),3,50);
            myHero.Bullet = new Bullet(Content.Load<Texture2D>("bullet"),myHero._position);

            myHero.Input = new ArrowKeys();
            level1 = new Level(blockTexture,endBlockTexture,coinAnimation,enemyTexture,enemyBulletTexture,16,20);
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
                { 1,0,1,1,1,1,2,0,1,1,1,1,1,1,1,1 },
                { 1,0,0,0,1,0,1,2,2,2,0,0,0,0,0,1 },
                { 1,0,0,0,1,0,0,1,2,2,2,0,0,0,0,1 },
                { 1,0,0,0,0,0,1,1,1,1,2,0,0,0,0,1 },
                { 1,0,0,0,2,2,0,0,0,0,1,2,2,0,0,1 },
                { 1,0,2,2,0,0,0,0,0,0,0,1,0,0,1,1 },
                { 1,0,0,0,30,0,1,1,1,0,0,2,0,1,1,1 },
                { 1,0,0,2,1,0,0,0,0,0,1,1,1,0,0,1 },
                { 1,2,0,1,1,2,0,0,0,0,0,0,0,0,0,1 },
                { 1,6,30,31,0,0,2,0,0,0,0,0,0,0,31,1},
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



            foreach(var sprite in _sprites)
            {
                sprite.IsRemoved = true;
            }


            _font = Content.Load<SpriteFont>("Font");
            _sprites.Add(myHero);

        }

        public override void Draw(GameTime gameTime,SpriteBatch spriteBatch)
        {
            foreach(var sprite in _sprites)
            {
                sprite.Draw(spriteBatch);
            }

            spriteBatch.DrawString(_font,string.Format("Score " + myHero.Score),
                new Vector2(25 + myHero._position.X - (Game1.ScreenWidth / 2),
                25 + myHero._position.Y - (Game1.ScreenHeight / 2)),Color.White);
            spriteBatch.DrawString(_font,string.Format("Health " + myHero.Health),
                new Vector2(25 + myHero._position.X - (Game1.ScreenWidth / 2),
                50 + myHero._position.Y - (Game1.ScreenHeight / 2)),Color.White);
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gametime)
        {
        }

        public override void Update(GameTime gameTime)
        {
            myHero.Update(gameTime);
            foreach(var sprite in _sprites.ToArray())
            {
                if(sprite is Hero)
                {
                    sprite.Update(gameTime,_sprites);
                    _game.Camera.Follow(sprite);
                }
                if(sprite is Coin)
                {
                    sprite.Update(gameTime);
                }
                if(sprite is Enemy)
                {
                    sprite.Update(gameTime,_sprites);
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
        }
    }
}

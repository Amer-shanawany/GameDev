using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDev
{
    public class Enemy : Sprite,IShoot
    {
         
        public Enemy(Texture2D texture,Vector2 position)
            : base(texture,position)
        {
            _texture = texture;
            Position = position;
            Bullets = new List<Bullet>();
        }


        public Directoin Directoin { set; get; }
         
        public Texture2D BulletTexture { get  ; set  ; }
        public Bullet Bullet;
        public List<Bullet> Bullets { get  ; set  ; }
        public bool HasShoot { get  ; set  ; }
        public override void Draw(SpriteBatch spriteBatch)
        {
            SpriteEffects spriteEffects;

            if(Directoin == Directoin.Right)
                spriteEffects = SpriteEffects.None;
            else
                spriteEffects = SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(_texture,Rectangle,null,Color.White,0f,_origin,spriteEffects,0);
        }


        public void Shoot(List<Sprite> sprites)
        {

            var bullet = Bullet.Clone() as Bullet;
            bullet.Position = new Vector2(Position.X + (this._texture.Width /2) ,Position.Y + (this._texture.Height  /2));
            bullet.Velocity.X = 1f;
            bullet.Parent = this;
            bullet.Directoin = Directoin;

            bullet.Lifespan = 1f;
            sprites.Add(bullet);
        }
        private float _timer;
        public override void Update(GameTime gameTime,List<Sprite> sprites)
        {
            base.Update(gameTime,sprites);
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(_timer >3f )
            {
                Shoot(sprites);
                _timer = 0;
            }
            foreach(var sprite in sprites)
            {
                if(sprite is Bullet && sprite.Parent != this && !(sprite.Parent is Enemy))
                {
                    if(IsTouching(sprite))
                    {
                        IsRemoved = true;
                    }
                }
            }
        }
    }
}

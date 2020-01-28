using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev
{
    public enum Directoin { Right =1 , Left = -1 }
    public class Bullet : Sprite,ICloneable
    {
        public Directoin Directoin { set; get; } = Directoin.Right;
        protected float _timer;
        public float Lifespan = 2.5f;
        public Vector2 Velocity;
        public Bullet(Texture2D texture,Vector2 position)
            : base(texture,position)
        {
            _velocity = Velocity;
            
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            switch(Directoin)
            {
                case Directoin.Right:
                    spriteBatch.Draw(_texture,_position,null,Color.White,0f,_origin,Vector2.One,SpriteEffects.None,1f);

                    break;
                case Directoin.Left:
                    spriteBatch.Draw(_texture,_position,null,Color.White,0f,_origin,Vector2.One,SpriteEffects.FlipHorizontally,1f);

                    break;
                default:
                    break;
            }
        }
        public override void Update(GameTime gameTime,List<Sprite> sprites)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(_timer > Lifespan)
                 IsRemoved = true;

            switch(Directoin)
            {
                case Directoin.Right:
                    _position.X += _velocity.X + 3f;
                    break;
                case Directoin.Left:
                    _position.X += _velocity.X - 3f;
                    break;
                default:
                    break;
            }
            
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
         
    }
}

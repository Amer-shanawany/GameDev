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
        private float _timer;
        public float Lifespan = 3f;
        public Vector2 velocity;
        public Bullet(Texture2D texture,Vector2 position)
            : base(texture,position)
        {
            _velocity = velocity;
            
             
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            //base.Draw(spriteBatch);
            switch(Directoin)
            {
                case Directoin.Right:
                    spriteBatch.Draw(_texture,_position,null,Color.Blue,0f,_origin,new Vector2(0.2f,0.2f),SpriteEffects.None,1f);

                    break;
                case Directoin.Left:
                    spriteBatch.Draw(_texture,_position,null,Color.Blue,0f,_origin,new Vector2(0.2f,0.2f),SpriteEffects.FlipHorizontally,1f);

                    break;
                default:
                    break;
            }
            //spriteBatch.Draw(_texture,_position,_destination,Color.White,0f,_origin,1.0f,SpriteEffects.None,0);
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
            
            //_position += (_velocity * 2f); //+ new Vector2(3,0);

        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
         
    }
}

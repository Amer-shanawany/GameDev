using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev
{
    public class Sprite
    {
        public Sprite Parent;
        public Texture2D _texture;
        private Rectangle _destination;
        private Rectangle _source;

        public Vector2 Position;
        
        protected Vector2 _origin;
        protected Vector2 _velocity;
        protected Rectangle _rectangle;

        public bool IsRemoved = false;

        public Sprite(Texture2D texture,Vector2  position) {
            _texture = texture;
            Position = position;
            _origin = new Vector2(_destination.Width,_destination.Height);

        } 
         
        public virtual void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(_texture,Position,Color.White);


        }
        public virtual void Update(GameTime gameTime) {}
        
        public virtual void Update(GameTime gameTime,List<Sprite> sprites) {}
        public virtual Rectangle Rectangle
        {
            
            get
            {
                if(_texture != null)
                {
                 return new Rectangle((int)Position.X,(int)Position.Y, _texture.Width, _texture.Height);

                }
                
                throw new Exception("This Sprite has no Rectangle!!");
            }
        }

        //Collision Section 

        protected bool IsTouchingLeft(Sprite sprite)
        {

            return Rectangle.Right + _velocity.X > sprite.Rectangle.Left &&
                Rectangle.Left < sprite.Rectangle.Left &&
                Rectangle.Bottom > sprite.Rectangle.Top &&
                Rectangle.Top < sprite.Rectangle.Bottom;
        }

        protected bool IsTouchingRight(Sprite sprite)
        {
            return Rectangle.Left + _velocity.X < sprite.Rectangle.Right &&
                Rectangle.Right > sprite.Rectangle.Right &&
                Rectangle.Bottom > sprite.Rectangle.Top &&
                Rectangle.Top < sprite.Rectangle.Bottom;
        }

        protected bool IsTouchingTop(Sprite sprite)
        {
            return Rectangle.Bottom + _velocity.Y > sprite.Rectangle.Top &&
               Rectangle.Top < sprite.Rectangle.Top &&
               Rectangle.Right > sprite.Rectangle.Left &&
               Rectangle.Left < sprite.Rectangle.Right;
        }

        protected bool IsTouchingBottom(Sprite sprite)
        {
            return Rectangle.Top + _velocity.Y < sprite.Rectangle.Bottom &&
               Rectangle.Bottom > sprite.Rectangle.Bottom &&
               Rectangle.Right > sprite.Rectangle.Left &&
               Rectangle.Left < sprite.Rectangle.Right;
        }
        protected bool IsTouching(Sprite sprite)
        {
            if(IsTouchingBottom(sprite) || IsTouchingLeft(sprite) || IsTouchingRight(sprite) || IsTouchingTop(sprite))
            {
                return true;
            }
            return false;
        }



    }
}

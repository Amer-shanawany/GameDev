using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev
{
    public class Sprite:Component
    {
        public Sprite Parent;
        public Texture2D _texture;
        //protected List<Texture2D> _textureList;

        //
        private Rectangle _destination;
        private Rectangle _source;

        public Vector2 _position;
        
        protected Vector2 _origin;
        protected Vector2 _velocity;
        protected Rectangle _rectangle;

        public bool IsRemoved = false;

        public Sprite(Texture2D texture,Vector2  position) {
            _texture = texture;
            _position = position;
            //_source = new Rectangle(0,0,_texture.Width,_texture.Height);
            //_destination = new Rectangle(0,0,_texture.Width ,_texture.Height);
            //TODO : fix this line according to your texture
            _origin = new Vector2(_destination.Width,_destination.Height);

        } 
         
        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(_texture,_position,Color.White);


        }
        public override void Update(GameTime gameTime) {}

        //Collision Detection
        public virtual void Update(GameTime gameTime,List<Sprite> sprites) {}
        public virtual Rectangle Rectangle
        {
            
            get
            {
                if(_texture != null)
                {/*
                    return new Rectangle((int)_position.X - (int)_texture.X,
                        (int)_position.Y - (int)_origin.Y,
                        _texture.Width,
                        _texture.Height);*/
                 //returning the whole texture in case of an animation 
                 //move the collision functions to the animations ! 
                 // you don't wanna check every sprite if it's touching the other static sprites 
                 // you wanna check the moving objects if they're touching other sprites ! 
                 return new Rectangle((int)_position.X,(int)_position.Y, _texture.Width, _texture.Height);

                }
                /*
                if(_animationManager != null)
                {
                    var animation = _animations.FirstOrDefault().Value;

                    return new Rectangle((int)Position.X - (int)Origin.X
                        ,(int)Position.Y - (int)Origin.Y,
                        animation.FrameWidth,
                        animation.FrameHeight);
                }
                */
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

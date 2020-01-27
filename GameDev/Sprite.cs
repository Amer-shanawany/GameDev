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
        public Texture2D _texture;
        //protected List<Texture2D> _textureList;

        //
        private Rectangle _destination;
        private Rectangle _source;

        public Vector2 _position;
        
        private Vector2 _origin;
        protected Vector2 _velocity;
        protected Rectangle _rectangle;

        public bool IsRemoved = false;

        public Sprite(Texture2D texture,Vector2  position) {
            _texture = texture;
            _position = position;
            //_source = new Rectangle(0,0,_texture.Width,_texture.Height);
            //_destination = new Rectangle(0,0,_texture.Width ,_texture.Height);//TODO : fix this line according to your texture
            _origin = new Vector2(_destination.Width,_destination.Height);

        } 
         
        public virtual void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(_texture,_position,Color.White);

            //spriteBatch.Draw(_texture,_position,_source,Color.White,0f,_origin,new Vector2(1,1),SpriteEffects.None,0f);
           //spriteBatch.Draw(_texture,_position,_destination,Color.White,0f,_origin,1.0f,SpriteEffects.None,0);

        }
        public virtual void Update(GameTime gameTime) {}

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





    }
}

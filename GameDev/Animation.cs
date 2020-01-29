using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev
{
    public  class Animation:Sprite
    {
        Dictionary<string,Texture2D> _textureList;
        
        Vector2 _origin;
        protected Vector2 _gravity = new Vector2(0,1.5f);
        protected bool hasJumped = true;
        protected bool isJumping = false;
        int _currentFrame;
        int _frameHeight;
        int _frameWidth;
        int _frameCount;
        
        float timer;
        float _interval;

        public override Rectangle Rectangle
        {
            get
            {
                return  new Rectangle( 
                    (int)Position.X,(int)Position.Y,_frameWidth,_frameHeight-1);
                ;
            }
        }

        public Animation(Dictionary <string , Texture2D> TextureList,Vector2 Position,int FrameCount, float Interval)
             :base(TextureList["idle"],Position)
        {
            _textureList = TextureList;
            base.Position = Position;
            _frameCount = FrameCount;
            _interval = Interval;
        }
        public override void Update(GameTime gameTime)

        {
            //TODO : Add an idle animation 
            if(_velocity != Vector2.Zero)
            { 
                Animate(gameTime);
            }
            _frameHeight = _texture.Height;
            _frameWidth = _texture.Width / _frameCount;
            _rectangle = new Rectangle(_currentFrame * _frameWidth,0,_frameWidth,_frameHeight);
            _origin = Vector2.Zero;// new Vector2(_rectangle.Width/2 ,_rectangle.Height /2);
            
            Position += _velocity  ;
            
            SetAnimation();
            
        }
        public override void Update(GameTime gameTime,List<Sprite> sprites)
        {
            base.Update(gameTime,sprites);

            float i = 2f;
            _velocity += _gravity;
            foreach(var sprite in sprites)

            {
                if(IsTouchingTop(sprite)&& !(sprite is Bullet))
                {
                    // _gravity.Y= 0;
                    hasJumped = false;
                    isJumping = false;
                    _gravity.Y = 0;
                }else
                {
                    _gravity.Y = 1.5f;
                 }
                   
                if(sprite != this)
                {

                    if(sprite is Block &&!(sprite is EndBlock))
                    {
                        
                    
                         if(_velocity.X > 0 && IsTouchingLeft(sprite)||
                        _velocity.X < 0 && IsTouchingRight(sprite))
                        {
                            _velocity.X = 0;
                        }
                       if(_velocity.Y > 0 && IsTouchingTop(sprite) ||
                        _velocity.Y < 0 && IsTouchingBottom(sprite))
                        {
                             _velocity.Y = 0;
                        }

                    }
                    
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
                  
        {
            if(_texture == null)  
            {
                _texture = _textureList["idle"];
            }
            spriteBatch.Draw(_texture,Position,_rectangle,Color.White,0f,_origin,1.0f,SpriteEffects.None,0f);
         }
        public void Animate(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.Milliseconds  ;
            if(timer>_interval)
            {
                _currentFrame++;

                if(_currentFrame==_frameCount)
                {
                    _currentFrame = 0;
                }
                timer = 0;


            }


        }
        private void SetAnimation()
        {
            if(_velocity.X > 0)
            {
                _texture = _textureList["right"];
            }
            else if(_velocity.X < 0)
            {
                _texture = _textureList["left"];
            }           
            else
            {
                _velocity = Vector2.Zero;
                _texture = _textureList["idle"];
            }

      

    }
           
    }
}

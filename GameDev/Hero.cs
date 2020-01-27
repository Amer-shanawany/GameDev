using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDev
{
    public class Hero : Animation

    {
        bool spacebarDown;
        public int Score = 0; 

        public Input Input { get; set; } 
        public Hero(Dictionary<string,Texture2D> TextureList,Vector2 Position,int FrameCount,float Interval) 
            : base(TextureList,Position,FrameCount,Interval)
        {
            
        }
        public override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);
            Input.Update();
            if(Input.Left)
            {
                _velocity = new Vector2(-1.5f,0);
            }
            else if(Input.Right)
            {
                _velocity = new Vector2(1.5f,0);
            }
            else if(Input.Up)
            {
               // _velocity = new Vector2(0,-1);
            }
            else if(Input.Down)
            {
                //_velocity = new Vector2(0,1);
            }
            
            else
            {
                _velocity.X = 0;
            }
            if(Input.Jump && !hasJumped && !spacebarDown)
            {
                // sound.Play(volume,pitch,pan); // plays jumping sound
                // _position.Y -= 150f;               // position of jump
                //_velocity.Y -=  50f;            // velocity of jump 
                _position.Y -= 35;
                //_velocity.Y = -50;
                _velocity.Y -= 85;
                hasJumped = true;
                spacebarDown = true;
            }
            if(hasJumped)
            {
                float i = 3f;
                //_velocity.Y += 0.6f * i;
            }

          //if(!isJumping)
          //{
          //    if(!isPressingJump && Keyboard.GetState().IsKeyDown(Keys.W))
          //    {
          //        isJumping = true;
          //        isPressingJump = true;
          //    }
          //}
            if(!Input.Jump)
            {
                spacebarDown = false;
            }

           

        }

        public override void Update(GameTime gameTime,List<Sprite> sprites)
        {
            base.Update(gameTime,sprites);
            foreach(var sprite in sprites)
            {
                if(sprite is Coin)
                {
                    if(IsTouchingBottom(sprite) || IsTouchingLeft(sprite) || IsTouchingRight(sprite) || IsTouchingTop(sprite))
                    {
                        //add score 

                        //remove coin 
                        //sprites.ToArray();
                        //int index = sprites.IndexOf(sprite);
                        //sprites.RemoveAt(index);
                        /// break;
                        /// 
                        sprite.IsRemoved = true;//1 

                        Score++;
                    }
                }
            }
            
        }
    }
    
}

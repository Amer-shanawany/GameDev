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
    public class Hero : Animation, IShoot
    {

        //Level 
        public int Level { get; set; } = 1;
        //Health
        public int Health = 5;
          
        //Jumping
         bool spacebarDown;

        //score 
        //TODO: seprate Score Class ! 
        public int Score = 0;
         
        public Input Input { get; set; }

        //IShoot
        public Texture2D BulletTexture { get ; set; }
        public Bullet Bullet;
        public List<Bullet> Bullets { get; set; }
        public bool HasShoot { get; set; } = false;

        public Hero(Dictionary<string,Texture2D> TextureList,Vector2 Position,int FrameCount,float Interval) 
            : base(TextureList,Position,FrameCount,Interval)
        {
            Bullets = new List<Bullet>();
            
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

                _position.Y -= 55;
                //_velocity.Y = -50;
                _velocity.Y = -85;
                
                hasJumped = true;
                spacebarDown = true;
            }
            if(hasJumped)
            {
                float i = 3f;
                //_velocity.Y += 0.6f * i;
            }

       
            if(!Input.Jump)
            {
                spacebarDown = false;
            }

            
            //RemoveBullets();
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
                        sprite.IsRemoved = true; 
                        Score++;
                    }
                }
                if(sprite is Bullet && sprite.Parent != this)
                {
                    if(IsTouching(sprite))
                    {
                         Health--;
                         
                        sprite.IsRemoved = true;
                    }
                }
                 
                if(sprite is EndBlock && IsTouching(sprite))
                {
                    Level++;
                    Console.WriteLine(Level);
                }
            }
            if(Input.Shoot&&!HasShoot)
            {
                Shoot(sprites);
                HasShoot = true;
            }
            if(!Input.Shoot)
            {
                HasShoot = false;
            }
           
        }

      
        public void Shoot(List<Sprite> sprites)
        {
            
             var bullet = Bullet.Clone() as Bullet;
            bullet.Parent = this;
            bullet._position = new Vector2 (_position.X + _rectangle.Width/2,_position.Y + this._rectangle.Height / 2);
            bullet.Velocity.X = _velocity.X;
             if(_velocity.X < 0)
            {
                bullet.Directoin = Directoin.Left;
            }
            else
           
            {
                bullet.Directoin = Directoin.Right;
            }
                bullet.Lifespan = 1.5f;
                sprites.Add(bullet);
        

        }
        
    }
    
}

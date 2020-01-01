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
                _velocity = new Vector2(-1,0);
            }
            else if(Input.Right)
            {
                _velocity = new Vector2(1,0);
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
                _velocity = Vector2.Zero;
            }
     

        }

             
    }
    
}

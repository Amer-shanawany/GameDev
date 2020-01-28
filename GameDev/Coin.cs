using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev
{
    public class Coin : Animation
    {
        public Texture2D Texture2D;
        public Coin(Dictionary<string,Texture2D> TextureList,Vector2 Position,int FrameCount,float Interval) 
            : base(TextureList,Position,FrameCount,Interval)
        {
            _gravity = Vector2.Zero;
            _velocity = Vector2.Zero;
            _texture = TextureList["idle"];
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Animate(gameTime);
        }
      



    }
}

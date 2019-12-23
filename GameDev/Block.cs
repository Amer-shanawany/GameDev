using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDev
{
    public class Block : Sprite
    {
        public int blockWidth;
        public int blockHeight;
        public Block(Texture2D texture,Vector2 position) 
            : base(texture,position)
        {
            blockWidth = texture.Width;
            blockHeight = texture.Height;
        }

    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev
{
    public class Camera2D
    {
        Vector2 position;
        public Matrix Transform { get; private set; }
        public void Follow(Sprite spriteTarget) 
        {
            var offset = Matrix.CreateTranslation(
                    Game1.ScreenWidth / 2,
                    Game1.ScreenHeight / 2,
                0);

            var position = Matrix.CreateTranslation(
                -spriteTarget._position.X - (spriteTarget.Rectangle.Width / 2),
                -spriteTarget._position.Y - (spriteTarget.Rectangle.Height / 2),//-spriteTarget._position.Y - (spriteTarget.Rectangle.Height / 2
                0);

            Transform = position * offset;
        
        }
    }
}

using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev
{
    public interface IShoot
    {
        Texture2D BulletTexture { get; set; }
        List<Bullet> Bullets { get; set; }
        bool HasShoot { get; set; }


        void Shoot(List<Sprite> sprites);
        
        
    }
}

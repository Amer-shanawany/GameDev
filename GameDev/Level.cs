using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev
{
    public class Level
    {
        // Sprite blockSprite=new Sprite();
        Texture2D _texture;
        public byte[,] tileArray { get; set; }
        private Block[,] blocksArray;
        public int LevelHeight { get; set; }
        public int LevelWidth { get; set; }
        
        public Level(Texture2D texture,int LevelWidth,int LevelHeight)
        {
            _texture = texture;
           // this.blockSprite = sprite;
            this.LevelWidth = LevelHeight;
            this.LevelHeight = LevelWidth;
            blocksArray = new Block[LevelHeight,LevelWidth];
        }


        public void CreateWorld()
        {
            for(int x = 0; x < LevelWidth; x++)
            {
                for(int y = 0; y < LevelHeight; y++)
                {
                    if(tileArray[x,y] == 1)
                    {
                        blocksArray[x,y] = new Block(_texture,new Vector2(y * _texture.Width,x * _texture.Height));
                    }

                }
            }
        }

        public void DrawWorld(SpriteBatch spritebatch)
        {
            for(int x = 0; x < LevelWidth; x++)
            {
                for(int y = 0; y < LevelHeight; y++)
                {
                    if(blocksArray[x,y] != null)
                    {
                        blocksArray[x,y].Draw(spritebatch);
                    }
                }
            }

        }
        public List<Block> ToArray()
        {
            List<Block> temp = blocksArray.OfType<Block>().ToList();
            return temp;
        }
    }
}

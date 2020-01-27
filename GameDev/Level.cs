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
        Texture2D _blockTexture;
        Texture2D _coinTexture;
        Dictionary<string,Texture2D> _coinTextureDictionary;
        public byte[,] tileArray { get; set; }
        private Block[,] blocksArray;
        private Coin[,] coinsArray;
        public int LevelHeight { get; set; }
        public int LevelWidth { get; set; }

        public Level(Texture2D blockTexture,Dictionary<string,Texture2D> coinTexture,int LevelWidth,int LevelHeight)
        {
            _blockTexture = blockTexture;
            _coinTextureDictionary = coinTexture;
            // this.blockSprite = sprite;
            this.LevelWidth = LevelHeight;
            this.LevelHeight = LevelWidth;
            blocksArray = new Block[LevelHeight,LevelWidth];
            coinsArray = new Coin[LevelHeight,LevelWidth];
        }


        public void CreateWorld()
        {
            // Coin coin1 = new Coin(_coinTextureDictionary,null,8,50);
            for(int x = 0; x < LevelWidth; x++)
            {
                for(int y = 0; y < LevelHeight; y++)
                {
                    if(tileArray[x,y] == 1)
                    {
                        blocksArray[x,y] = new Block(_blockTexture,new Vector2(y * _blockTexture.Width,x * _blockTexture.Height));
                    }
                    if(tileArray[x,y] == 2)
                    {
                        //coinsArray[x,y] = new Coin(_coinTextureDictionary,new Vector2(y* _coinTextureDictionary.ElementAt(0).Value.Bounds.Width,x * _coinTextureDictionary.ElementAt(0).Value.Bounds.Height),3,50);
                        coinsArray[x,y] = new Coin(_coinTextureDictionary,new Vector2((y * _blockTexture.Width)+5,(x * _blockTexture.Height)+9),8,50);
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
                    if(coinsArray[x,y] != null)
                    {
                        coinsArray[x,y].Draw(spritebatch);
                    }
                }
            }

        }
        public List<Block> ToArray()
        {
            List<Block> temp = blocksArray.OfType<Block>().ToList();
            return temp;
        }
        public List<Coin> ToArrayCoins() 
        {
            List<Coin> temp = coinsArray.OfType<Coin>().ToList();
            return temp;
        }
    }
}

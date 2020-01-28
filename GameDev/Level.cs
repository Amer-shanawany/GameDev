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
        Texture2D _endBlokTexture;
        Texture2D _enemyTexture;
        Texture2D _enemyBulletTexture;
        Dictionary<string,Texture2D> _enemyDictionary;
        Dictionary<string,Texture2D> _coinTextureDictionary;
        public byte[,] tileArray { get; set; }
        private Block[,] blocksArray;
        private Coin[,] coinsArray;
        private Enemy[,] enemiesArray;
        private EndBlock[,] EndBlocksArray;
        public int LevelHeight { get; set; }
        public int LevelWidth { get; set; }

        public Level(Texture2D blockTexture,Texture2D endBlockTexture,Dictionary<string,Texture2D> coinDictionary,
             Texture2D  enemyTexture,Texture2D enemyBulletTexture,int LevelWidth,int LevelHeight)
        {
            _endBlokTexture = endBlockTexture;
            _blockTexture = blockTexture;
            _coinTextureDictionary = coinDictionary;
            _enemyTexture = enemyTexture;
            _enemyBulletTexture = enemyBulletTexture;
            //_enemyDictionary = enemyDictionary;
            // this.blockSprite = sprite;
            this.LevelWidth = LevelHeight;
            this.LevelHeight = LevelWidth;
            blocksArray = new Block[LevelHeight,LevelWidth];
            EndBlocksArray = new EndBlock[LevelHeight,LevelWidth];
            coinsArray = new Coin[LevelHeight,LevelWidth];
            enemiesArray = new Enemy[LevelHeight,LevelWidth];
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
                    if(tileArray[x,y] == 30 || tileArray[x,y] ==31 )
                    {
                        Directoin direction;
                        switch(tileArray[x,y])
                        {
                            case 30:
                                direction = Directoin.Right;
                                break;
                            default  :
                                direction = Directoin.Left;
                                break;

                        }
                        enemiesArray[x,y] = new Enemy(_enemyTexture,new Vector2(y * _blockTexture.Width,x * _blockTexture.Height))
                        {  Directoin = direction };
                        enemiesArray[x,y].Bullet = new Bullet(_enemyBulletTexture,
                            new Vector2(enemiesArray[x,y]._position.X + _enemyTexture.Width / 2,
                        enemiesArray[x,y]._position.Y + _enemyTexture.Height / 2))
                        { Directoin = direction};
                    }
                    if(tileArray[x,y] == 6)
                    
                    {
                        EndBlocksArray[x,y] = new EndBlock(_endBlokTexture,new Vector2(y * _blockTexture.Width,x * _blockTexture.Height));

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
                    if(enemiesArray[x,y] != null)
                        enemiesArray[x,y].Draw(spritebatch);
                    if(EndBlocksArray[x,y] != null)
                        enemiesArray[x,y].Draw(spritebatch);
                }
            }

        }
         
        public List<Block> ToArrayBlocks()
        {
            List<Block> temp = blocksArray.OfType<Block>().ToList();
            return temp;
        }
        public List<Coin> ToArrayCoins() 
        {
            List<Coin> temp = coinsArray.OfType<Coin>().ToList();
            return temp;
        }
        public List<Enemy> ToArrayEnemies()
        {
            List<Enemy> temp = enemiesArray.OfType<Enemy>().ToList();
            return temp;
        }
        public List<EndBlock> ToArrayEndBlock()
        {
            List<EndBlock> t = EndBlocksArray.OfType<EndBlock>().ToList();
            return t;
        }
    }
}

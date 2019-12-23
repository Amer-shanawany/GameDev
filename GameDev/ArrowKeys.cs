using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev
{
    public class ArrowKeys : Input
    {
        public override void Update()
        {
            KeyboardState stateKey = Keyboard.GetState();
            if(stateKey.IsKeyDown(Keys.Left))
                Left = true;
            if(stateKey.IsKeyUp(Keys.Left))
                Left = false;

            if(stateKey.IsKeyDown(Keys.Right))
                Right = true;
            if(stateKey.IsKeyUp(Keys.Right))
                Right = false;

            if(stateKey.IsKeyDown(Keys.Up))
                Up = true;
            if(stateKey.IsKeyUp(Keys.Up))
                Up = false;

            if(stateKey.IsKeyDown(Keys.Down))
                Down = true;
            if(stateKey.IsKeyUp(Keys.Down))
                Down = false;


            if(stateKey.IsKeyDown(Keys.Space))
                Jump = true;
            if(stateKey.IsKeyUp(Keys.Space))
                Jump = false;
        }
    }
}

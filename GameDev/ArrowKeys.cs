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
        public KeyboardState currentKeyboardState;
        public KeyboardState previousKeyboardState;
        public override void Update()
        {            
            previousKeyboardState = currentKeyboardState;

            currentKeyboardState = Keyboard.GetState();

            if(currentKeyboardState.IsKeyDown(Keys.Left))
                Left = true;
            if(currentKeyboardState.IsKeyUp(Keys.Left))
                Left = false;

            if(currentKeyboardState.IsKeyDown(Keys.Right))
                Right = true;
            if(currentKeyboardState.IsKeyUp(Keys.Right))
                Right = false;

            if(currentKeyboardState.IsKeyDown(Keys.Up))
                Up = true;
            if(currentKeyboardState.IsKeyUp(Keys.Up))
                Up = false;

            if(currentKeyboardState.IsKeyDown(Keys.Down))
                Down = true;
            if(currentKeyboardState.IsKeyUp(Keys.Down))
                Down = false;

            

            if(currentKeyboardState.IsKeyDown(Keys.Space))
                Jump = true;
            if(currentKeyboardState.IsKeyUp(Keys.Space))
                Jump = false;
            if(currentKeyboardState.IsKeyDown(Keys.X)&&previousKeyboardState.IsKeyUp(Keys.X))
            {
                Shoot = true;
            }
            if(currentKeyboardState.IsKeyUp(Keys.X))
            {
                Shoot = false;
            }
            
        }
    }
}

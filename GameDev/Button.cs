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
    public class Button : Component
    {
        private MouseState _currentMouseState;
        private MouseState _previousMouseState;
        private SpriteFont _font;
        private bool _isHovering;
        private Texture2D _texture;
        public event EventHandler Click;
        public bool Clicked { get; private set; }
        public Color CursorColor { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle Rectangle { get { return new Rectangle((int)Position.X,(int)Position.Y,_texture.Width,_texture.Height);   } }
        public string Text { get; set; }



        public Button(Texture2D texture, SpriteFont spriteFont)
        {
            _texture = texture;
            _font = spriteFont;
            CursorColor = Color.White;
        }




        public override void Draw(SpriteBatch spriteBatch)
        {
            var color = Color.White;
            if(_isHovering)
                color = Color.Gray;
            if(!string.IsNullOrEmpty(Text))
            {

                var x = (Rectangle.X + (Rectangle.Width / 2) - (_font.MeasureString(Text).X / 2));
                var y = (Rectangle.Y + (Rectangle.Height/ 2) - (_font.MeasureString(Text).Y / 2));
                spriteBatch.DrawString(_font,Text,new Vector2(x,y),CursorColor);
            }

        }

        public override void Update(GameTime gameTime)
        {
            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
            var mouseRectangle = new Rectangle(_currentMouseState.X,_currentMouseState.Y,1,1);
            _isHovering = false;
            if(mouseRectangle.Intersects(Rectangle))
            {
                _isHovering = true;
                if(_currentMouseState.LeftButton == ButtonState.Released && _previousMouseState.LeftButton == ButtonState.Pressed)
                {     
                Click?.Invoke(this,new EventArgs());

                }
            }
           
        }
    }
}

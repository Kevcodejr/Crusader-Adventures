using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Treetown
{
    public class Arrow
    {
        private Rectangle arrowHitbox;
        private Texture2D sprite;
        private bool isRight;
        private Vector2 size;

        public Arrow(int sizeX, int sizeY)
        {
            size = new Vector2(sizeX, sizeY);
        }

        public void setPosition(int X, int Y)
        {
            arrowHitbox = new Rectangle(X, Y, (int)size.X, (int)size.Y);
        }

        public void setDirection(bool isRight, Texture2D sprite)
        {
            this.sprite = sprite;
            this.isRight = isRight;
        }

        public void updateArrow(float value)
        {
            if (isRight)
            {
                arrowHitbox.X = arrowHitbox.X + (int)value;
            }
            else if(!isRight)
            {
                arrowHitbox.X = arrowHitbox.X - (int)value;
            }
        }

        public void drawArrow(SpriteBatch spriteBatch)
        {
            if(isRight != null)
            {
                spriteBatch.Draw(sprite, arrowHitbox, Color.White);
            }
        }
    }
}

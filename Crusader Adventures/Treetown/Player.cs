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
    public class Player
    {
        private Vector2 size;
        private Vector2 position;
        private Texture2D sprite;
        private Texture2D right;
        private Texture2D left;
        private Boolean isRight;


        public Player(Vector2 size, Vector2 position)
        {
            this.size = size;
            this.position = position;
        }

        public void loadSprite(Texture2D right, Texture2D left)
        {
            this.right = right;
            this.left = left;
            sprite = right;
            isRight = true;
        }
        public Vector2 getPosition() { return this.position; }
        public void updatePosition(Vector2 position)
        {
            this.position = position;
        }

        public void setLeft()
        {
            if(isRight == true)
            {
                sprite = left;
                isRight = false;
            }
        }
        public void setRight()
        {
            if (isRight == false)
            {
                sprite = right;
                isRight = true;

            }
        }
        public Boolean getDirection() { return isRight; }

        public void drawSprite(SpriteBatch spriteBatch)
        {
            if(sprite == null)
            {
                return;
            }
            spriteBatch.Draw(sprite, new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y), Color.White);
        }



    }
}

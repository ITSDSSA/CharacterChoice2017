using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprites
{
    public class Player
    {
        public Texture2D Image;
        public Vector2 Position;
        public Rectangle BoundingRect;

        // Constructor expects to see a loaded Texture
        // and a start position
        public Player( Texture2D spriteImage,
                            Vector2 startPosition)
        {
            //
            // Take a copy of the texture passed down
            Image = spriteImage;
            // Take a copy of the start position
            Position = startPosition;
            // Calculate the bounding rectangle
            BoundingRect = new Rectangle((int)startPosition.X, (int)startPosition.Y, Image.Width, Image.Height);

        }

        public void draw(SpriteBatch sp, Texture2D Image)
        {
            if (Image != null)
            {
                sp.Draw(Image, Position, Color.White);
            }
        }

        public void Move(Vector2 delta)
        {
            Position += delta;
            BoundingRect = new Rectangle((int)Position.X, (int)Position.Y, Image.Width, Image.Height);
            BoundingRect.X = (int)Position.X;
            BoundingRect.Y = (int)Position.Y;
        }

    }
}

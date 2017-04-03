using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Engine.Engines;

namespace Sprites
{
    public class Player
    {
        public Texture2D Image;
        public Vector2 Position;
        public Rectangle BoundingRect;
        public bool Visible = true;
        public float Speed = 2.0f;
        public Vector2 size = new Vector2(64, 64);


        public Player(Texture2D spriteImage,
                            Vector2 startPosition)
        {
            Image = spriteImage;
            Position = startPosition;
            BoundingRect = new Rectangle(startPosition.ToPoint(), size.ToPoint());

        }

        public void Update()
        {
            if (InputEngine.IsKeyHeld(Keys.A))
                Position += new Vector2(-1,0) * Speed;
            if (InputEngine.IsKeyHeld(Keys.S))
                Position += new Vector2(1,0) * Speed;
            if (InputEngine.IsKeyHeld(Keys.W))
                Position += new Vector2(0, -1) * Speed;
            if (InputEngine.IsKeyHeld(Keys.S))
                Position += new Vector2(0, 1) * Speed;
            BoundingRect = new Rectangle(Position.ToPoint(), size.ToPoint());

        }

        public void draw(SpriteBatch sp)
        {
            if(Visible)
                sp.Draw(Image, BoundingRect, Color.White);
        }

        
    }
}

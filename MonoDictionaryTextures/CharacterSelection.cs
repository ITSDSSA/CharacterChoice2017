using Engine.Engines;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoDictionaryTextures
{
    class CharacterSelection
    {
        public Texture2D Texture;
        public Rectangle Bound;
        public bool Selected = false;

        public CharacterSelection(Texture2D tx, Vector2 pos)
        {
            Texture = tx;
            Bound = new Rectangle(pos.ToPoint(), new Point(tx.Width, tx.Height));
        }

        public void Update()
        {
            
            if(Bound.Contains(InputEngine.MousePosition) && InputEngine.IsMouseLeftClick())
            {
                Selected = true;
            }
        }
    }
}

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
        public Vector2 size = new Vector2(64, 64);

        public CharacterSelection(Texture2D tx, Vector2 pos)
        {
            Texture = tx;
            Bound = new Rectangle(pos.ToPoint(), size.ToPoint());
        }

        public void Update()
        {
            
            if (InputEngine.IsMouseLeftClick() && Bound.Contains(InputEngine.MousePosition))
            {
                Selected = true;
            }
        }

        public void Draw(SpriteBatch sp)
        {
            sp.Draw(Texture, Bound, Color.White);
        }
    }
}

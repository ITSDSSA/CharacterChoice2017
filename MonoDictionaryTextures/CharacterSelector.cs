using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoDictionaryTextures
{
    class CharacterSelector
    {
        Texture2D _background;
        Dictionary<string, CharacterSelection> characters = 
            new Dictionary<string, CharacterSelection>();

        public CharacterSelector()
        {
            
        }

    }
}

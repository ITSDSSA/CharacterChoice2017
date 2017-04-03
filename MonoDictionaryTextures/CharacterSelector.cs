using AudioPlayer;
using Engine.Engines;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoDictionaryTextures
{
    class CharacterSelector
    {
        Texture2D _background;
        Vector2 _position;
        bool _selecting;
        SoundEffectInstance _backingTrackPlayer;
        Dictionary<string, CharacterSelection> characters = 
            new Dictionary<string, CharacterSelection>();

        CharacterSelection _currentSelected;

        public bool Selecting
        {
            get
            {
                return _selecting;
            }

            set
            {
                _selecting = value;
            }
        }

        internal CharacterSelection CurrentSelected
        {
            get
            {
                return _currentSelected;
            }

            set
            {
                _currentSelected = value;
            }
        }

        public CharacterSelector(Dictionary<string,Texture2D> textures, Texture2D Background, Vector2 pos)
        {
            setupCharcaters(textures);
            CurrentSelected = characters.First().Value;
            _background = Background;
            Selecting = false;
        }

        private void setupCharcaters(Dictionary<string, Texture2D> textures)
        {
            Vector2 choicePos = new Vector2(10, 10);
            foreach (var item in textures)
            {
                Texture2D tx = item.Value;
                CharacterSelection c = new CharacterSelection(item.Value, choicePos);
                characters.Add(item.Key, c);
                choicePos +=  new Vector2(c.size.X + 10, 0);
            }
        }

        public void Update(Player p )
        {
            // if the Esc key is pressed then we are hanging up
            if(InputEngine.IsKeyPressed(Keys.Escape))
                Selecting = !Selecting;

            if(Selecting)
            {
                AudioManager.Play(ref _backingTrackPlayer, "backingTrack");
                // If selecting iterate over the characters in 
                // the Dictionary and see if one is selected
                // Note we only update the characters to catch a 
                // Mouse press if we are in selection mode
                foreach (var character in characters)
                {
                    character.Value.Update();
                        if(character.Value.Selected)
                            CurrentSelected = character.Value;
                    // Reset the character selected value as 
                    // we have captured the selction in Current Selected
                    character.Value.Selected = false;
                    
                }
                // When done set the player texture
                p.Image = CurrentSelected.Texture;

            }
            // If not selecting then check player
            else {
                if (_backingTrackPlayer != null)
                    if (_backingTrackPlayer.State == SoundState.Playing)
                    { 
                        _backingTrackPlayer.Stop();
                        _backingTrackPlayer = null;
                    }
                 }
        }

        public void draw(SpriteBatch sp)
        {
            if (Selecting)
            {
                // Draw the background and the Character Selection
                // Choices
                sp.Draw(_background, _position, Color.White);
                foreach (var character in characters)
                    character.Value.Draw(sp);
            }


        }


    }
}

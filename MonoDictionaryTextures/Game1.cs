using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;
using AudioPlayer;
using Engine.Engines;
using Loader;
using Sprites;

namespace MonoDictionaryTextures
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    /// 

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Dictionary<string, Texture2D> badges = new Dictionary<string, Texture2D>();
        CharacterSelector selector;
        Player player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            new InputEngine(this);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            selector = new CharacterSelector(
                ContentLoader.ContentLoad<Texture2D>(Content,"Characters"), 
                Content.Load<Texture2D>("Play Scene Background"), 
                Vector2.Zero);

            player = new Player(selector.CurrentSelected.Texture, new Vector2(100, 100));

            AudioManager.SoundEffects = ContentLoader.ContentLoad<SoundEffect>(Content,"Audio");

        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        /// 

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            if (InputEngine.IsKeyPressed(Keys.P))
            {
                SoundEffectInstance player = null;
                AudioManager.Play(ref player,"0");
                    }
            // TODO: Add your update logic here
            player.Update();
            selector.Update(player);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            player.draw(spriteBatch);
            selector.draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void DrawBadges()
        {
            Vector2 pos = new Vector2(50, 50);
            // Draw 5 badges per row
            int ColCount = 5;
            foreach (KeyValuePair<string, Texture2D> entry in badges)
            {
                spriteBatch.Draw(entry.Value, pos, Color.White);

                if (ColCount-- > 1)
                    pos += new Vector2(entry.Value.Width + 10, 0);
                else
                {
                    ColCount = 5;
                    pos += new Vector2(-pos.X + 50, entry.Value.Height + 10);
                }
            }

        }
    }
}

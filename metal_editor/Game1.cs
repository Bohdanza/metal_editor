using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace metal_editor
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Level testLevel;
        private int xlev = 0, ylev = 0;
        public static Texture2D NoTexture;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.ApplyChanges();

            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;

            _graphics.ApplyChanges();

            _graphics.IsFullScreen = false;

            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            NoTexture = Content.Load<Texture2D>("no_texture");

            if (File.Exists("levels/level1"))
                testLevel = Level.Load("level1");
            else
                testLevel = new Level(Content, 20, 20, "level1");

            //testLevel = new Level(Content, 20, 20, "level1");
            //testLevel.Save();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            var ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Up))
                ylev += 10;
            if (ks.IsKeyDown(Keys.Down))
                ylev -= 10;
            if (ks.IsKeyDown(Keys.Left))
                xlev += 10;
            if (ks.IsKeyDown(Keys.Right))
                xlev -= 10;

            testLevel.Update(Content);

            if (ks.IsKeyDown(Keys.S) && ks.IsKeyDown(Keys.LeftControl))
                testLevel.Save();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            testLevel.Draw(_spriteBatch, xlev, ylev);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

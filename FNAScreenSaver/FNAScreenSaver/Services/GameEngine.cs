using System;
using System.Collections.Generic;
using System.Linq;
using FNAScreenSaver.Constants;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Color = Microsoft.Xna.Framework.Color;

namespace FNAScreenSaver.Services
{
    /// <summary>
    /// Основной класс игры
    /// </summary>
    public class GameEngine : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D backgroundTexture;
        private Texture2D snowflakeTexture;

        private SnowflakeManager snowflakeManager;

        /// <summary>
        /// Инициализировать новый экземпляр <see cref="GameEngine"/>
        /// </summary>
        public GameEngine()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            var screenWidth = graphics.PreferredBackBufferWidth;
            var screenHeight = graphics.PreferredBackBufferHeight;

            snowflakeManager = new SnowflakeManager(SnowflakeConstants.Count, screenWidth, screenHeight);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            backgroundTexture = Content.Load<Texture2D>("forest");
            snowflakeTexture = Content.Load<Texture2D>("snowflake");
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().GetPressedKeys().Length > 0)
            {
                Exit();
            }
            snowflakeManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            spriteBatch.Draw(backgroundTexture, GraphicsDevice.Viewport.Bounds, Color.White);

            var snowflakes = snowflakeManager.GetAllSnowflakes();
            foreach (var snowflake in snowflakes)
            {
                var origin = new Vector2(snowflakeTexture.Width / 2, snowflakeTexture.Height / 2);
                var position = new Vector2(snowflake.X, snowflake.Y);

                spriteBatch.Draw(
                    snowflakeTexture,
                    position,
                    null,
                    snowflake.Color,
                    0,
                    origin,
                    snowflake.Scale,
                    SpriteEffects.None,
                    0f
                );
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void UnloadContent()
        {
            spriteBatch?.Dispose();
            backgroundTexture?.Dispose();
            snowflakeTexture?.Dispose();

            base.UnloadContent();
        }

    }
}

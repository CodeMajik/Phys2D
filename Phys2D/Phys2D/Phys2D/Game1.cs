using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Phys2D
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        EntityManager m_manager;
        ControllableEntity m_player;

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
            Texture2D tex = Content.Load<Texture2D>("cube");

            m_manager = EntityManager.GetInitInstance(ref tex);
            m_manager.floorY = (double)graphics.PreferredBackBufferHeight;
            m_manager.screenRight = (double)graphics.PreferredBackBufferWidth;

            m_player = new ControllableEntity();
            m_player.m_entity.SetTexture(ref tex);
            m_player.m_entity.m_force.Y = WorldForces.Gravity.Y;

            m_player.floorY = (double)graphics.PreferredBackBufferHeight;
            m_player.screenRight = (double)graphics.PreferredBackBufferWidth;
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
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

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                m_player.m_impulseForce.Y = -10.0f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                m_player.m_impulseForce.X = 1.0f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                m_player.m_impulseForce.X = -1.0f;
            }

            m_player.Update(gameTime);
          //  m_manager.Update(ref gameTime);
            // TODO: Add your update logic here

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
            //m_manager.Draw(ref spriteBatch);
            Rectangle rect = new Rectangle();
            int width, height;
            width = (int)m_player.m_entity.m_width;
            height = (int)m_player.m_entity.m_height;
            rect.X = (int)m_player.m_entity.m_position.X;
            rect.Y = (int)m_player.m_entity.m_position.Y;
            rect.Width = width;
            rect.Height = height;
            spriteBatch.Draw(m_player.m_entity.m_texture, rect, Color.White); 
            spriteBatch.End();
            // TODO: Add your drawing code here
           

            base.Draw(gameTime);
        }
    }
}
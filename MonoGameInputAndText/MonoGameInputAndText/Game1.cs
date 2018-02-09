using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/// <summary>
/// IGME-106 - Game Development and Algorithmic Problem Solving
/// Practice Exercise 7 - MonoGame Basics
/// Class Description   : Main class and main menu for a number guessing game
/// Author              : Benjamin Kleynhans
/// Modified By         : Benjamin Kleynhans
/// Date                : February 7, 2018
/// Filename            : Game1.cs
/// </summary>

namespace MonoGameInputAndText
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Texture2D beetleRightFacing;                // Create image (texture) variable
        private Vector2 position;                           // Create position (vector) variable
        private SpriteFont spriteFont;

        private float XPos = 5;                             // Create X and Y position variables
        private float YPos = 5;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Window.Position = new Point(                    // Center the game view on the screen
                (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2) -
                    (graphics.PreferredBackBufferWidth / 2),
                (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2) -
                    (graphics.PreferredBackBufferHeight / 2)
            );
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
            Vector2 vector2 = new Vector2(XPos, YPos);          // Set initial location for texture

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
            // Load texture
            beetleRightFacing = Content.Load<Texture2D>("BeatleRightFacing");
            // Load sprite font
            spriteFont = Content.Load<SpriteFont>("spriteFont");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //XPos++;                                             // Increase X position of texture by 1

            //position = new Vector2(XPos, YPos);                 // Update position variable

            ProcessInput();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.MonoGameOrange);

            spriteBatch.Begin();                                // Begin draw process

            spriteBatch.Draw(beetleRightFacing, position, Color.White);
            spriteBatch.DrawString(spriteFont, "test", position, Color.Blue);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void ProcessInput()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.A))                    // Move left
            {
                position.X = position.X - 5;
            }

            if (keyboardState.IsKeyDown(Keys.D))                    // Move right
            {
                position.X = position.X + 5;
            }

            if (keyboardState.IsKeyDown(Keys.W))                    // Move up
            {
                position.Y = position.Y - 5;
            }

            if (keyboardState.IsKeyDown(Keys.S))                    // Move down
            {
                position.Y = position.Y + 5;
            }
        }
    }
}

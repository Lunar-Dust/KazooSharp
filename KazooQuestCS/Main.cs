using KazooQuestCS.GUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace KazooQuestCS
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Menu menu;
        World world;

        public const int tileSize = 50;
        public const int windowSize = 550;

        public static List<Menu> menus;
        public static Player player;
        public static GraphicsDevice graphicsDevice;
        public static XmlDocument Enemies;

        public static KeyboardState currKeyboard;
        public static KeyboardState prevKeyboard;

        public static bool KeyPush(Keys key)
        {
            if( currKeyboard.IsKeyDown(key) && !prevKeyboard.IsKeyDown(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = windowSize;
            graphics.PreferredBackBufferHeight = windowSize;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        public void Start()
        {
            player.Active = true;
            world.Active = true;
            menu.Dispose();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphicsDevice = GraphicsDevice;

            Enemies = new XmlDocument();
            Enemies.Load("Data/Enemies.xml");
            player = new Player();
            player.Create("AAAAA", 0);
            menu = new Menu();
            Rectangle menuRect = new Rectangle(200, 100, 200, 300);
            Texture2D menuTexture = new Texture2D(GraphicsDevice, 200, 300);
            menu.Initialize(menuTexture, "Main Menu", menuRect);
            menu.Add("Test", Start);
            menu.Add("Another test", Start);

            world = new World();
            world.Initialize();
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

            Rectangle playerRect = new Rectangle((GraphicsDevice.Viewport.Width / 2),
                (GraphicsDevice.Viewport.Height / 2),
                (int)(tileSize * 0.5), (int)(tileSize * 0.5));

            FileStream fileStream = new FileStream("Content/Graphics/player.png", FileMode.Open);
            player.Initialize(Texture2D.FromStream(GraphicsDevice, fileStream), playerRect);
            fileStream.Dispose();

            SpriteFont font = Content.Load<SpriteFont>("Graphics/Arial");
            menu.SetFont(font);
            //System.Diagnostics.Debug.Write(Enemies.InnerXml);
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
            prevKeyboard = currKeyboard;
            currKeyboard = Keyboard.GetState();

            // TODO: Add your update logic here
            player.Update(gameTime);
            menu.Update(gameTime);
            world.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            world.Draw(spriteBatch);
            player.Draw(spriteBatch);
            menu.Draw(spriteBatch);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

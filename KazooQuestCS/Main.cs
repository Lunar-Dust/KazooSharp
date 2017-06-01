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

        public const int tileSize = 5;
        public const int windowSize = 550;

        public static Dictionary<string, SpriteFont> Fonts;

        public static List<Menu> menus;
        public static Player player;
        public static World world;
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

        public static bool KeyDown(Keys key)
        {
            return currKeyboard.IsKeyDown(key);
        }

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = windowSize;
            graphics.PreferredBackBufferHeight = windowSize;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            Fonts = new Dictionary<string, SpriteFont>();
            Enemies = new XmlDocument();
            menus = new List<Menu>();
        }

        public void Start()
        {
            player.Active = true;
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
            Enemies.Load("Data/Enemies.xml");
            Rectangle menuRect = new Rectangle(100, 100, windowSize - 100, windowSize - 100);
            menus.Add(new Menu("Test menu", menuRect));
            menus[0].Add("Start Game", Start);
            menus[0].Active = true;

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


            FileStream fileStream = new FileStream("Content/Graphics/player.png", FileMode.Open);
            player = new Player(Texture2D.FromStream(GraphicsDevice, fileStream));
            fileStream.Dispose();

            SpriteFont font = Content.Load<SpriteFont>("Graphics/Arial");
            Fonts.Add("Arial", font);
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
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            prevKeyboard = currKeyboard;
            currKeyboard = Keyboard.GetState();
            player.Update(gameTime);
            foreach (Menu menu in menus)
            {
                menu.Update(gameTime);
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            player.Draw(spriteBatch);
            foreach (Menu menu in menus) {
                menu.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

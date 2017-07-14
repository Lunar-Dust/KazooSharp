using KazooQuestCS.GUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
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
        InputManager inputManager;
        Camera camera;

        public const int tileSize = 32;
        public const int windowSize = 480;
        public const int maxVisibleTiles = windowSize / tileSize;
        public const int totalMapSize = maxVisibleTiles * 15;

        public static Dictionary<string, SpriteFont> Fonts;

        public static List<Menu> menus;
        public static Player player;
        public static World world;
        public static HUD hud;
        public static GraphicsDevice graphicsDevice;
        public static XmlDocument Enemies;
        public static Dictionary<string, Texture2D> TextureStore;
        public static Dictionary<string, string> Textures;
        public static AnimationManager AManager;

        // Because workarounds
        public static Action Pause;

        public static Random random = new Random(Guid.NewGuid().GetHashCode());

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

        // Praise the Stack https://stackoverflow.com/a/29089475
        public static Main self;

        public Main()
        {
            self = this;
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = windowSize;
            graphics.PreferredBackBufferHeight = windowSize;
            graphics.ApplyChanges();
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
            graphicsDevice = GraphicsDevice;

            Fonts = new Dictionary<string, SpriteFont>();
            Enemies = new XmlDocument();
            menus = new List<Menu>();
            TextureStore = new Dictionary<string, Texture2D>();
            Textures = new Dictionary<string, string>();
            AManager = new AnimationManager();
            Rectangle menuRect = new Rectangle(100, 100, windowSize - 100, windowSize - 100);
            menus.Add(new MainMenu());
            menus.Add(new PauseMenu());

            inputManager = new InputManager();
            camera = new Camera(graphicsDevice.Viewport);

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

            Enemies.Load("Data/Enemies.xml");

            List<string> graphicsFiles = new List<string>() { "player0", "player1", "player2", "player3", "player4", "player5", "Tiles/Grass1", "Tiles/Rock1", "wolf1" };

            foreach (string file in graphicsFiles)
            {
                Texture2D texture = Content.Load<Texture2D>(string.Format("Graphics/{0}", file));
                TextureStore.Add(file, texture);
            }
            Texture2D pixel = new Texture2D(graphicsDevice, 1, 1);
            pixel.SetData(new[] { Color.White });
            TextureStore.Add("Pixel", pixel);
            Textures.Add("player", "player0");
            player = new Player();
            Animation playerAnim = new Animation("player", 10);
            AManager.AddAnimation(playerAnim);
            world = new World();
            world.Initialize();
            hud = new HUD();

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
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            prevKeyboard = currKeyboard;
            currKeyboard = Keyboard.GetState();
            inputManager.Update(gameTime);
            AManager.Update(gameTime);
            foreach (Menu menu in menus)
            {
                menu.Update(gameTime);
            }
            player.Update(gameTime);
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

            // Relative elements
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend,
                              null, null, null, null, camera.TransformMatrix);
            world.Draw(spriteBatch);
            player.Draw(spriteBatch);
            spriteBatch.End();

            // Absolute elements
            spriteBatch.Begin();
            foreach (Menu menu in menus) {
                menu.Draw(spriteBatch);
            }
            hud.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

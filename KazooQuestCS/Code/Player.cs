using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace KazooQuestCS
{
    public class Player
    {
        private Stats stats;

        public Stats Stats { get { return stats;  } }
        public Texture2D Texture { get; }
        public Rectangle CollisionBox;
        public Rectangle OldCollisionBox;
        public Vector2 TilePosition { get; }
        public string Name { get; }
        public int Height { get { return Texture.Height; }}
        public int Width { get {return Texture.Width; }}
        public bool Active { get; set; }

        public Player(Texture2D texture)
        {
            Texture = texture;
            TilePosition = new Vector2(0, 0);
            CollisionBox = new Rectangle((Main.windowSize - Main.tileSize) / 2,
                                         (Main.windowSize - Main.tileSize) / 2,
                                          Main.tileSize, Main.tileSize);
            OldCollisionBox = CollisionBox;
        }

        public void Create(string name, int _class)
        {
            stats = new Stats();
            stats.Set(1, 100, 10, 10, 1, 0, 0);
        }

        public void Update(GameTime gameTime)
        {
            if (!Active) return;
            CollisionBox.X = MathHelper.Clamp(CollisionBox.X, 0, (Main.totalMapSize - 1) * Main.tileSize);
            CollisionBox.Y = MathHelper.Clamp(CollisionBox.Y, 0, (Main.totalMapSize - 1) * Main.tileSize);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Active) return;
            spriteBatch.Draw(Main.TextureStore["player"], CollisionBox, Color.White);
        }

        private void CheckValidTile()
        { }
    }
}

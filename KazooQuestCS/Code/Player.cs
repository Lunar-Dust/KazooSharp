using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace KazooQuestCS
{
    public class Player
    {
        public Texture2D Texture;
        public Rectangle CollisionBox;
        public Vector2 TilePosition;
        public string Name;
        public int Moves;
        public Stats Stats;
        private bool active = false;

        public int Height
        {
            get { return Texture.Height; }
        }

        public int Width
        {
            get { return Texture.Width; }
        }

        public bool Active
        {
            get
            {
                return active;
            }

            set
            {
                active = value;
            }
        }

        public Player(Texture2D texture)
        {
            Texture = texture;
            TilePosition = new Vector2(0, 0);
            CollisionBox = new Rectangle(0, 0, Main.tileSize / 2, Main.tileSize / 2);
        }

        public void Create(string name, int _class)
        {
            Stats = new Stats();
            Stats.Set(1, 100, 10, 10, 1, 0, 0);
        }

        public void Update(GameTime gameTime)
        {
            if (!active) return;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Active) return;
            spriteBatch.Draw(Texture, CollisionBox, null, Color.White);
        }

        private void CheckValidTile()
        { }
    }
}

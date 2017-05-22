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
        public Rectangle Position;
        public string Name;
        private bool active = false;
        public int Moves;
        /// <summary>
        /// 0- Keys.A
        /// 1- Keys.D
        /// 2- Keys.W
        /// 3- Keys.S
        /// </summary>
        public bool[] LastMove = new bool[4];

        private bool[] _lastReset = new bool[4];
        private IDictionary<string, int> stats;

        public int Height
        {
            get { return Texture.Height; }
        }

        public int Width
        {
            get { return Texture.Width; }
        }

        public IDictionary<string, int> Stats
        {
            get { return stats; }
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

        public void Initialize(Texture2D texture, Rectangle position)
        {
            Texture = texture;
            Position = position;
        }

        public void Create(string name, int _class)
        {
            stats.Add("max_health", 100);
            stats.Add("health", 100);
            stats.Add("max_mana", 10);
            stats.Add("mana", 10);
            stats.Add("max_stamina", 10);
            stats.Add("stamina", 10);
            stats.Add("attack", 1);
            stats.Add("defense", 0);
        }

        public void Update(GameTime gameTime)
        {
            MovePlayer();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Active) return;
            spriteBatch.Draw(Texture, Position, null, Color.White);
        }

        private void MovePlayer()
        {
            if (!Active) return;
            LastMove = (bool[])_lastReset.Clone();

            if (Main.currKeyboard.GetPressedKeys().Length > 0) ++Moves;

            if (Main.KeyPush(Keys.A))
            {
                Position.X -= Main.tileSize;
                LastMove[0] = true;
            }

            if (Main.KeyPush(Keys.D))
            {
                Position.X += Main.tileSize;
                LastMove[1] = true;
            }

            if (Main.KeyPush(Keys.W))
            {
                Position.Y -= Main.tileSize;
                LastMove[2] = true;
            }

            if (Main.KeyPush(Keys.S))
            {
                Position.Y += Main.tileSize;
                LastMove[3] = true;
            }
            
            if(Main.KeyPush(Keys.H))
            { Position.X--; }

            if (Main.KeyPush(Keys.J))
            { Position.Y++; }

            if (Main.KeyPush(Keys.K))
            { Position.Y--; }

            if (Main.KeyPush(Keys.L))
            { Position.X++; }

            Position.X = MathHelper.Clamp(Position.X, 0, Main.graphicsDevice.Viewport.Width - Main.tileSize);
            Position.Y = MathHelper.Clamp(Position.Y, 0, Main.graphicsDevice.Viewport.Height - Main.tileSize);
        }

        public Vector2 GetTile()
        {
            return new Vector2(Position.X / Main.tileSize,
                               Position.Y / Main.tileSize);
        }
    }
}

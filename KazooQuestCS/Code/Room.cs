using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazooQuestCS
{
    class Room
    {
        Vector2 Position;
        public Texture2D Texture = new Texture2D(Main.graphicsDevice, Main.tileSize, Main.tileSize);
        public bool Visible = true;
        Tile[,] Tiles;

        public Enemy Enemy;

        private int _xtiles;
        private int _ytiles;

        public Room(Vector2 position)
        {
            Random rnd = new Random(this.GetHashCode());
            if(rnd.Next(5) == 1) Enemy = new Enemy();
            Position = position;
            _xtiles = Main.graphicsDevice.Viewport.Width / Main.tileSize;
            _ytiles = Main.graphicsDevice.Viewport.Height / Main.tileSize;
            Tiles = new Tile[_xtiles, _ytiles];

            Color[] data = new Color[Texture.Width * Texture.Height];
            Texture.GetData(data);

            // This is ungodly ugly
            for (int x = 0; x < data.Length; ++x)
            {
                /*if (x < Texture.Width * 2)
                {
                    if (exits[2] == 1) data[x] = Color.Yellow;
                    else data[x] = Color.Black;
                }
                else if (x % Texture.Width == 0 || x % Texture.Width == Texture.Width - 1)
                {
                    if (exits[1] == 1) data[x] = Color.Blue;
                    else data[x] = Color.Black;
                }
                else if (x % Texture.Width == 1 || x % Texture.Width == 2)
                {
                    if (exits[0] == 1) data[x] = Color.Purple;
                    else data[x] = Color.Black;
                }
                else if (x > Texture.Width * (Texture.Height - 2))
                {
                    if (exits[3] == 1) data[x] = Color.Red;
                    else data[x] = Color.Black;
                }
                  else
                {*/
                if (Enemy != null) data[x] = Color.Red;
                else data[x] = Color.Black;
                //}
            }
            Texture.SetData(data);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Visible) return;

            spriteBatch.Draw(Texture, Position, Color.White);
             
        }
    }
}

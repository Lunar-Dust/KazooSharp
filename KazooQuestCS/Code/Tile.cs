using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace KazooQuestCS
{
    class Tile
    {
        public Texture2D Texture = new Texture2D(Main.graphicsDevice, Main.tileSize, Main.tileSize);
        public Vector2 Position;
        public Color _Color;

        public Tile(Vector2 position)
        {
            Position = position;
            SetColor();
        }

        public void SetColor(Tuple<int, int, int> color = null)
        {
            Color[] data = new Color[Texture.Width * Texture.Height];

            if (color == null)
            {
                Random rnd;
                rnd = new Random(this.GetHashCode() + Main.player.Moves);
                Texture.GetData(data);
                int r, g, b;
                r = rnd.Next(0, 256);
                g = rnd.Next(0, 256);
                b = rnd.Next(0, 256);
                _Color = new Color(r, g, b);
            }
            else
            {
                _Color = new Color(color.Item1, color.Item2, color.Item3);
                Texture.GetData(data);
            }
            for (int x = 0; x < data.Length; ++x)
            {
                data[x] = _Color;
            }
            Texture.SetData(data);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, _Color);
        }
    }
}

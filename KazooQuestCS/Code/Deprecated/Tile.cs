using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace KazooQuestCS
{
    public class Tile
    {
        public Texture2D Texture = new Texture2D(Main.graphicsDevice, Main.tileSize, Main.tileSize);
        public Vector2 Offset;
        public Rectangle Position;
        public Color Color;
        Enemy Enemy;

        public bool Passable = true;

        public Tile(Vector2 offset,
                    Color color)
        {
            Offset = offset;
            Position = new Rectangle((int)offset.X * Main.tileSize, (int)offset.Y * Main.tileSize,
                                     Main.tileSize, Main.tileSize);
            Color = color;
            SetColor();
        }

        private void SetColor()
        {
            Color[] data = new Color[Texture.Width * Texture.Height];
            Texture.GetData(data);
            for (int x = 0; x < data.Length; ++x)
            {
                data[x] = Color;
            }
            Texture.SetData(data);
        }

        public void SetEnemy(Enemy enemy)
        {
            Enemy = enemy;
        }

        public void Update(GameTime gameTime)
        {
            if (Enemy != null)
            {
                Random rnd = new Random(Guid.NewGuid().GetHashCode());
                int move = rnd.Next(1, 4);
                int offX = (int)Offset.X;
                int offY = (int)Offset.Y;

                switch (move)
                {
                    case 1:
                        if (Offset.X > 0)
                            offX--;
                        else offX++;
                        break;
                    case 2:
                        if (Offset.X < Main.totalMapSize - 1)
                            offX++;
                        else offX--;
                        break;
                    case 3:
                        if (Offset.Y > 0)
                            offY--;
                        else offY++;
                        break;
                    case 4:
                        if (Offset.Y < Main.totalMapSize - 1)
                            offY++;
                        else offY--;
                        break;
                }

                Tile tile = Main.world.GetTileByOffset(offX, offY);
                if (tile.Enemy == null && tile.Passable)
                {
                    tile.SetEnemy(Enemy);
                    Enemy = null;
                }


            }
        }

        public void Draw(SpriteBatch spriteBatch, bool aaa = false)
        {
            Vector2 pos = new Vector2((Main.world.CameraPosition.X + Offset.X) * Main.tileSize,
                                      (Main.world.CameraPosition.Y + Offset.Y) * Main.tileSize);
            spriteBatch.Draw(Texture, pos, Color);
            /*if (Enemy != null)
            {
                pos.X += (Main.tileSize / 4);
                pos.Y += (Main.tileSize / 4);
                spriteBatch.DrawString(Main.font, string.Format("!"), pos, Color.Red);
            }*/
            //if(Main.font != null)
            //    spriteBatch.DrawString(Main.font, string.Format("{0},{1}", Offset.X, Offset.Y), pos, Color.White);
        }
    }
}

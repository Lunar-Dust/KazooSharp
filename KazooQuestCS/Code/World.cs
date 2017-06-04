using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using System.Linq;


namespace KazooQuestCS
{
    public class World
    {
        public Tile[,] Tiles;
        private List<WeakReference<Tile>> nonFloorTiles;

        public bool Active { get; set; }

        public World()
        {
            Tiles = new Tile[Main.totalMapSize, Main.totalMapSize];
            nonFloorTiles = new List<WeakReference<Tile>>();
        }

        public void Initialize()
        {
            for (int x = 0; x < Main.totalMapSize; ++x)
            {
                for (int y = 0; y < Main.totalMapSize; ++y)
                {
                    switch (Main.random.Next(5))
                    {
                        case 1:
                            Tiles[x, y] = new Tile(new Vector2(x, y), "Tiles/Rock1");
                            Tiles[x, y].IsPassable = false;
                            nonFloorTiles.Add(new WeakReference<Tile>(Tiles[x, y]));
                            break;
                        default:
                            Tiles[x, y] = new Tile(new Vector2(x, y), "Tiles/Grass1");
                            break;
                    }
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            if (!Active) return;
            foreach (WeakReference<Tile> tileRef in nonFloorTiles)
            {
                Tile tile;
                tileRef.TryGetTarget(out tile);
                if(tile != null)
                    if(tile.CollisionBox.Intersects(Main.player.CollisionBox))
                    {
                        Rectangle collision = Rectangle.Intersect(tile.CollisionBox, Main.player.CollisionBox);
                        if (collision.Width == collision.Height)
                        {
                            Main.player.CollisionBox.Offset(0.1f, 0.1f);
                        }

                        if (collision.Width <= collision.Height)
                        {
                            int colX = collision.Center.X - tile.CollisionBox.Center.X;
                            if (colX <= 0)
                                Main.player.CollisionBox.X -= collision.Width;
                            else Main.player.CollisionBox.X += collision.Width;
                        }
                        else
                        {
                            int colY = collision.Center.Y - tile.CollisionBox.Center.Y;
                            if (colY <= 0)
                                Main.player.CollisionBox.Y -= collision.Height;
                            else Main.player.CollisionBox.Y += collision.Height;
                        }
                    }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Active) return;
            int xPos = Main.player.CollisionBox.X / Main.tileSize;
            int yPos = Main.player.CollisionBox.Y / Main.tileSize;
            for (int x = xPos - Main.maxVisibleTiles / 2; x < xPos + Main.maxVisibleTiles; ++x)
            {
                if (x < 0 || x > Main.totalMapSize - 1)
                    continue;
                for (int y = yPos - Main.maxVisibleTiles / 2; y < yPos + Main.maxVisibleTiles; ++y)
                {
                    if (y < 0 || y > Main.totalMapSize - 1) continue;
                    Tiles[x, y].Draw(spriteBatch);
                }
            }
            /* 
             * This was a really bad method for drawing, as it drew stuff that wasn't even visible
            foreach (Tile tile in Tiles)
                tile.Draw(spriteBatch);*/
        }
    }
}

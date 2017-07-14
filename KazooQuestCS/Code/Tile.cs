using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazooQuestCS
{
    public class Tile
    {
        public bool IsPassable { get; set; }

        public Rectangle CollisionBox;
        public Vector2 TilePosition;
        public Enemy Enemy;
        private string Texture;

        private WeakReference<Tile> tileUp = null;
        private WeakReference<Tile> tileDown = null;
        private WeakReference<Tile> tileLeft = null;
        private WeakReference<Tile> tileRight = null;

        public Tile(Vector2 tilePosition, string textureName)
        {
            TilePosition = tilePosition;
            Texture = textureName;
            CollisionBox = new Rectangle((int)TilePosition.X * Main.tileSize,
                                         (int)TilePosition.Y * Main.tileSize,
                                         Main.tileSize, Main.tileSize);

            int x = (int)tilePosition.X;
            int y = (int)tilePosition.Y;
            if (tilePosition.X > 0)
                tileLeft = new WeakReference<Tile>(Main.world.Tiles[x - 1, y]);
            if (tilePosition.X < Main.totalMapSize - 1)
                tileRight = new WeakReference<Tile>(Main.world.Tiles[x + 1, y]);
            if (tilePosition.Y > 0)
                tileUp = new WeakReference<Tile>(Main.world.Tiles[x, y - 1]);
            if (tilePosition.Y < Main.totalMapSize - 1)
                tileDown = new WeakReference<Tile>(Main.world.Tiles[x, y + 1]);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Main.TextureStore[Texture], CollisionBox, Color.Gray);
            if(Enemy != null)
            {
                Enemy.Draw(spriteBatch);
            }
        }
    }
}

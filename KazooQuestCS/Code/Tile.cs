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
        private Texture2D Texture;

        public Tile(Vector2 tilePosition, Texture2D texture = null)
        {
            TilePosition = tilePosition;
            Texture = texture;
            CollisionBox = new Rectangle((int)TilePosition.X * Main.tileSize,
                                         (int)TilePosition.Y * Main.tileSize,
                                         Main.tileSize, Main.tileSize);
        }
    }
}

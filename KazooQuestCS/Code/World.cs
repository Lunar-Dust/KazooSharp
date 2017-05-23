using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using System.Linq;

namespace KazooQuestCS
{
    class World
    {
        int roomCount = 1;
        const int mapRooms = Main.windowSize / Main.tileSize;
        const int roomWant = 15;
        const int roomStart = (int)mapRooms / 2;
        Room[,] Rooms = new Room[mapRooms, mapRooms];

        private bool active = false;

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

        public void Initialize()
        {
            Rooms[roomStart, roomStart] = new Room(new Vector2(roomStart * Main.tileSize));
            while (roomCount < roomWant)
            {
                for(int x=0; x < mapRooms; ++x)
                {
                    Random rnd = new Random(Guid.NewGuid().GetHashCode());
                    for (int y=0; y < mapRooms; ++y)
                    {
                        Random rand = new Random(rnd.Next(256));
                        // Left, Right, Up, Down
                        List<int> val = NearRoom(x, y);
                        if (!val.Contains(-1))
                        {
                            if (rand.Next(5) != 1) continue;
                            if (Rooms[x, y] != null) continue;
                            Rooms[x, y] = new Room(new Vector2(x * Main.tileSize, y * Main.tileSize));
                            roomCount++;
                        }
                    }
                }
            }
        }

        private List<int> NearRoom(int x, int y)
        {
            List<int> returns = new List<int>();

            if (x == 0 || y == 0) return new List<int>() { -1 };
            if (x == mapRooms - 1 || y == mapRooms - 1) return new List<int>() { -1 };

            if (Rooms[x - 1, y] != null) returns.Add(1);

            if (Rooms[x + 1, y] != null) returns.Add(2);

            if (Rooms[x, y - 1] != null) returns.Add(3);

            if (Rooms[x, y + 1] != null) returns.Add(4);

            if(returns.Count == 0) return new List<int>() { -1 };
            else return returns;
        }

        public void Update(GameTime gameTime)
        {
            int x = Main.player.Position.X / Main.tileSize;
            int y = Main.player.Position.Y / Main.tileSize;
            x = MathHelper.Clamp(x, 0, roomWant - 1);
            y = MathHelper.Clamp(y, 0, roomWant - 1);
            if (Main.player.LastMove[0])
                if(Rooms[x, y] == null) x++;

            if (Main.player.LastMove[1])
                if (Rooms[x, y] == null) x--;

            if (Main.player.LastMove[2])
                if (Rooms[x, y] == null) y++;

            if (Main.player.LastMove[3])
                if (Rooms[x, y] == null) y--;

            Main.player.Position.X = (x * Main.tileSize) + (int)(Main.tileSize * 0.25);
            Main.player.Position.Y = (y * Main.tileSize) + (int)(Main.tileSize * 0.25);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Active) return;
            for (int x=0; x < mapRooms; ++x)
            {
                for (int y = 0; y < mapRooms; ++y)
                {
                    if (Rooms[x, y] == null) continue;
                        Rooms[x, y].Draw(spriteBatch);
                }
            }
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using System.Xml;

namespace KazooQuestCS
{
    public class Enemy
    {
        Texture2D Texture;
        Vector2 Position;
        Stats Stats = new Stats();

        public Enemy()
        {
            int level = Main.player.Stats.Level;
            XmlNodeList enemies = Main.Enemies.SelectNodes(string.Format("/Enemies/Enemy[level > {0} and level < {1}]", level - 3, level + 3));
            Random rnd = new Random(GetHashCode());
            int _index = rnd.Next(enemies.Count);
            Stats.FromXml(enemies[_index]);
            Texture = new Texture2D(Main.graphicsDevice, Main.tileSize / 2, Main.tileSize / 2);
            Color[] data = new Color[Texture.Width * Texture.Height];
            Texture.GetData(data);

            for (int x=0; x < data.Length; ++x)
            {
                int r = rnd.Next(256);
                int g = rnd.Next(256);
                int b = rnd.Next(256);
                data[x] = new Color(r, g, b);
            }
            Texture.SetData(data);
        }

        public void StartFight()
        {
            Main.world.Active = false;

        }

        public void Update()
        { }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}

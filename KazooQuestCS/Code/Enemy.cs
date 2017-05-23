using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using System.Xml;

namespace KazooQuestCS
{
    class Enemy
    {
        Texture2D Texture;
        Vector2 Position;
        Stats Stats = new Stats();

        public Enemy()
        {
            int level = Main.player.Stats.Level;
            XmlNodeList enemies = Main.Enemies.SelectNodes(String.Format("/Enemies/Enemy[level > {0} and level < {1}]", level - 3, level + 3));
            Random rnd = new Random(this.GetHashCode());
            int _index = rnd.Next(enemies.Count);
            Stats.FromXml(enemies[_index]);
        }
    }
}

﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace KazooQuestCS.GUI
{
    enum ButtonType
    {
        basic = 0,   // Calls a function
        toggle = 1,  // Changes a setting thing
        submenu = 2, // Opens another menu
        back = 3     // Goes back from a submenu
    }

    public class Button
    {
        public Vector2 Position;
        public string Name;
        public string Text;
        public int Type { get; }
        protected Action _Call = null;

        public Button(string name, int type, string text = "")
        {
            Name = name;
            Type = type;
            if (text == "") Text = name;
            else Text = text;
        }

        public void Initialize(Action call)
        {
            _Call = call;
        }

        public void Call()
        {
            _Call();
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            if(Main.Fonts != null)
                spriteBatch.DrawString(Main.Fonts["Arial"], Text, Position, Color.Black);
        }
    }
}

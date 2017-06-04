using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using KazooQuestCS.GUI;

namespace KazooQuestCS
{
    public class Menu : IDisposable
    {
        string Title;
        Texture2D Background;
        SpriteFont Font;
        Rectangle Position;
        public bool Active { get; set; }
        public short Selected = 0;

        private Vector2 _base;
        private Vector2 _pos;

        public List<Button> Items = new List<Button>();
         
        public void Dispose()
        {
            Active = false;
            Items.Clear();
            if(Background != null) Background.Dispose();
        }

        public void SetFont(SpriteFont font)
        {
            if(Font == null) Font = font;
        }

        public Menu(string title,
                    Rectangle position,
                    Texture2D background = null,
                    bool active = false)
        {
            _base.X = position.Left;
            _base.Y = position.Top;
            if (background == null) Background = new Texture2D(Main.graphicsDevice, position.Width, position.Height);
            else Background = background;
            Title = title;
            Active = active;
        }

        public void Add(string name, Action action, int type = 0, string text = "")
        {
            Button b = new Button(name, type, text);
            if (text == "") text = name;
            b.Initialize(action);
            b.Position.X = _base.X;
            b.Position.Y = _base.Y + ((Background.Height / 10) * Items.Count);
            Items.Add(b);
        }

        public void Update(GameTime gameTime)
        {
            if (!Active) return;
            Selected = (short)MathHelper.Clamp(Selected, 0, Items.Count - 1);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Active) return;
            spriteBatch.Draw(Background, Position, Color.White);
            _pos = _base;
            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].Draw(spriteBatch, Font);
            }
            _pos.X -= Main.graphicsDevice.Viewport.Width / 8;
            _pos.Y += ((Background.Height / 10) * Selected);
            spriteBatch.DrawString(Main.Fonts["Arial"], ">>", _pos, Color.DarkGreen);
        }
    }
}

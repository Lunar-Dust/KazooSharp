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
        bool Active;
        bool Visible = true;
        short Selected = 0;

        private Vector2 _base;
        private Vector2 _pos;

        List<Button> Items = new List<Button>();
         
        public void Dispose()
        {
            Active = false;
            Visible = false;
            Items.Clear();
            //_Submenus.Clear();
            if(Background != null) Background.Dispose();
        }

        public void SetFont(SpriteFont font)
        {
            if(Font == null) Font = font;
        }

        public void Initialize(Texture2D background,
            string title,
            Rectangle position)
        {
            _base.X = position.Left;
            _base.Y = position.Top;
            Background = background;
            Title = title;
            Active = true;
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
            if (Main.currKeyboard.IsKeyDown(Keys.W) && !Main.prevKeyboard.IsKeyDown(Keys.W))
                Selected -= 1;

            if (Main.currKeyboard.IsKeyDown(Keys.S) && !Main.prevKeyboard.IsKeyDown(Keys.S))
                Selected += 1;

            if (Main.currKeyboard.IsKeyDown(Keys.Enter) && !Main.prevKeyboard.IsKeyDown(Keys.Enter))
                Items[Selected].Call();

            Selected = (short)MathHelper.Clamp(Selected, 0, Items.Count - 1);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Visible) return;
            spriteBatch.Draw(Background, Position, Color.White);
            _pos = _base;
            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].Draw(spriteBatch, Font);
            }
            _pos.X -= Main.graphicsDevice.Viewport.Width / 8;
            _pos.Y += ((Background.Height / 10) * Selected);
            spriteBatch.DrawString(Font, ">>", _pos, Color.DarkGreen);
        }

        public void ToggleVisibility()
        {
            Visible = !Visible;
        }
    }
}

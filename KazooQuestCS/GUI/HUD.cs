using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using KazooQuestCS;

namespace KazooQuestCS.GUI
{
    public class HUD
    {
        public bool Active { get; set; }

        public HUD(bool active = true)
        {
            Active = active;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Main.TextureStore["Pixel"],
                new Rectangle(0, 0,
                spriteBatch.GraphicsDevice.Viewport.Width,
                spriteBatch.GraphicsDevice.Viewport.Height / 10), Color.Black);
            /*spriteBatch.Draw(Main.TextureStore["Pixel"],
                new Rectangle(0, 0,
                spriteBatch.GraphicsDevice.Viewport.Width / 20,
                spriteBatch.GraphicsDevice.Viewport.Height), Color.Black);
            spriteBatch.Draw(Main.TextureStore["Pixel"],
                new Rectangle((spriteBatch.GraphicsDevice.Viewport.Width / 20) * 19, 0,
                spriteBatch.GraphicsDevice.Viewport.Width / 20,
                spriteBatch.GraphicsDevice.Viewport.Height), Color.Black);
            spriteBatch.Draw(Main.TextureStore["Pixel"],
                new Rectangle(0, (spriteBatch.GraphicsDevice.Viewport.Height / 20) * 19,
                spriteBatch.GraphicsDevice.Viewport.Width,
                spriteBatch.GraphicsDevice.Viewport.Height / 20), Color.Black);*/
        }
    }
}

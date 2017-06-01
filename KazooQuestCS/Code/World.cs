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
            
        }

        public void Update(GameTime gameTime)
        {
            if (!active) return;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!active) return;
        }
    }
}

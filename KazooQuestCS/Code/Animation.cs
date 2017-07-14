using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KazooQuestCS
{
    public class Animation
    {
        private int Frame;
        private int Frames = -1;
        private string Name;
        private Regex reg;
        private int Delay;
        private int delayLoop = 0;

        public string TextureName
        {
            get
            {
                return string.Format("{0}{1}", Name, Frame);
            }
        }

        public Animation(
            string name, int delay = 0,
            int frameCount = -1)
        {
            reg = new Regex(name + @"\d{1,}");
            if (frameCount == -1)
            {
                foreach (KeyValuePair<string, Texture2D> entry in Main.TextureStore)
                {
                    if (reg.Match(entry.Key).Success)
                    {
                        Frames++;
                    }
                }
            }
            else
            {
                Frames = frameCount - 1;
            }

            Name = name;
            Delay = delay;
        }

        public void Update(GameTime gameTime)
        {
            if (Delay == 0)
            {
                Frame++;
                if (Frame > Frames)
                    Frame = 0;
                UpdateTexture();
                return;
            }

            delayLoop++;
            if (delayLoop >= Delay)
            {
                delayLoop = 0;
                Frame++;
                if (Frame >= Frames)
                    Frame = 0;
                UpdateTexture();
            }
        }

        public void UpdateTexture()
        {
            Main.Textures[Name] = TextureName;
        }
    }
}

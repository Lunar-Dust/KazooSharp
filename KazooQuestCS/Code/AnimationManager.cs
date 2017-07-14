using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazooQuestCS
{
    public class AnimationManager
    {
        private List<Animation> animations;

        public AnimationManager()
        {
            animations = new List<Animation>();
        }

        public void AddAnimation(Animation anim)
        {
            animations.Add(anim);
        }

        public void Update(GameTime gameTime)
        {
            foreach(Animation anim in animations)
            {
                anim.Update(gameTime);
            }
        }
    }
}

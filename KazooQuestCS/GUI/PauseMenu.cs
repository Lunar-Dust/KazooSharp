using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using KazooQuestCS.GUI;

namespace KazooQuestCS.GUI
{
    class PauseMenu : Menu
    {
        public PauseMenu()
        {
            Title = "PauseMenu";
            Active = false;
            Add("Resume", Resume);
            Add("Exit", Main.self.Exit);
            Main.Pause = Pause;
        }

        public void Pause()
        {
            Main.player.Active = false;
            Main.world.Active = false;
            Active = true;
        }

        private void Resume()
        {
            Active = false;
            // TODO: check to see if this is abusable
            Main.player.Active = true;
            Main.world.Active = true;
        }
    }

}

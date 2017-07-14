using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace KazooQuestCS.GUI
{
    class MainMenu : Menu
    {
        public MainMenu()
        {
            Add("Start Game", Start);
            Add("Exit", Main.self.Exit);
            Active = true;
        }
        private void Start()
        {
            Active = false;
            Main.player.Active = true;
            Main.world.Active = true;
        }
    }
}

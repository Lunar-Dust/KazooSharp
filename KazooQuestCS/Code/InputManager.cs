using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazooQuestCS
{
    public class InputManager
    {
        const int playerMoveDistance = Main.tileSize / 10;
        public void Update(GameTime gameTime)
        {
            MenuInput();
            PlayerInput();
        }

        private void MenuInput()
        {
            foreach (Menu menu in Main.menus)
            {
                if (!menu.Active) continue;

                if (Main.KeyPush(Keys.W))
                    menu.Selected -= 1;

                if (Main.KeyPush(Keys.S))
                    menu.Selected += 1;

                if (Main.KeyPush(Keys.Enter))
                {
                    menu.Items[menu.Selected].Call();
                    if (menu.Items[menu.Selected].Type != 1)
                        menu.Active = false;
                }
            }
        }

        private void PlayerInput()
        {
            if (!Main.player.Active)
                return;
            if (Main.currKeyboard.GetPressedKeys().Length > 0)
                Main.player.OldCollisionBox = Main.player.CollisionBox;
            else
                return;

            if (Main.KeyDown(Keys.A))
                Main.player.CollisionBox.X -= playerMoveDistance;
            if (Main.KeyDown(Keys.D))
                Main.player.CollisionBox.X += playerMoveDistance;

            if (Main.KeyDown(Keys.W))
                Main.player.CollisionBox.Y -= playerMoveDistance;
            if (Main.KeyDown(Keys.S))
                Main.player.CollisionBox.Y += playerMoveDistance;
        }
    }
}

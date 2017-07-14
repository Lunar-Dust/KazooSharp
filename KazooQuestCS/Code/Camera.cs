using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazooQuestCS
{
    public class Camera
    {
        public Point Location
        {
            get
            {
                return Main.player.CollisionBox.Center;
            }
        }
        public float Rotation { get; set; }
        public float Zoom { get; set; }

        private Rectangle Bounds { get; set; }

        public Matrix TransformMatrix
        {
            get
            {
                return
                    Matrix.CreateTranslation(new Vector3(-Location.X, -Location.Y, 0)) *
                    Matrix.CreateTranslation(new Vector3(Bounds.Width * 0.5f, Bounds.Height * 0.5f, 0));
            }
        }

        public Camera(Viewport viewport)
        {
            Bounds = viewport.Bounds;
        }
    }
}

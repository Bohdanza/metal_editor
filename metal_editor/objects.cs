using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace metal_editor
{
    public class Hero:PhysicalObject
    {
        public Hero(ContentManager contentManager, float x, float y):base(contentManager, "hero", x, y, x+0.7f, y+0.9f)
        {

        }
    }
}
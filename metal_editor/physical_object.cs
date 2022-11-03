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
using Newtonsoft.Json;

namespace metal_editor
{
    public abstract class PhysicalObject
    {
        [JsonProperty]
        public bool Rigid { get; protected set; }
        [JsonProperty]
        public bool GravitationAffected { get; protected set; }
        
        [JsonProperty]
        public virtual float X1 { get; protected set; }
        [JsonProperty]
        public virtual float Y1 { get; protected set; }
        [JsonProperty]
        public virtual float X2 { get; protected set; }
        [JsonProperty]
        public virtual float Y2 { get; protected set; }

        [JsonProperty]
        public virtual DynamicTexture Texture { get; protected set; }

        [JsonProperty]
        public Vector2 Vector { get; private set; }

        /// <summary>
        /// initializer with rigidness and gravitation enabled
        /// </summary>
        /// <param name="contentManager"></param>
        /// <param name="name">texture base name</param>
        /// <param name="x1">coords</param>
        /// <param name="y1">coords</param>
        /// <param name="x2">coords</param>
        /// <param name="y2">coords</param>
        protected PhysicalObject(ContentManager contentManager, string name, float x1, float y1, float x2, float y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;

            Rigid = true;
            GravitationAffected = true;

            Texture = new DynamicTexture(contentManager, name);
            Vector = new Vector2(0, 0);
        }

        protected PhysicalObject(ContentManager contentManager, string name, 
            float x1, float y1, float x2, float y2,
            bool gravitationAffected, bool rigid)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;

            Rigid = rigid;
            GravitationAffected = gravitationAffected;

            Texture = new DynamicTexture(contentManager, name);
            Vector = new Vector2(0, 0);
        }

        public virtual void Update(ContentManager contentManager, Level level)
        {
            Texture.Update(contentManager);
        }

        public virtual void Draw(SpriteBatch spriteBatch, int x, int y, Color color) 
        { spriteBatch.Draw(Texture.GetCurrentFrame(), new Vector2(x, y), color); }
        
        public virtual void AddVector(Vector2 vector)
        {
            Vector = new Vector2(Vector.X + vector.X, Vector.Y + vector.Y);
        }

        public virtual void AddVector(float x, float y)
        {
            Vector = new Vector2(Vector.X + x, Vector.Y + y);
        }
    }
}
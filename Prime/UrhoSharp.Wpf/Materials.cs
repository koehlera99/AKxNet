using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urho;

namespace UrhoSharp.Wpf
{
    class Texture
    {
        public static Material Random => GetRandomTexture();

        public static Material BlackStone => GetTexture("BlackStone.png");
        public static Material Grass => GetTexture("Grass.jpg");
        public static Material BlueBlackSphere => GetTexture("BlueBlackSphere.jpg");
        public static Material BlueSlate => GetTexture("BlueSlate.jpg");
        public static Material BrownClay => GetTexture("BrownClay.jpg");
        public static Material Grass2 => GetTexture("Grass2.jpg");
        public static Material GreenSlate => GetTexture("GreenSlate.jpg");
        public static Material GreyBlocks => GetTexture("GreyBlocks.jpg");
        public static Material GreyClay => GetTexture("GreyClay.jpg");
        public static Material GreySlate => GetTexture("GreySlate.jpg");
        public static Material GreyTile => GetTexture("GreyTile.jpg");
        public static Material SquareSquareBlue => GetTexture("SquareSquareBlue.jpg");
        public static Material Whitestone => GetTexture("Whitestone.jpg");
        public static Material Whitestone2 => GetTexture("Whitestone2.jpg");
        public static Material Whitestone3 => GetTexture("Whitestone3.jpg");
        public static Material WoodPanel => GetTexture("WoodPanel.jpg");
        public static Material OakPanel => GetTexture("OakPanel.jpg");
        public static Material Brick => GetTexture("Brick.jpg");

        public Texture()
        {
            SetUpTexture();
        }

        private static List<Material> TextureList = new List<Material>();

        private static Material GetTexture(string textureName)
        {
            return Material.FromImage($"Textures/{textureName}");
        }

        public static Material GetRandomTexture()
        {
            if (TextureList.Count() == 0)
                SetUpTexture();

            int random = (int)Urho.Randoms.Next(0, TextureList.Count());

            return GetTexture(random);
        }

        public static Material GetTexture(int index)
        {
            return TextureList[index];
        }

        private static void SetUpTexture()
        {
            TextureList = new List<Material>();

            TextureList.Add(Texture.BlackStone);
            //TextureList.Add(Texture.Grass);
            TextureList.Add(Texture.BlueBlackSphere);
            //TextureList.Add(Texture.BlueSlate);
            TextureList.Add(Texture.BrownClay);
            //TextureList.Add(Texture.Grass2);
            //TextureList.Add(Texture.GreenSlate);
            TextureList.Add(Texture.GreyTile);
            TextureList.Add(Texture.SquareSquareBlue);
            TextureList.Add(Texture.Whitestone);
            TextureList.Add(Texture.Whitestone2);
            TextureList.Add(Texture.Whitestone3);
            //TextureList.Add(Texture.WoodPanel);
            //TextureList.Add(Texture.OakPanel);
            TextureList.Add(Texture.Brick);

        }
    }
}

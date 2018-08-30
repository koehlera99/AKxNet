using System.Collections.Generic;
using System.Linq;
using Urho.Resources;
using Urho.Gui;
using Urho.Navigation;
using System;
using System.Diagnostics;
using Urho;
using Urho.Actions;
using Urho.Shapes;
using System.Threading.Tasks;
using RPG.Standard.Tools;
using System.Threading;

namespace UrhoSharp.Wpf.Scenes
{
    class Scene1
    {
        public Dictionary<Vector3, Block> ListOfStaticBlocks { get; set; }
        public Dictionary<Vector3, Block> ListOfCharacters { get; set; }

        public Block PrimayCharacter { get; set; }

        public bool CheckBlockLocationIsEmpty(Vector3 vector)
        {
            return !ListOfStaticBlocks.ContainsKey(vector) && !ListOfCharacters.ContainsKey(vector);
        }

        public bool CheckBlockExistsInLocation(Block block)
        {
            return CheckBlockLocationIsEmpty(block.Location);
        }

        public void CreateListOfBlocks(Scene scene)
        {
            ListOfStaticBlocks = new Dictionary<Vector3, Block>();

            AddCharacter(scene);
            AddCharacterSphere(scene);
            AddLevelFoundation(scene);
            AddLevelTerrain(scene);
            CreateBoxes(scene);
        }

        private void AddCharacter(Scene scene)
        {
            PrimayCharacter = new Block(scene.CreateChild());

            PrimayCharacter.Location = new Vector3(12 * 5, 40, 10);


            //character.Shape = Sphere;
            var cp = PrimayCharacter.BlockNode.CreateComponent<Sphere>();
            cp.SetMaterial(Texture.GetRandomTexture());



            PrimayCharacter.BlockNode.RunActionsAsync(
               new RepeatForever(
                   new RotateBy(duration: 1, deltaAngleX: 0, deltaAngleY: 90, deltaAngleZ: 0)));

            //character.RunActionsAsync(
            //   new RepeatForever(
            //       new RotateAroundBy(1, new Vector3(13 * 5, 50, 20), 50, 50, 50)));

            //ListOfCharacters.Add(character.Location, character);
        }

        private void AddCharacterSphere(Scene scene)
        {
            ListOfCharacters = new Dictionary<Vector3, Block>();

            for (int i = 0; i < 20; i++)
            {
                var block = new Block(scene.CreateChild());

                block.Location = new Vector3(i * 5, 40, Roll.d10 * 5);

                var sphere = block.BlockNode.CreateComponent<Sphere>();
                sphere.SetMaterial(Texture.GetRandomTexture());

                //node.RunActionsAsync(
                //   new RepeatForever(
                //       new RotateBy(duration: 1, deltaAngleX: 0, deltaAngleY: Roll.d100, deltaAngleZ: 0)));

                //node.RunActionsAsync(
                //   new RepeatForever(
                //       new RotateAroundBy(1, new Vector3(Roll.d20 * 5, Roll.d100, Roll.d20), Roll.d100, Roll.d100, Roll.d100)));

                ListOfCharacters.Add(block.Location, block);
            }
        }

        public void AddCharacterSpheresAgain(Scene scene)
        {
            AddCharacterSphere(scene);
        }

        public void DropCharacterSpheres()
        {
            int count = 1;

            foreach(var block in ListOfCharacters)
            {
                var vector = block.Value.Location;

                vector.Y -= 35;

                while (!CheckBlockLocationIsEmpty(vector))
                {
                    vector.Y += 5;
                }

                var moveTo = new MoveTo(count, vector);
                var ease = new EaseBounceOut(moveTo);

                block.Value.BlockNode.RunActionsAsync(ease);

                count++;

                if (count == 4)
                    count = 2;
                    
            }
        }

        private void AddLevelFoundation(Scene scene)
        {
            for (int x = 0; x < 50; x++)
            {
                for (int y = 0; y < 50; y++)
                {
                    var block = new Block(scene.CreateChild());

                    block.Location = new Vector3(x * 5, 0, y * 5);

                    var box = block.BlockNode.CreateComponent<Box>();

                    if (x == 17 || x == 18)
                    {
                        box.SetMaterial(Texture.Grass);
                    }
                    else
                    {
                        box.SetMaterial(Texture.BlackStone);
                    }

                    ListOfStaticBlocks.Add(block.Location, block);
                }
            }
        }

        private void AddLevelTerrain(Scene scene)
        {
            for (int x = 15; x <= 20; x++)
            {
                for (int y = 15; y <= 20; y++)
                {
                    for (int z = 1; z < 5; z++)
                    {
                        var block = new Block(scene.CreateChild());

                        block.Location = new Vector3(x * 5, z * 5, y * 5);

                        var box = block.BlockNode.CreateComponent<Box>();

                        if ((z == 1 || z == 2) && (x == 17 || x == 18))
                        {
                            box.SetMaterial(Texture.OakPanel);
                        }
                        else
                        {
                            box.SetMaterial(Texture.Brick);
                        }

                        ListOfStaticBlocks.Add(block.Location, block);
                    }
                }
            }
        }

        private void CreateBoxes(Scene scene)
        {
            // Create randomly sized boxes. If boxes are big enough, make them occluders
            uint numBoxes = 15;
            const float size = 5f;

            for (uint i = 0; i < numBoxes; ++i)
            {
                var block = new Block(scene.CreateChild());

                do
                {
                    block.Location = new Vector3(NextRandom(i) * size, size, NextRandom(i) * size);
                }
                while (ListOfStaticBlocks.ContainsKey(block.Location));
                
                var box = block.BlockNode.CreateComponent<Box>();
                box.SetMaterial(Texture.WoodPanel);

                ListOfStaticBlocks.Add(block.Location, block);
            }

            numBoxes += 20;

            for (uint i = 14; i < numBoxes; ++i)
            {
                var block = new Block(scene.CreateChild());

                do
                {
                    block.Location = new Vector3(NextRandom(i) * size, size, NextRandom(i) * size);
                }
                while (ListOfStaticBlocks.ContainsKey(block.Location));

                var box = block.BlockNode.CreateComponent<Box>();
                box.SetMaterial(Texture.LightWood);

                ListOfStaticBlocks.Add(block.Location, block);
            }

            numBoxes = 15;

            for (uint i = 0; i < numBoxes; ++i)
            {
                var block = new Block(scene.CreateChild());

                do
                {
                    block.Location = new Vector3(NextRandom(i) * size, size, NextRandom(i) * size);
                }
                while (ListOfStaticBlocks.ContainsKey(block.Location));

                var box = block.BlockNode.CreateComponent<Box>();
                box.SetMaterial(Texture.OakPanel);

                ListOfStaticBlocks.Add(block.Location, block);
            }

            numBoxes += 20;

            for (uint i = 14; i < numBoxes; ++i)
            {
                var block = new Block(scene.CreateChild());

                do
                {
                    block.Location = new Vector3(NextRandom(i) * size, size, NextRandom(i) * size);
                }
                while (ListOfStaticBlocks.ContainsKey(block.Location));

                var box = block.BlockNode.CreateComponent<Box>();
                box.SetMaterial(Texture.DarkWood);

                ListOfStaticBlocks.Add(block.Location, block);
            }
        }

        System.Random Random = new Random();

        public float NextRandom(float max)
        {
            int next = Random.Next(0, (int)max + 5);

            return next; // > 5 ? max : next;
        }
    }
}

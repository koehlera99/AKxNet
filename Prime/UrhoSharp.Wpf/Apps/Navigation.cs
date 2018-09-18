
// Copyright (c) 2008-2015 the Urho3D project.
// Copyright (c) 2015 Xamarin Inc
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

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
using UrhoSharp.Wpf.Scenes;
using System.Threading;

namespace UrhoSharp.Wpf.Apps
{
    public class Navigation : Application
    {
        private static Scene BrickScene;
        float yaw;
        float pitch;
        bool drawDebug;
        Node jackNode;
        Vector3 endPos;
        List<Vector3> currentPath = new List<Vector3>();
        Node CameraNode;
        System.Random Random = new Random();

        private static Scene1 scene1;

        public Navigation(ApplicationOptions options = null) : base(options) { }

        protected override void Start()
        {
            base.Start();
            CreateScene();
            CreateUI();
            SetupViewport();
            SubscribeToEvents();

            //UI.m
            //UI.KeyDown += HandleKeyDown;
            scene1.DropLevelFoundation();
            Thread.Sleep(10000);
            //scene1.DropCharacterSpheres();


        }



        void HandleKeyDown(KeyDownEventArgs arg)
        {
            switch (arg.Key)
            {
                //case Key.Esc: Engine.(); return;
            }
        }

#pragma warning disable CS0618 // Type or member is obsolete
            void SubscribeToEvents()
        {
            Engine.SubscribeToPostRenderUpdate(args =>
            {
                // If draw debug mode is enabled, draw viewport debug geometry, which will show eg. drawable bounding boxes and skeleton
                // bones. Note that debug geometry has to be separately requested each frame. Disable depth test so that we can see the
                // bones properly
                if (drawDebug)
                    Renderer.DrawDebugGeometry(false);

                if (currentPath.Count > 0)
                {
                    // Visualize the current calculated path
                    DebugRenderer debug = BrickScene.GetComponent<DebugRenderer>();
                    debug.AddBoundingBox(new BoundingBox(endPos - new Vector3(0.1f, 0.1f, 0.1f), endPos + new Vector3(0.1f, 0.1f, 0.1f)),
                        new Color(1.0f, 1.0f, 1.0f), true);

                    // Draw the path with a small upward bias so that it does not clip into the surfaces
                    Vector3 bias = new Vector3(0.0f, 0.05f, 0.0f);
                    debug.AddLine(jackNode.Position + bias, currentPath[0] + bias, new Color(1.0f, 1.0f, 1.0f), true);

                    if (currentPath.Count > 1)
                    {
                        for (int i = 0; i < currentPath.Count - 1; ++i)
                            debug.AddLine(currentPath[i] + bias, currentPath[i + 1] + bias, new Color(1.0f, 1.0f, 1.0f), true);
                    }
                }
            });
        }
#pragma warning restore CS0618 // Type or member is obsolete

        protected override void OnUpdate(float timeStep)
        {
            base.OnUpdate(timeStep);
            MoveCamera(timeStep);
        }

        public static void AddAndDropSpheres()
        {
            //scene1.AddCharacterSpheresAgain(BrickScene);
            scene1.DropCharacterSpheres();
        }

        private void MoveCamera(float timeStep)
        {
            // Right mouse button controls mouse cursor visibility: hide when pressed
            UI.Cursor.Visible = !Input.GetMouseButtonDown(MouseButton.Right);

            // Do not move if the UI has a focused element (the console)
            if (UI.FocusElement != null)
                return;

            // Movement speed as world units per second
            const float moveSpeed = 20.0f;
            // Mouse sensitivity as degrees per pixel
            const float mouseSensitivity = 0.1f;

            // Use this frame's mouse motion to adjust camera node yaw and pitch. Clamp the pitch between -90 and 90 degrees
            // Only move the camera when the cursor is hidden
            if (!UI.Cursor.Visible)
            {
                IntVector2 mouseMove = Input.MouseMove;
                yaw += mouseSensitivity * mouseMove.X;

                pitch += mouseSensitivity * mouseMove.Y;
                pitch = MathHelper.Clamp(pitch, -90, 90);

                // Construct new orientation for the camera scene node from yaw and pitch. Roll is fixed to zero
                CameraNode.Rotation = new Quaternion(pitch, yaw, 0.0f);
            }

            // Read WASD keys and move the camera scene node to the corresponding direction if they are pressed
            if (Input.GetKeyDown(Key.W))
                CameraNode.Translate(Vector3.UnitZ * moveSpeed * timeStep);
            if (Input.GetKeyDown(Key.S))
                CameraNode.Translate(-Vector3.UnitZ * moveSpeed * timeStep);
            if (Input.GetKeyDown(Key.A))
                CameraNode.Translate(-Vector3.UnitX * moveSpeed * timeStep);
            if (Input.GetKeyDown(Key.D))
                CameraNode.Translate(Vector3.UnitX * moveSpeed * timeStep);
            if (Input.GetKeyDown(Key.R))
                CameraNode.Translate(Vector3.UnitY * moveSpeed * timeStep);
            if (Input.GetKeyDown(Key.F))
                CameraNode.Translate(-Vector3.UnitY * moveSpeed * timeStep);
        }

        private void SetupViewport()
        {
            var renderer = Renderer;
            renderer.SetViewport(0, new Viewport(Context, BrickScene, CameraNode.GetComponent<Camera>(), null));
        }

        private void CreateUI()
        {
            var cache = ResourceCache;

            // Create a Cursor UI element because we want to be able to hide and show it at will. When hidden, the mouse cursor will
            // control the camera, and when visible, it will point the raycast target
            XmlFile style = cache.GetXmlFile("UI/DefaultStyle.xml");
            Cursor cursor = new Cursor();
            cursor.SetStyleAuto(style);
            UI.Cursor = cursor;

            // Set starting position of the cursor at the rendering window center
            var graphics = Graphics;
            cursor.SetPosition(graphics.Width / 2, graphics.Height / 2);
        }

        public static void MoveCharacter(string direction)
        {
            var vector3 = scene1.PrimayCharacter.Location;

            Vector3 vector = new Vector3(vector3.X, vector3.Y, vector3.Z);

            if (vector.X % 5f == 0 && vector.Y % 5f == 0 && vector.Z % 5f == 0)
            {
                RotateBy rotate = null;
                RotateTo rotateTo = null;

                const float distance = 5;
                const float duration = distance / 5;

                switch (direction)
                {
                    case "L":
                        rotateTo = new RotateTo(duration: duration, deltaAngleX: 0, deltaAngleY: 0, deltaAngleZ: 90);
                        vector.X -= distance;
                        break;
                    case "R":
                        rotateTo = new RotateTo(duration: duration, deltaAngleX: 0, deltaAngleY: 0, deltaAngleZ: -90);
                        vector.X += distance;
                        break;
                    case "D":
                        rotate = new RotateBy(duration: duration, deltaAngleX: 0, deltaAngleY: -90, deltaAngleZ: 0);
                        vector.Y -= distance;
                        break;
                    case "U":
                        rotate = new RotateBy(duration: duration, deltaAngleX: 0, deltaAngleY: 90, deltaAngleZ: 0);
                        vector.Y += distance;
                        break;
                    case "B":
                        rotate = new RotateBy(duration: duration, deltaAngleX: 0, deltaAngleY: 0, deltaAngleZ: 0);
                        vector.Z -= distance;
                        break;
                    case "F":
                        rotate = new RotateBy(duration: duration, deltaAngleX: -90, deltaAngleY: 0, deltaAngleZ: 0);
                        vector.Z += distance;
                        break;
                    default:
                        rotate = new RotateBy(duration: duration, deltaAngleX: 90, deltaAngleY: 0, deltaAngleZ: 0);
                        break;
                }

                if (scene1.CheckBlockLocationIsEmpty(vector))
                {
                    var moveTo = new MoveTo(duration, vector);

                    var ease = GetRandomActionEase(moveTo);

                    scene1.PrimayCharacter.BlockNode.RunActions(ease);

                    //if (rotate == null)
                    //{
                    //    scene1.PrimayCharacter.BlockNode.RunActionsAsync(new Urho.Actions.Parallel(ease, rotateTo));
                    //}
                    //else
                    //{
                    //    scene1.PrimayCharacter.BlockNode.RunActionsAsync(new Urho.Actions.Parallel(ease, rotate));
                    //}
                }
            }
        }

        private static ActionEase GetRandomActionEase(MoveTo moveTo)
        {
            ActionEase ease;

            switch (Roll.d10)
            {
                case 1:
                    ease = new EaseBackInOut(moveTo);
                    break;
                case 2:
                    ease = new EaseBackIn(moveTo);
                    break;
                case 3:
                    ease = new EaseBackOut(moveTo);
                    break;
                case 4:
                    ease = new EaseBounceInOut(moveTo);
                    break;
                case 5:
                    ease = new EaseElasticInOut(moveTo);
                    break;
                case 6:
                    ease = new EaseElasticOut(moveTo);
                    break;
                case 7:
                    ease = new EaseExponentialIn(moveTo);
                    break;
                case 8:
                    ease = new EaseExponentialInOut(moveTo);
                    break;
                case 9:
                    ease = new EaseExponentialOut(moveTo);
                    break;
                case 10:
                    ease = new EaseInOut(moveTo, 5f);
                    break;
                default:
                    ease = new EaseBackInOut(moveTo);
                    break;
            }

            return ease;
        }

        private void CreateScene()
        {
            var cache = ResourceCache;

            BrickScene = new Scene();

            BrickScene.CreateComponent<Octree>();
            BrickScene.CreateComponent<DebugRenderer>();

            scene1 = new Scene1();
            scene1.CreateListOfBlocks(BrickScene);

            // Create a Zone component for ambient lighting & fog control
            var zoneNode = BrickScene.CreateChild("Zone");
            var zone = zoneNode.CreateComponent<Zone>();
            zone.SetBoundingBox(new BoundingBox(-1000.0f, 1000.0f));
            zone.AmbientColor = new Color(0.15f, 0.15f, 0.15f);
            zone.FogColor = new Color(0.5f, 0.5f, 0.7f);
            zone.FogStart = 100.0f;
            zone.FogEnd = 300.0f;

            // Create a directional light to the world. Enable cascaded shadows on it
            var lightNode = BrickScene.CreateChild("DirectionalLight");
            lightNode.SetDirection(new Vector3(0.6f, -1.0f, 0.8f));

            var light = lightNode.CreateComponent<Light>();
            light.LightType = LightType.Directional;
            light.CastShadows = true;
            light.ShadowBias = new BiasParameters(0.00025f, 0.5f);
            // Set cascade splits at 10, 50 and 200 world units, fade shadows out at 80% of maximum shadow distance
            light.ShadowCascade = new CascadeParameters(10.0f, 50.0f, 200.0f, 0.0f, 0.8f);

            // Create Jack node that will follow the path
            jackNode = BrickScene.CreateChild("Jack");
            jackNode.Position = new Vector3(15.0f, 15.0f, 20.0f);
            AnimatedModel modelObject = jackNode.CreateComponent<AnimatedModel>();
            //modelObject.Model = cache.GetModel("Models/Jack.mdl");
            modelObject.SetMaterial(cache.GetMaterial("Materials/Moon.xml"));
            modelObject.CastShadows = true;

            // Create a NavigationMesh component to the scene root
            NavigationMesh navMesh = BrickScene.CreateComponent<NavigationMesh>();
            // Create a Navigable component to the scene root. This tags all of the geometry in the scene as being part of the
            // navigation mesh. By default this is recursive, but the recursion could be turned off from Navigable
            BrickScene.CreateComponent<Navigable>();
            // Add padding to the navigation mesh in Y-direction so that we can add objects on top of the tallest boxes
            // in the scene and still update the mesh correctly
            navMesh.Padding = new Vector3(0.0f, 10.0f, 0.0f);

            // Create the camera. Limit far clip distance to match the fog
            CameraNode = BrickScene.CreateChild("Camera");
            Camera camera = CameraNode.CreateComponent<Camera>();
            camera.FarClip = 300.0f;

            // Set an initial position for the camera scene node above the plane
            CameraNode.Position = new Vector3(57.48847f, 60.82811f, -60.87394f); //
            CameraNode.Rotation = new Quaternion(29.3f, 1.1f, 0.0f);

            var n = BrickScene.CreateChild("gui");

            var b = new Urho.Gui.Button(); 
            //b.
            ///var b = new UrhoSharp.Gu
            ///
            var bnNode = BrickScene.CreateChild("button");
            var btn = new Button();
            btn.CreateButton("newBtn");
            btn.SetSize(500, 500);

           // bnNode.AddChild(btn);
        }

        public float NextRandom(float max)
        {
            int next = Random.Next(0, (int)max);

            return next; // > 5 ? max : next;
        }
    }   
}
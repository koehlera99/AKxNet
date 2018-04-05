﻿using System;
using System.Diagnostics;
using Urho;
using Urho.Actions;
using Urho.Gui;
using Urho.Shapes;

namespace UrhoSharp.Wpf
{
    class BattleGrid : Application
    {
        Node cameraNode;
        Node earthNode;
        Node rootNode;
        Scene scene;
        float yaw, pitch;

        [Preserve]
        public BattleGrid(ApplicationOptions options) : base(options) { }

        static BattleGrid()
        {
            UnhandledException += (s, e) =>
            {
                if (Debugger.IsAttached)
                    Debugger.Break();
                e.Handled = true;
            };
        }

        protected override async void Start()
        {
            base.Start();

            // 3D scene with Octree
            scene = new Scene(Context);
            scene.CreateComponent<Octree>();
            // Create a node for the Earth
            rootNode = scene.CreateChild();
            rootNode.Position = new Vector3(0, 0, 20);

            CreateGrid();

            // Clouds
            //var cloudsNode = box.CreateChild();
            //cloudsNode.SetScale(1.02f);
            //var clouds = cloudsNode.CreateComponent<Sphere>();
            //var cloudsMaterial = new Material();
            //cloudsMaterial.SetTexture(TextureUnit.Diffuse, ResourceCache.GetTexture2D("Textures/Earth_Clouds.jpg"));
            //cloudsMaterial.SetTechnique(0, CoreAssets.Techniques.DiffAddAlpha);
            //clouds.SetMaterial(cloudsMaterial);

            // Light
            Node lightNode = scene.CreateChild();
            var light = lightNode.CreateComponent<Light>();
            light.LightType = LightType.Directional;
            light.Range = 20;
            light.Brightness = 1f;
            lightNode.SetDirection(new Vector3(1f, -0.25f, 1.0f));

            // Camera
            cameraNode = scene.CreateChild();
            var camera = cameraNode.CreateComponent<Camera>();
            camera.Orthographic = true;
            camera.OrthoSize = 50f;
            camera.Fov = 20f;

            //camera.Position =  (new Vector3(1000f, 10f, 100f));

            // Viewport
            var viewport = new Viewport(Context, scene, camera, null);
            Renderer.SetViewport(0, viewport);
            //viewport.RenderPath.Append(CoreAssets.PostProcess.FXAA2);

            Input.Enabled = true;
            // FPS
            new MonoDebugHud(this).Show(Color.Green, 25);

            // Stars (Skybox)
            var skyboxNode = scene.CreateChild();
            var skybox = skyboxNode.CreateComponent<Skybox>();
            skybox.Model = CoreAssets.Models.Box;
            skybox.SetMaterial(Material.SkyboxFromImage("Textures/Space.png"));

            // Run a an action to spin the Earth (7 degrees per second)
            //rootNode.RunActions(); //new RepeatForever(new RotateBy(duration: 1f, deltaAngleX: 0, deltaAngleY: -2, deltaAngleZ: -7)));
            
            // Spin clouds:
            //cloudsNode.RunActions(new RepeatForever(new RotateBy(duration: 1f, deltaAngleX: 0, deltaAngleY: 1, deltaAngleZ: 0)));
            // Zoom effect:
            await rootNode.RunActionsAsync(new EaseOut(new MoveTo(2f, new Vector3(0, 0, 12)), 1));

            //AddCity(0, 0, "(0, 0)");
            //AddCity(53.9045f, 27.5615f, "Midgar");
            //AddCity(51.5074f, 0.1278f, "Windfall");
            //AddCity(40.7128f, -74.0059f, "Empire");
            //AddCity(37.7749f, -122.4194f, "Neverwinter");
            //AddCity(39.9042f, 116.4074f, "Waterdeep");
            //AddCity(-31.9505f, 115.8605f, "Afalor");
        }

        public void CreateGrid()
        {
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    CreateBox(x * 5, 0, y * 5);
                }
            }
        }

        public void CreateBox(float x, float y, float z)
        {

            Node box = rootNode.CreateChild();
            box.SetScale(5f);
            //box.Rotation = new Quaternion(25, 180, 145);
            box.Position = new Vector3(x, y, z);

            // Create a static model component - Sphere:
            var earth = box.CreateComponent<Box>();
            earth.SetMaterial(ResourceCache.GetMaterial("Materials/Earth.xml")); // or simply Material.FromImage("Textures/Earth.jpg")
        }

        public void AddCity(float lat, float lon, string name)
        {
            var height = earthNode.Scale.Y / 2f;

            lat = (float)Math.PI * lat / 180f - (float)Math.PI / 2f;
            lon = (float)Math.PI * lon / 180f;

            float x = height * (float)Math.Sin(lat) * (float)Math.Cos(lon);
            float z = height * (float)Math.Sin(lat) * (float)Math.Sin(lon);
            float y = height * (float)Math.Cos(lat);

            var markerNode = rootNode.CreateChild();
            markerNode.Scale = Vector3.One * 0.1f;
            markerNode.Position = new Vector3((float)x, (float)y, (float)z);
            markerNode.CreateComponent<Sphere>();
            markerNode.RunActionsAsync(new RepeatForever(
                new TintTo(0.5f, Color.White),
                new TintTo(0.5f, Randoms.NextColor())));

            var textPos = markerNode.Position;
            textPos.Normalize();

            var textNode = markerNode.CreateChild();
            textNode.Position = textPos * 2;
            textNode.SetScale(3f);
            textNode.LookAt(Vector3.Zero, Vector3.Up, TransformSpace.Parent);
            var text = textNode.CreateComponent<Text3D>();
            text.SetFont(CoreAssets.Fonts.AnonymousPro, 150);
            text.EffectColor = Color.Black;
            text.TextEffect = TextEffect.Shadow;
            text.Text = name;
        }

        protected override void OnUpdate(float timeStep)
        {
            MoveCameraByTouches(timeStep);
            SimpleMoveCamera3D(timeStep);
            base.OnUpdate(timeStep);
        }

        /// <summary>
        /// Move camera for 3D samples
        /// </summary>
        protected void SimpleMoveCamera3D(float timeStep, float moveSpeed = 10.0f)
        {
            if (!Input.GetMouseButtonDown(MouseButton.Left))
                return;

            const float mouseSensitivity = .1f;
            var mouseMove = Input.MouseMove;
            yaw += mouseSensitivity * mouseMove.X;
            pitch += mouseSensitivity * mouseMove.Y;
            pitch = MathHelper.Clamp(pitch, -90, 90);
            cameraNode.Rotation = new Quaternion(pitch, yaw, 0);
        }

        protected void MoveCameraByTouches(float timeStep)
        {
            const float touchSensitivity = 2f;

            var input = Input;
            for (uint i = 0, num = input.NumTouches; i < num; ++i)
            {
                TouchState state = input.GetTouch(i);
                if (state.Delta.X != 0 || state.Delta.Y != 0)
                {
                    var camera = cameraNode.GetComponent<Camera>();
                    if (camera == null)
                        return;

                    yaw += touchSensitivity * camera.Fov / Graphics.Height * state.Delta.X;
                    pitch += touchSensitivity * camera.Fov / Graphics.Height * state.Delta.Y;
                    cameraNode.Rotation = new Quaternion(pitch, yaw, 0);
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using HelixToolkit.Wpf;
using TCS.Net;

namespace TCS.FantasyBattle
{
    class BattleGrid
    {
        public static HelixViewport3D Battle3DViewPort { get; set; }
        public static ModelVisual3D UnitModel { get; set; } = new ModelVisual3D();

        static BattleGrid()
        {
            DrawCube();
        }

        public static void AddNewUnitSphere(ClientData client)
        {
            
            Random r = new Random();

            Players.UnitSpheres.Add(client.ClientID, new SphereVisual3D());
            Players.UnitSpheres.Last().Value.Center = new Point3D(r.Next(0, 20), r.Next(0, 20), 2);
            Players.UnitSpheres.Last().Value.Fill = Brushes.DarkOrange;
            Players.UnitSpheres.Last().Value.Radius = 0.5;
            Battle3DViewPort.Children.Add(Players.UnitSpheres.Last().Value);
        }

        public static void AddNewUnitSphere(UnitData unit)
        {

            Random r = new Random();

            Players.UnitSpheres.Add(unit.UnitID, new SphereVisual3D());
            Players.UnitSpheres.Last().Value.Center = new Point3D(r.Next(0, 20), r.Next(0, 20), 2);
            Players.UnitSpheres.Last().Value.Fill = Brushes.DarkOrange;
            Players.UnitSpheres.Last().Value.Radius = 0.5;
            Battle3DViewPort.Children.Add(Players.UnitSpheres.Last().Value);
        }

        public static void RemoveUnitSphere(UnitData unit)
        {
            if(Players.UnitSpheres.ContainsKey(unit.UnitID))
            {
                SphereVisual3D sphere = Players.UnitSpheres[unit.UnitID];
                Battle3DViewPort.Children.Remove(sphere);
            }
        }

        //[DebuggerStepThrough]
        public static void MoveUnitSphere(UnitData unit)
        {
            try
            {
                if(Players.UnitSpheres.Count > 0)
                    Players.UnitSpheres[unit.UnitID].Center = new Point3D(unit.Location.X, unit.Location.Y, unit.Location.Z);
                else
                {
                    Players.AddNew(unit.UnitID);
                    Players.UnitSpheres[unit.UnitID].Center = new Point3D(unit.Location.X, unit.Location.Y, unit.Location.Z);

                    if (Battle3DViewPort == null)
                        DrawCube();


                    Battle3DViewPort.Children.Add(Players.UnitSpheres.Last().Value);
                }
            }
            catch
            {
                Players.AddNew(unit.UnitID);
                Players.UnitSpheres[unit.UnitID].Center = new Point3D(unit.Location.X, unit.Location.Y, unit.Location.Z);

                if (Battle3DViewPort == null)
                    DrawCube();


                Battle3DViewPort.Children.Add(Players.UnitSpheres.Last().Value);
            }
        }

        private static void DrawCube()
        {
            if (Battle3DViewPort == null)
            {
                Battle3DViewPort =  Application.Current.FindResource("Battle3DViewPort") as HelixViewport3D;
            }
               
           // Battle3DViewPort = new HelixViewport3D();

            //var view = new HelixViewport3D();


            int roomSize = 20;
            var lights = new DefaultLights();

            LinearGradientBrush horGradBrushBlue = new LinearGradientBrush();
            horGradBrushBlue.StartPoint = new Point(0, 0.5);
            horGradBrushBlue.EndPoint = new Point(1, 0.5);
            horGradBrushBlue.GradientStops.Add(new GradientStop(Colors.RoyalBlue, 0.0));
            horGradBrushBlue.GradientStops.Add(new GradientStop(Colors.Blue, 0.4));

            LinearGradientBrush horGradBrushGreen = new LinearGradientBrush();
            horGradBrushGreen.StartPoint = new Point(0, 0.5);
            horGradBrushGreen.EndPoint = new Point(1, 0.5);
            horGradBrushGreen.GradientStops.Add(new GradientStop(Colors.Green, 0.5));
            horGradBrushGreen.GradientStops.Add(new GradientStop(Colors.ForestGreen, 1.0));

            RadialGradientBrush radGradBrush = new RadialGradientBrush();
            radGradBrush.GradientOrigin = new Point(0.75, 0.75);
            radGradBrush.Center = new Point(0.5, 0.5);
            radGradBrush.RadiusX = 0.5;
            radGradBrush.RadiusY = 0.5;
            radGradBrush.GradientStops.Add(new GradientStop(Colors.RoyalBlue, 0.0));
            radGradBrush.GradientStops.Add(new GradientStop(Colors.Blue, 0.4));

            radGradBrush.Freeze();
            horGradBrushBlue.Freeze();

            Rectangle myRectangle = new Rectangle();
            myRectangle.Width = 200;
            myRectangle.Height = 100;
            myRectangle.Fill = radGradBrush;

            CubeVisual3D cube = new CubeVisual3D();

            int x = 0;
            int y = 0;
            int z = 0;

            for (x = 0; x < roomSize; x++)
            {
                for (y = 0; y < roomSize; y++)
                {
                    for (z = 0; z < roomSize; z++)
                    {
                        if (z == 0)
                        {
                            cube = new CubeVisual3D();

                            cube.SideLength = 1;
                            cube.Center = new Point3D(x, y, z);
                            cube.Fill = horGradBrushGreen;



                            Battle3DViewPort.Children.Add(cube);
                        }
                        else if (z == 1 && x >= 5 && y >= 5)
                        {
                            cube = new CubeVisual3D();

                            cube.SideLength = 1;
                            cube.Center = new Point3D(x, y, z);
                            cube.Fill = horGradBrushGreen;

                            Battle3DViewPort.Children.Add(cube);
                        }
                        else if (z >= 2 && z <= 10 && x > 10 && y > 10 && x < roomSize - 5 && y < roomSize - 5)
                        {
                            cube = new CubeVisual3D();

                            cube.SideLength = 1;
                            cube.Center = new Point3D(x, y, z);
                            cube.Fill = horGradBrushBlue;

                            Battle3DViewPort.Children.Add(cube);
                        }
                    }
                }
            }

            GridLinesVisual3D grid2 = new GridLinesVisual3D();
            grid2.Center = new Point3D(12, 12, 1.52);
            grid2.Length = 15;
            grid2.Width = 15;
            grid2.MajorDistance = 5;
            grid2.MinorDistance = 1;
            grid2.Thickness = .02;
            grid2.Fill = Brushes.Black;


            Battle3DViewPort.Children.Add(grid2);

            GridLinesVisual3D grid = new GridLinesVisual3D();
            grid.Center = new Point3D(9.5, 9.5, .52);
            grid.Length = 20;
            grid.Width = 20;
            grid.MajorDistance = 5;
            grid.MinorDistance = 1;
            grid.Thickness = .02;
            grid.Fill = Brushes.Black;


            Battle3DViewPort.Children.Add(grid);

            foreach(KeyValuePair<Guid, SphereVisual3D> sphere in Players.UnitSpheres)
            {
                Battle3DViewPort.Children.Add(sphere.Value);
            }
            //foreach(SphereVisual3D sphere in Players.UnitSpheres)
            //{

            //}
            //    Players.UnitSpheres.Add(Guid.NewGuid(), new SphereVisual3D());


            //Players.UnitSpheres.Last().Value.Center = new Point3D(5, 5, 3);
            //Players.UnitSpheres.Last().Value.Fill = Brushes.DarkOrange;
            //Players.UnitSpheres.Last().Value.Radius = 0.5;
            //Battle3DViewPort.Children.Add(Players.UnitSpheres.Last().Value);

            //UnitModel.Content = Display3d("CuteDarkVador.STL");

            //var transGroup = new Transform3DGroup();
            //transGroup.Children.Add(new ScaleTransform3D(new Vector3D(.01, .01, .01)));
            //transGroup.Children.Add(new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 0, 0), 90)));
            //transGroup.Children.Add(new TranslateTransform3D(new Vector3D(5, 10, 2)));

            //UnitModel.Transform = transGroup;


            Battle3DViewPort.ZoomExtents();

            //view.Children.Add(cube);
            //BattleScreenCanvas.Children.Add(BattleViewPort);

        }

        /// <summary>
        /// Display 3D Model
        /// </summary>
        /// <param name="model">Path to the Model file</param>
        /// <returns>3D Model Content</returns>
        private static Model3D Display3d(string model)
        {
            Model3D device = null;
            try
            {
                //Adding a gesture here
                Battle3DViewPort.RotateGesture = new MouseGesture(MouseAction.LeftClick);

                //Import 3D model file
                ModelImporter import = new ModelImporter();

                //Load the 3D model file
                device = import.Load(model);
            }
            catch (Exception e)
            {
                // Handle exception in case can not find the 3D model file
                MessageBox.Show("Exception Error : " + e.StackTrace);
            }
            return device;
        }
    }
}

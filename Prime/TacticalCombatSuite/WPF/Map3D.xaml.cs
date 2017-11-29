using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace TCS.WPF
{
    /// <summary>
    /// Interaction logic for Map3D.xaml
    /// </summary>
    public partial class Map3D : Window
    {
        private System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        public Map3D()
        {
            InitializeComponent();

            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (slider1.Value == slider1.Maximum)
                slider1.Value = 0;
            else
                slider1.Value += 1;

            if (slider2.Value == 0)
                slider2.Value = slider2.Maximum;
            else
                slider2.Value -= 1;

            if (slider3.Value == 0)
                slider3.Value = slider3.Maximum;
            else
                slider3.Value -= 1;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //GeometryModel3D Cube1 = new GeometryModel3D();
            //MeshGeometry3D cubeMesh = CubeModel.MCube();
            //Cube1.Geometry = cubeMesh;

            //GradientStopCollection scol = new GradientStopCollection();
            //scol.Add(new GradientStop(Color.FromRgb(165, 32, 4), 0.0));
            //scol.Add(new GradientStop(Color.FromRgb(5, 23, 56), 100));
            //scol.Add(new GradientStop(Color.FromRgb(251, 45, 1), 200));


            //LinearGradientBrush rgb = new LinearGradientBrush(scol);
            //Cube1.Material = new DiffuseMaterial(rgb);
            //Cube1.Material = new EmissiveMaterial(new SolidColorBrush(Colors.Blue));

            ////Cube1.Material = new DiffuseMaterial(new SolidColorBrush(Colors.Red));

            //Model3DGroup modg = new Model3DGroup();
            //modg.Children.Add(Cube1);

            //ModelVisual3D modv = new ModelVisual3D();
            //modv.Content = modg;
            //MainViewport.Children.Add(modv);

            //Basic3DShapeExample();
            DrawCube();
        }

        public void DrawCube()
        {
            RectangleVisual3D myCube = new RectangleVisual3D();
            myCube.Origin = new Point3D(50, 50, 50); //Set this value to whatever you want your Cube Origen to be.
            myCube.Width = 50; //whatever width you would like.
            myCube.Length = 50; //Set Length = Width
            myCube.Normal = new Vector3D(0, 1, 0); // if you want a cube that is not at some angle then use a vector in the direction of an axis such as this one or <1,0,0> and <0,0,1>
            myCube.LengthDirection = new Vector3D(0, 1, 0); //This will depend on the orientation of the cube however since it is equilateral just set it to the same thing as normal.
            myCube.Material = new DiffuseMaterial(Brushes.Red); // Set this with whatever you want or just set the myCube.Fill Property with a brush type.

            var hVp3D = new HelixViewport3D();
            var lights = new DefaultLights();
            var teaPot = new Teapot();
            hVp3D.Children.Add(lights);
            //hVp3D.Children.Add(teaPot);
            hVp3D.Children.Add(myCube);
            this.Content = hVp3D;

            //this.AddChild(hVp3D);
        }


        public void Basic3DShapeExample()
        {

            // Declare scene objects.
            Viewport3D myViewport3D = new Viewport3D();
            Model3DGroup myModel3DGroup = new Model3DGroup();
            GeometryModel3D myGeometryModel = new GeometryModel3D();
            ModelVisual3D myModelVisual3D = new ModelVisual3D();
            // Defines the camera used to view the 3D object. In order to view the 3D object,
            // the camera must be positioned and pointed such that the object is within view 
            // of the camera.
            OrthographicCamera myPCamera = new OrthographicCamera();
            //PerspectiveCamera myPCamera = new PerspectiveCamera();

            // Specify where in the 3D scene the camera is.
            myPCamera.Position = new Point3D(0, 0, 2);

            // Specify the direction that the camera is pointing.
            myPCamera.LookDirection = new Vector3D(0, 0, -1);

            // Define camera's horizontal field of view in degrees.
            //myPCamera.FieldOfView = 60;

            // Asign the camera to the viewport
            myViewport3D.Camera = myPCamera;
            // Define the lights cast in the scene. Without light, the 3D object cannot 
            // be seen. Note: to illuminate an object from additional directions, create 
            // additional lights.
            DirectionalLight myDirectionalLight = new DirectionalLight();
            myDirectionalLight.Color = Colors.White;
            myDirectionalLight.Direction = new Vector3D(-0.61, -0.5, -0.61);

            myModel3DGroup.Children.Add(myDirectionalLight);

            // The geometry specifes the shape of the 3D plane. In this sample, a flat sheet 
            // is created.
            MeshGeometry3D myMeshGeometry3D = new MeshGeometry3D();

            // Create a collection of normal vectors for the MeshGeometry3D.
            Vector3DCollection myNormalCollection = new Vector3DCollection();
            myNormalCollection.Add(new Vector3D(0, 0, 1));
            myNormalCollection.Add(new Vector3D(0, 0, 1));
            myNormalCollection.Add(new Vector3D(0, 0, 1));
            myNormalCollection.Add(new Vector3D(0, 0, 1));
            myNormalCollection.Add(new Vector3D(0, 0, 1));
            myNormalCollection.Add(new Vector3D(0, 0, 1));
            myMeshGeometry3D.Normals = myNormalCollection;

            // Create a collection of vertex positions for the MeshGeometry3D. 
            Point3DCollection myPositionCollection = new Point3DCollection();
            myPositionCollection.Add(new Point3D(-0.5, -0.5, 0.5));
            myPositionCollection.Add(new Point3D(0.5, -0.5, 0.5));
            myPositionCollection.Add(new Point3D(0.5, 0.5, 0.5));
            myPositionCollection.Add(new Point3D(0.5, 0.5, 0.5));
            myPositionCollection.Add(new Point3D(-0.5, 0.5, 0.5));
            myPositionCollection.Add(new Point3D(-0.5, -0.5, 0.5));
            myMeshGeometry3D.Positions = myPositionCollection;

            // Create a collection of texture coordinates for the MeshGeometry3D.
            PointCollection myTextureCoordinatesCollection = new PointCollection();
            myTextureCoordinatesCollection.Add(new Point(0, 0));
            myTextureCoordinatesCollection.Add(new Point(1, 0));
            myTextureCoordinatesCollection.Add(new Point(1, 1));
            myTextureCoordinatesCollection.Add(new Point(1, 1));
            myTextureCoordinatesCollection.Add(new Point(0, 1));
            myTextureCoordinatesCollection.Add(new Point(0, 0));
            myMeshGeometry3D.TextureCoordinates = myTextureCoordinatesCollection;

            // Create a collection of triangle indices for the MeshGeometry3D.
            Int32Collection myTriangleIndicesCollection = new Int32Collection();
            myTriangleIndicesCollection.Add(0);
            myTriangleIndicesCollection.Add(1);
            myTriangleIndicesCollection.Add(2);
            myTriangleIndicesCollection.Add(3);
            myTriangleIndicesCollection.Add(4);
            myTriangleIndicesCollection.Add(5);
            myMeshGeometry3D.TriangleIndices = myTriangleIndicesCollection;

            // Apply the mesh to the geometry model.
            myGeometryModel.Geometry = myMeshGeometry3D;

            // The material specifies the material applied to the 3D object. In this sample a  
            // linear gradient covers the surface of the 3D object.

            // Create a horizontal linear gradient with four stops.   
            LinearGradientBrush myHorizontalGradient = new LinearGradientBrush();
            myHorizontalGradient.StartPoint = new Point(0, 0.5);
            myHorizontalGradient.EndPoint = new Point(1, 0.5);
            myHorizontalGradient.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
            myHorizontalGradient.GradientStops.Add(new GradientStop(Colors.Red, 0.25));
            myHorizontalGradient.GradientStops.Add(new GradientStop(Colors.Blue, 0.75));
            myHorizontalGradient.GradientStops.Add(new GradientStop(Colors.LimeGreen, 1.0));

            // Define material and apply to the mesh geometries.
            DiffuseMaterial myMaterial = new DiffuseMaterial(myHorizontalGradient);
            myGeometryModel.Material = myMaterial;

            // Apply a transform to the object. In this sample, a rotation transform is applied,  
            // rendering the 3D object rotated.
            RotateTransform3D myRotateTransform3D = new RotateTransform3D();
            AxisAngleRotation3D myAxisAngleRotation3d = new AxisAngleRotation3D();
            myAxisAngleRotation3d.Axis = new Vector3D(0, 3, 0);
            myAxisAngleRotation3d.Angle = 40;
            myRotateTransform3D.Rotation = myAxisAngleRotation3d;
            myGeometryModel.Transform = myRotateTransform3D;

            // Add the geometry model to the model group.
            myModel3DGroup.Children.Add(myGeometryModel);

            // Add the group of models to the ModelVisual3d.
            myModelVisual3D.Content = myModel3DGroup;

            // 
            myViewport3D.Children.Add(myModelVisual3D);

            // Apply the viewport to the page so it will be rendered.
            this.Content = myViewport3D;
        }
    }
}

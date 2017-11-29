using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Windows.Media;


namespace TCS.FantasyBattleh
{
    class CubeModel
    {
        public static MeshGeometry3D MCube()
        {
            MeshGeometry3D cube = new MeshGeometry3D();
            //First we need to create an array of points.In this case we need eight points corresponding to the eight corners of the cube:
            Point3DCollection corners =
                   new Point3DCollection();
            corners.Add(new Point3D(0.5, 0.5, 0.5));
            corners.Add(new Point3D(-0.5, 0.5, 0.5));
            corners.Add(new Point3D(-0.5, -0.5, 0.5));
            corners.Add(new Point3D(0.5, -0.5, 0.5));
            corners.Add(new Point3D(0.5, 0.5, -0.5));
            corners.Add(new Point3D(-0.5, 0.5, -0.5));
            corners.Add(new Point3D(-0.5, -0.5, -0.5));
            corners.Add(new Point3D(0.5, -0.5, -0.5));
            //Every mesh stores the array of points it uses in its Positions collection:
            cube.Positions = corners;

            Int32[] indices ={
            //front
                  0,1,2,
                  0,2,3,
            //back
                  4,7,6,
                  4,6,5,
            //Right
                  4,0,3,
                  4,3,7,
            //Left
                  1,5,6,
                  1,6,2,
            //Top
                  1,0,4,
                  1,4,5,
            //Bottom
                  2,6,7,
                  2,7,3
            };

            Int32Collection Triangles = new Int32Collection();

            foreach (Int32 index in indices)
            {
                Triangles.Add(index);
            }

            cube.TriangleIndices = Triangles;

            return cube;
        }
    }
}

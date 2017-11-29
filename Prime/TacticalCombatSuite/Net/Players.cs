using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;


namespace TCS.Net
{
    class Players
    {
        //public static List<Guid> PlayersOnline { get; set; } = new List<Guid>();

        
        public static ClientData Client { get; } =  new ClientData();

        public static Dictionary<Guid, SphereVisual3D> UnitSpheres = new Dictionary<Guid, SphereVisual3D>();

        static Players()
        {
            CreateNewClient();
        }

        private static void CreateNewClient()
        {
            Client.ClientID = Guid.NewGuid();
            Client.ClientName = "Client Name";
            Client.Units = new List<UnitData>();

            CreateNewUnit();
        }

        public static UnitData CreateNewUnit()
        {
            UnitData unit = new UnitData();
            unit.ClientID = Client.ClientID;
            unit.UnitID = Guid.NewGuid();
            unit.UnitName = "Unit Name";

            unit.Energy = 100;
            unit.HitPoints = 100;
            unit.Magic = 100;
            unit.Power = 100;

            unit.Location = new UnitLocation
            {
                X = 0,
                Y = 0,
                Z = 0
            };

            Client.Units.Add(unit);

            return unit;
        }


        public static void RemoveUnit(Guid guid)
        {
            UnitSpheres.Remove(guid);
        }

        public static void AddNew(Guid guid, SphereVisual3D sphere)
        {
            UnitSpheres.Add(guid, sphere);
        }

        public static void AddNew(Guid guid)
        {
            UnitSpheres.Add(guid, GetNewSphere());
        }

        /// <summary>
        /// Generate Random Sphere
        /// </summary>
        /// <returns></returns>
        public static SphereVisual3D GetNewSphere()
        {
            Random r = new Random();
            SphereVisual3D sphere = new SphereVisual3D();

            sphere.Center = new Point3D(r.Next(0, 20), r.Next(0, 20), 2);

            switch(r.Next(1, 10))
            {
                case 1:
                    sphere.Fill = Brushes.DarkOrange;
                    break;
                case 2:
                    sphere.Fill = Brushes.Aqua;
                    break;
                case 3:
                    sphere.Fill = Brushes.Bisque;
                    break;
                case 4:
                    sphere.Fill = Brushes.BlueViolet;
                    break;
                case 5:
                    sphere.Fill = Brushes.Coral;
                    break;
                case 6:
                    sphere.Fill = Brushes.DarkGreen;
                    break;
                case 7:
                    sphere.Fill = Brushes.DarkMagenta;
                    break;
                case 8:
                    sphere.Fill = Brushes.DarkTurquoise;
                    break;
                case 9:
                    sphere.Fill = Brushes.ForestGreen;
                    break;
                case 10:
                    sphere.Fill = Brushes.HotPink;
                    break;
                default:
                    sphere.Fill = Brushes.LightGreen;
                    break;

            }

            sphere.Radius = 0.5;

            return sphere;
        }
    }
}

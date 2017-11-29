using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TCS.FantasyBattle;

namespace TCS.WPF
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : Window
    {
        HwndSource WinSource;
        const int WM_EXITSIZEMOVE = 0x232;
        private bool sizeChanged = false;

        Room room = new Room(20, 20);
        Dictionary<Guid, UnitSection> ListOfUnitsInRoom { get; set; } = new Dictionary<Guid, UnitSection>();
        List<Guid> ActiveIDs { get; set; } = new List<Guid>();

        int activeID = 0;

        //List<UnitSection> UnitsInRoom { get; set; } = new List<UnitSection>();

        public Map()
        {
            InitializeComponent();
        }

        private void MainMap_Loaded(object sender, RoutedEventArgs e)
        {
            SetupRoom();
            InitializeGrid();
            AddNewUnitToRoom(7, 8);
            AddNewUnitToRoom();
            AddNewUnitToRoom(10, 8);
            //UnitsInRoom.Add(new UnitSection(room.Sections[7, 8]));
            ReDrawGrid();
            LoadWindowHandler();
        }

        private void MainMap_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            sizeChanged = true;
            //ReDrawGrid();   
        }

        #region Hwnd window handler
        private void LoadWindowHandler()
        {
            WinSource = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
            WinSource.AddHook(new HwndSourceHook(WndProc));
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_EXITSIZEMOVE && sizeChanged)
            {
                sizeChanged = false;
                ReDrawGrid();
            }
            return IntPtr.Zero;
        }
        #endregion

        private void AddNewUnitToRoom(UnitSection unitSection)
        {
            ListOfUnitsInRoom.Add(unitSection.ID, unitSection);
            ActiveIDs.Add(unitSection.ID);
        }

        private void AddNewUnitToRoom()
        {
            AddNewUnitToRoom(new UnitSection(room.Sections[10, 2]));
        }

        private void AddNewUnitToRoom(int x, int y)
        {
            AddNewUnitToRoom(new UnitSection(room.Sections[x, y]));
        }

        private void AddNewUnitToRoom(Point point)
        {
            AddNewUnitToRoom(new UnitSection(room.Sections[(int)point.X, (int)point.Y]));
        }

        /// <summary>
        /// Sets up the initiale room for the first time
        /// </summary>
        private void SetupRoom()
        {
            for(int x = 0; x < 5; x++)
            {
                for(int y = 0; y < 5; y++)
                {
                    room.Sections[x, y].IsNothing = true;
                }
            }

            for (int x = 15; x < 20; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    room.Sections[x, y].IsNothing = true;
                }
            }
        }

        private void MainMap_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        

        

        

        /// <summary>
        /// Initialize grid: Set default tiles, basic layout, ect.
        /// </summary>
        private void InitializeGrid()
        {
            foreach (RoomSection section in room.Sections)
            {
                section.Rect = new Rectangle
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = .75,
                    Width = CanvasMap.ActualWidth / room.Width,
                    Height = CanvasMap.ActualHeight / room.Height
                };

                if (section.IsNothing)
                    section.NormalBrush = Brushes.Black;
                else
                    section.NormalBrush = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/FantasyBattle/Icons/GreySlate.jpg", UriKind.Absolute))
                    };

                section.Rect.Fill = section.NormalBrush;
                section.Rect.MouseDown += CanvasMap_MouseDown;

                Canvas.SetLeft(section.Rect, section.Rect.Width * section.X);
                Canvas.SetTop(section.Rect, section.Rect.Height * section.Y);

                //section.Rect = rect;
                CanvasMap.Children.Add(section.Rect);
            }
        }


        /// <summary>
        /// Draws the grid for the map and adds tiles (Used only for resizing map or when adding new items/units to map)
        /// </summary>
        private void ReDrawGrid()
        {
            CanvasMap.Children.Clear();
            InitializeGrid();

            for (int x = 0; x < 20; x++)
            {
                for(int y = 0; y < 20; y++)
                {

                    //Rectangle rect;

                    if (room.Sections[x, y].SectionUnitIsIn == null)
                    {

                        room.Sections[x, y].Rect = new Rectangle
                        {
                            Stroke = Brushes.Black,
                            StrokeThickness = .75,
                            Width = CanvasMap.ActualWidth / room.Width,
                            Height = CanvasMap.ActualHeight / room.Height
                        };

                        if (room.Sections[x, y].IsNothing)
                            room.Sections[x, y].Rect.Fill = Brushes.Black;
                        else
                            room.Sections[x, y].Rect.Fill = new ImageBrush
                            {
                                ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/FantasyBattle/Icons/GreySlate.jpg", UriKind.Absolute))
                            };
                    }
                    else
                    {
                        room.Sections[x, y].Rect = new Rectangle
                        {
                            Stroke = Brushes.Black,
                            StrokeThickness = .75,
                            Width = CanvasMap.ActualWidth / room.Width,
                            Height = CanvasMap.ActualHeight / room.Height,
                            Fill = Brushes.Red
                        };
                    }

                    room.Sections[x, y].Rect.MouseDown += CanvasMap_MouseDown;

                    Canvas.SetLeft(room.Sections[x, y].Rect, room.Sections[x, y].Rect.Width * room.Sections[x, y].X);
                    Canvas.SetTop(room.Sections[x, y].Rect, room.Sections[x, y].Rect.Height * room.Sections[x, y].Y);

                    room.Sections[x, y].Rect.Tag = new Point(x, y);

                    CanvasMap.Children.Add(room.Sections[x, y].Rect);
                }
            }
        }



        //private void RectangleClicked()

        private void CanvasMap_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            Point tagPoint = (Point)rect.Tag;

            //TODO: Check for max move speed before moving unit
            //UnitsInRoom[0].MoveUnit(room.Sections[(int)tagPoint.X, (int)tagPoint.Y]);

            ListOfUnitsInRoom[ActiveIDs[activeID]].MoveUnit(room.Sections[(int)tagPoint.X, (int)tagPoint.Y]);

            activeID++;

            if (activeID >= ListOfUnitsInRoom.Count)
                activeID = 0;

            return;
        }

        //private bool mouseDown = false;
        //private void MainMap_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    mouseDown = true;
        //}

        //private void MainMap_MouseUp(object sender, MouseButtonEventArgs e)
        //{
        //    mouseDown = false;
        //}
    }
}


//Color new 
////Set old Section back to normal
//UnitsInRoom[0].CurrentSection.Rect.Fill = new ImageBrush
//{
//    ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/FantasyBattle/Icons/GreySlate.jpg", UriKind.Absolute))
//};

//Move unit

//ReDrawGrid();

//return;



//Point newPoint = rect.TransformToAncestor(this).Transform(new Point(0, 0));
//Point oldPoint = UnitsInRoom[0].CurrentSection.Rect.TransformToAncestor(this).Transform(new Point(0, 0));

//foreach (RoomSection section in room.Sections)
//{
//    if (section.Rect.Equals(sender))
//    {
//        int sdf = 0;
//    }

//}

////    if (sender.Equals(UnitsInRoom[0].CurrentSection.Rect))
////{
////    int p = 0;
////}

////if (rect.Equals(sender))
////{
////    int p = 0;
////}

//int X;
//int Y;

//if (newPoint.X > oldPoint.X)
//    X = 1;
//else if (newPoint.X == oldPoint.X)
//    X = 0;
//else
//    X = -1;

//if (newPoint.Y > oldPoint.Y)
//    Y = 1;
//else if (newPoint.Y == oldPoint.Y)
//    Y = 0;
//else
//    Y = -1;

////var point = e.GetPosition(this.CanvasMap);

////if (true)
////    return;

////UnitsInRoom[0].MoveUnit(room.Sections[(int)point.X, (int)point.Y]);

//double x = UnitsInRoom[0].CurrentSection.X;
//double y = UnitsInRoom[0].CurrentSection.Y;

////double newX = point.X;
////double newY = point.Y;

////if (newX > x)
////    x += 1;

//UnitsInRoom[0].MoveUnit(room.Sections[(int)x + X, (int)y + Y]);
//ReDrawGrid();

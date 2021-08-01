
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TeleMedic.Library
{
    /// <summary>
    /// Interaction logic for BingMap.xaml
    /// </summary>
    public partial class BingMap : UserControl
    {
        private GeoCoordinateWatcher _coordinateWatcher = null;
        public BingMap()
        {
            InitializeComponent();

            _coordinateWatcher = new GeoCoordinateWatcher();
            _coordinateWatcher.StatusChanged += _coordinateWatcher_StatusChanged;
            _coordinateWatcher.Start();
        }

        private void _coordinateWatcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            if (e.Status == GeoPositionStatus.Ready)
            {
                // Display the latitude and longitude.
                //if (!_coordinateWatcher.Position.Location.IsUnknown)
                //{
                //    var latitude = _coordinateWatcher.Position.Location.Latitude;
                //    var longitude = _coordinateWatcher.Position.Location.Longitude;
                //    myMap.Center = new Location(latitude, longitude);
                //    myMap.ZoomLevel = 17.0;
                //}
                //else
                //{
                //}
            }
        }

        void addNewPolyline()
        {
            MapPolyline polyline = new MapPolyline();
            polyline.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Blue);
            polyline.StrokeThickness = 5;
            polyline.Opacity = 0.7;
            polyline.Locations = new LocationCollection() {
        new Location(47.6424,-122.3219),
        new Location(47.8424,-122.1747),
        new Location(47.67856,-122.130994)};

            myMap.Children.Add(polyline);
        }

        public void PlaceDot(Location location, Color color)
        {
            Ellipse dot = new Ellipse();
            dot.Fill = new SolidColorBrush(color);
            double radius = 12.0;
            dot.Width = radius * 2;
            dot.Height = radius * 2;
            ToolTip tt = new ToolTip();
            tt.Content = "Location = " + location;
            dot.ToolTip = tt;
            Point p0 = myMap.LocationToViewportPoint(location);
            Point p1 = new Point(p0.X - radius, p0.Y - radius);
            Location loc = myMap.ViewportPointToLocation(p1);
            MapLayer.SetPosition(dot, loc);
            myMap.Children.Add(dot);
        }

        private void myMap_Loaded(object sender, RoutedEventArgs e)
        {
            myMap.Focus();
            if (!_coordinateWatcher.Position.Location.IsUnknown)
            {
                var latitude = _coordinateWatcher.Position.Location.Latitude;
                var longitude = _coordinateWatcher.Position.Location.Longitude;
                myMap.Center = new Location(latitude, longitude);
                myMap.ZoomLevel = 12;

                PlaceDot(myMap.Center, Color.FromRgb(255,0,0 ));
            }

        }


    }
}

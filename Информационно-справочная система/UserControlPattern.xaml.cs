using ClassLibrary;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Информационно_справочная_система
{
    /// <summary>
    /// Interaction logic for UserControlPattern.xaml
    /// </summary>
    public partial class UserControlPattern : UserControl
    {
        ToolTip objinfo = new ToolTip();

        public UserControlPattern() { }


        public UserControlPattern(FotoEquipment f)
        {
            InitializeComponent();
            this.label.Content = f.Company + " " + f.Model;

            
            BitmapImage b = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, f.Photo)));
            image.Source = b;



            // objinfo.
            objinfo.Content = f.Info();
            //string[] arr = new string[10] { f.ToString(), f.Price.ToString(), f.Weight.ToString(), f.Country, f.Company, f.Model, "", "", "", "" };
            //objinfo.Content += Search.Info(arr);

            //if (f.ToString() == "Camera")
            //{
            //    Camera c = (Camera)f;
            //    arr[7] = c.Pixels.ToString();
            //    arr[8] = c.Matrix.ToString();
            //    arr[9] = c.Formatvideo;
            //    objinfo.Content += Search.InfoCamera(arr);
            //}

            //if (f.ToString() == "Lens")
            //{
            //    Lens l = (Lens)f;
            //    arr[6] = l.Zoom;
            //    arr[7] = l.Aperture.ToString();
            //    objinfo.Content += Search.InfoLens(arr);
            //}

            //if (f.ToString() == "Flash")
            //{
            //    Flash fl = (Flash)f;
            //    arr[6] = fl.Guidenumber.ToString();
            //    arr[7] = fl.Rotationangle.ToString();
            //    objinfo.Content += Search.InfoFlash(arr);
            //}
            image.ToolTip = objinfo;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        public void IsertPic(string source)
        {
           
            ////    Image image = new Image();
            ////    image.Source = source;
            ////sp.Children.Add(image);
        }
        public void InsertName(string name)
        {
            label.Content = name;
        }

       

        private void canvas_MouseEnter(object sender, MouseEventArgs e)
        {

            objinfo.IsOpen = true;
        }
    }
}

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
    public partial class UserControlPattern : UserControl//шаблон для отображения объектов
    {
        ToolTip objinfo = new ToolTip();

        public UserControlPattern() { }


        public UserControlPattern(FotoEquipment f)
        {
            InitializeComponent();
            this.label.Content = f.Company + " " + f.Model;
            try
            {
                BitmapImage b = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, f.Photo)));
                image.Source = b;
            }
            catch { MessageBox.Show("Image does not exist"); }

            objinfo.Content = f.Info();
            image.ToolTip = objinfo;
            objinfo.Opacity = 30;
        }
    }
}

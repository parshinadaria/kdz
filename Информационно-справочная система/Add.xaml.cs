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
using System.Windows.Shapes;
using ClassLibrary;
using System.IO;
namespace Информационно_справочная_система
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        Repository r;
        public Add(Repository r)
        {this.r = r;
            InitializeComponent();
        }
        private FotoEquipment f;
        public FotoEquipment F
        {
            get
            {
                return f;
            }
            set
            {
                f = value;
            }
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string Line = textBox.Text;//combobox is editable false, camera lens and flashes, три вкладки а табконтроле: добавить жлемент и у каждого окна грид с полями
            FileStream fl = new FileStream("C:\\kdz\\equipment.txt", FileMode.Open, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fl);
            sw.WriteLine(Line);
            sw.Close();
            fl.Close();
            string[] fileInfo = Line.Split(new char[] { ' ' });
            FotoEquipment f = null;
            if (fileInfo[0] == "Camera")
            {
                f = new Camera(double.Parse(fileInfo[1]), int.Parse(fileInfo[2]), fileInfo[3], fileInfo[4], fileInfo[5], fileInfo[6], double.Parse(fileInfo[7]), double.Parse(fileInfo[8]), fileInfo[9]);
            }
            if (fileInfo[0] == "Lens")
            {
                f = new Lens(double.Parse(fileInfo[1]), int.Parse(fileInfo[2]), fileInfo[3], fileInfo[4], fileInfo[5], fileInfo[6], fileInfo[7], double.Parse(fileInfo[8]));
            }
            if (fileInfo[0] == "Flash")
            {
                f = new Flash(double.Parse(fileInfo[1]), int.Parse(fileInfo[2]), fileInfo[3], fileInfo[4], fileInfo[5], fileInfo[6], int.Parse(fileInfo[7]), int.Parse(fileInfo[8]));
            }
            DialogResult = true;

            r.ListFotoEquipment.Add(f);//to repository

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

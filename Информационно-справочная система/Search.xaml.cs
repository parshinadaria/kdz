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
using System.IO;
using ClassLibrary;
namespace Информационно_справочная_система
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        Repository r;
        public Search(Repository r)
        {
            this.r = r;
            InitializeComponent();
            foreach (var item in r.ListFotoEquipment)
            {
                comboboxSear.Items.Add(item.Company + " " + item.Model);
            }
        }
        private List<string> answer;
        public List<string> Answer
        {
            get
            {
                return answer;
            }
            set
            {
                answer = value;
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            answer = new List<string>();
            string filename = "../../equipment.txt";
            FileStream fl = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fl);
            bool ok = false;
            while (!sr.EndOfStream)
            {
                string line  = sr.ReadLine();
                string[] arr = line.Split();
                if (arr[4]+" "+arr[5]==comboboxSear.Text)
                {
                    string str = Info(arr);
                    if (arr[0] == "Camera") str += InfoCamera(arr);
                    if (arr[0] == "Flash") str += InfoFlash(arr);
                    if (arr[0] == "Lens") str += InfoLens(arr);
                    answer.Add(str);
                    ok = true;
                }
            }
            string add = "not founded";
            if (ok==false)
            {
                answer.Add(add);
            }
            sr.Close();
            fl.Close();
            DialogResult = true;
        }

        public  static string Info(string[] arr)
        {
            return $"   {arr[0]}\r{arr[4]} {arr[5]}\rCountry: {arr[3]}\rPrice: {arr[1]} RUB\rWeight: {arr[2]} g\r";
        }

        public static string InfoCamera (string[] arr)
        {
            return $"Pixels: {arr[6]} mln\rMatrix: {arr[7]} crop factor\rVideo Format: {arr[8]}";
        }

        public static string InfoLens(string[] arr)
        {
            return $"Zoom: x{arr[6]}\rAperture: {arr[7]}";
        }

        public static string InfoFlash(string[] arr)
        {
            return $"Guide number: {arr[6]} \rRotation angle: {arr[7]}°";
        }
    }
}

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
    /// Interaction logic for Delete.xaml
    /// </summary>
    public partial class Delete : Window
    {
        Repository r;
        public Delete(Repository r)
        {
            this.r = r;
            InitializeComponent();
            foreach (var item in r.ListFotoEquipment)
            {
                comboboxDel.Items.Add(item.Company + " " + item.Model);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            //string filename = "../";
            //FileStream fl = new FileStream(filename, FileMode.Open, FileAccess.Read);
            //StreamReader sr = new StreamReader(fl);
            //List<string> lines = new List<string>();
            //while (!sr.EndOfStream)
            //{
            //    string line = sr.ReadLine();
            //    if (line !=  textBox.Text)
            //    {
            //        lines.Add(line);
            //    }
            //}
            //sr.Close();
            //fl.Close();
            //File.Delete("C:\\kdz\\equipment.txt");
            //FileStream fl1 = new FileStream("C:\\kdz\\equipment.txt", FileMode.Create, FileAccess.Write);
            //StreamWriter sw = new StreamWriter(fl1);
            try
            {
                if (comboboxDel.Text != "")
                {
                    FotoEquipment f = r.ListFotoEquipment.FirstOrDefault(e1 => (e1.Company + " " + e1.Model) == comboboxDel.Text);
                    if (f == null)
                    {
                        throw new ArgumentException("Данный элемент не найден");
                    }
                    else
                    {
                        r.ListFotoEquipment.Remove(f);
                    }
                }
            }
            catch (ArgumentException e2)
            {

                MessageBox.Show(e2.Message);
            }
           
        }

        private void CancelDelete_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

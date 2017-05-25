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
        public Delete(Repository r)//удаление объекта из репозитория по введенным данным о марке и модели
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
            try
            {
                if (comboboxDel.Text != "")
                {
                    FotoEquipment f = r.ListFotoEquipment.FirstOrDefault(e1 => (e1.Company + " " + e1.Model) == comboboxDel.Text);
                    if (f == null)
                    {
                        throw new ArgumentException("The item was not found");
                    }
                    else
                    {
                        r.ListFotoEquipment.Remove(f);
                        MainWindow.story += $"Deleted: {f.ToString()} {f.Company} {f.Model}\r";
                    }
                }
                else { MessageBox.Show("Please, choose an item"); }
            }
            catch (ArgumentException e2)
            {

                MessageBox.Show(e2.Message);
            }
            this.Close();
        }

        private void CancelDelete_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

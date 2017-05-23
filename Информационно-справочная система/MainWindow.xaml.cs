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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        Repository r; 
        public MainWindow()
        {
           
            r = new Repository();
            InitializeComponent();
           
        }

        private void ButtonCamera(object sender, RoutedEventArgs e)
        {
            
            contentControl.Content = new UserControlItems(r.ListFotoEquipment.Where(ee => ee is Camera).ToList());
        }

        private void ButtonLens(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new UserControlItems(r.ListFotoEquipment.Where(ee => ee is Lens).ToList());
        }

        private void ButtonFlash(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new UserControlItems(r.ListFotoEquipment.Where(ee => ee is Flash).ToList());
        }

        private void ButtonSearch(object sender, RoutedEventArgs e)
        {
            Search search = new Search(r);
            search.ShowDialog();
            if (search.DialogResult==true)
            {
                listBoxInfo.Items.Clear();
                    for (int i=0; i<search.Answer.Count; i++)
                    {
                        listBoxInfo.Items.Add(search.Answer[i]);
                    }
            }
        }

        private void ButtonDelete(object sender, RoutedEventArgs e)
        {
            Delete del = new Delete(r);
            del.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            del.ShowDialog();
            if (del.DialogResult == true)
            {
                listBoxInfo.Items.Clear();
                listBoxInfo.Items.Add("New item has been deleted successfully");
            }
        }

        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            Add add = new Add(r);
            add.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            add.Show();
            if (add.DialogResult == true)
            {
                listBoxInfo.Items.Clear();
                listBoxInfo.Items.Add("New item has been added successfully");
            }
        }
    }
}

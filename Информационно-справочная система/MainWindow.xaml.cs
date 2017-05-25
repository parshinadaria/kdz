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
using Microsoft.Win32;

namespace Информационно_справочная_система
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public static bool isCamera = true;
        public static bool isLens = false;
        public static bool isFlash = false;
        public static string story;
        Repository r = new Repository();
        private bool admin;
        public MainWindow(bool admin)
        {

            InitializeComponent();
            this.admin = admin;
            if (admin == false)
            {
                Add.IsEnabled = false;
                Delete.IsEnabled = false;
                Add.Visibility = Visibility.Collapsed;
                Delete.Visibility = Visibility.Collapsed;
            }
            contentControl.Content = new UserControlItems(r.ListFotoEquipment.Where(ee => ee is Camera).ToList());
        }

        private void ButtonCamera(object sender, RoutedEventArgs e)
        {

            contentControl.Content = new UserControlItems(r.ListFotoEquipment.Where(ee => ee is Camera).ToList());
            isCamera = true; isLens = false; isFlash = false;
        }

        private void ButtonLens(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new UserControlItems(r.ListFotoEquipment.Where(ee => ee is Lens).ToList());
            isCamera = false; isLens = true; isFlash = false;
        }

        private void ButtonFlash(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new UserControlItems(r.ListFotoEquipment.Where(ee => ee is Flash).ToList());
            isCamera = false; isLens = false; isFlash = true;
        }

        private void ButtonSearch(object sender, RoutedEventArgs e)
        {
            Search search = new Search(r);
            search.ShowDialog();
            if (search.DialogResult == true)
            {
                listBoxInfo.Items.Clear();
                for (int i = 0; i < search.Answer.Count; i++)
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
                listBoxInfo.Items.Add("Item has been deleted successfully");
            }
            if (isCamera == true) { contentControl.Content = new UserControlItems(r.ListFotoEquipment.Where(ee => ee is Camera).ToList()); }
            if (isLens == true) { contentControl.Content = new UserControlItems(r.ListFotoEquipment.Where(ee => ee is Lens).ToList()); }
            if (isFlash == true) { contentControl.Content = new UserControlItems(r.ListFotoEquipment.Where(ee => ee is Flash).ToList()); }
        }

        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            Add del = new Add(r);
            del.ShowDialog();
            if (del.DialogResult == true)
            {
                listBoxInfo.Items.Clear();
                listBoxInfo.Items.Add("Item has been added successfully");
            }
            
            contentControl.Content = new UserControlItems(r.ListFotoEquipment.Where(ee => ee is Camera).ToList());
            contentControl.Content = new UserControlItems(r.ListFotoEquipment.Where(ee => ee is Lens).ToList());
            contentControl.Content = new UserControlItems(r.ListFotoEquipment.Where(ee => ee is Flash).ToList());
        }

        private void serialize_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            Nullable<bool> result = save.ShowDialog();
            string filepath;
            if (result == true)
            {
                filepath = save.FileName;
                r.Serialize(r.ListFotoEquipment, filepath);
                MessageBox.Show("objects were saved successfully");
            }

        }

        private void deserialize_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            Nullable<bool> result = open.ShowDialog();
            string filepath;
            if (result == true)
            {
                filepath = open.FileName;
                r.Deserialize(filepath);
                MessageBox.Show("objects were uploaded successfully");
            }
        }

        private void buttonLogOut_Click(object sender, RoutedEventArgs e)
        {
            WindowAuth auth = new WindowAuth();
            auth.Show();
            this.Close();
        }

        private void history_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(story);
        }
    }
}
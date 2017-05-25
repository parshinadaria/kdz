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
    /// Interaction logic for AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public static string[] arr;
        Add add;
        public AddPage() : this(null) { }
        public AddPage(Add ad)
        {
            InitializeComponent();
            this.add = ad;
            string[] a = { "Camera", "Lens", "Flash" };
            foreach (string s in a )
            item.Items.Add(s);
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {

            TextBox[] ind = { pricetext, weighttext, countrytext, companytext, modeltext, phototext};
            arr = new string[10];
            arr[0] = item.Text;
            for (int i = 1; i < 7; i++)
            {
                arr[i] = ind[i-1].Text;
            }
            AddDetailsPage adddetailpage = new AddDetailsPage(add);

            NavigationService.Navigate(adddetailpage);
            
        }
    }
}


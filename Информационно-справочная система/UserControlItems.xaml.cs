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
using ClassLibrary;

namespace Информационно_справочная_система
{
    /// <summary>
    /// Interaction logic for UserControlItems.xaml
    /// </summary>
    public partial class UserControlItems : UserControl
    {
        List<FotoEquipment> list;
        public UserControlItems(List<FotoEquipment> list)
        {
            this.list = list;
            InitializeComponent();
            for (int i = 0; i < list.Count; i++)
            {
                UserControlPattern u = new UserControlPattern(list[i]);
                u.Height = 250;
                if (i%3==0)
                {
                    StackPanel1.Children.Add(u);
                }

                if (i % 3 == 1)
                {
                    StackPanel2.Children.Add(u);
                }

                if (i % 3 == 2)
                {
                    StackPanel3.Children.Add(u);
                }

            }
        }
    }
}

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
    /// Interaction logic for WindowAuth.xaml
    /// </summary>
    public partial class WindowAuth : Window
    {
        public WindowAuth()
        {
            InitializeComponent();
        }

        private void ButtonSignInClick(object sender, RoutedEventArgs e)
        {
            Check_Auth c = new Check_Auth();
            if (!string.IsNullOrEmpty(textBoxLogin.Text))
            {
                string response = c.checkAuth(textBoxLogin.Text, textBoxPassword.Text);
                if (!response.Equals("OK"))
                {
                    MessageBox.Show(response);
                }
                else
                {
                    try
                    {
                        MainWindow M = new MainWindow();
                        M.Show();
                        this.Close();
                    }
                    catch (FormatException)
                    {

                        MessageBox.Show("incorrect format");
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("file was not found");
                    }

                }
            }


        }
    }
}

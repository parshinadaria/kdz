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
            textBoxLogin.Focus();
        }

        private void ButtonSignInClick(object sender, RoutedEventArgs e)
        {

            try
            {

                Check_Auth c = new Check_Auth();
                if (!string.IsNullOrEmpty(textBoxLogin.Text))
                {
                    MainWindow M;
                    string response = c.checkAuth(textBoxLogin.Text, passwordBox.Password);
                    if (response == "admin")
                    {
                        M = new MainWindow(true);
                    }
                    else
                    {
                        M = new MainWindow(false);
                    }
                    M.Show();
                    Close();
                }
            }
            catch (FormatException)
            {

                MessageBox.Show("incorrect format");
            }
            catch (IOException)
            {
                MessageBox.Show("file was not found");
            }
            catch (ArgumentException e1)
            {
                MessageBox.Show(e1.Message);
            }

        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (e.Key == Key.Enter)
                    ButtonSignInClick(null, null);
            }
        }
    }


}



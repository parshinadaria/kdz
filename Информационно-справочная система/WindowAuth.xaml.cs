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
            //string login = textBoxLogin.Text;
            //string password = passwordBox.Password;
            //if (login == "guest")
            //{
            //    if (password == "1234")
            //    {
            //        MainWindow M = new MainWindow(false);
            //        M.Show();
            //        this.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Wrong password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //}
            //else if (login == "admin")
            //{
            //    if (password == "12345")
            //    {
            //        MainWindow M = new MainWindow(true);
            //        M.Show();
            //        this.Close();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Wrong login");
            //}


            Check_Auth c = new Check_Auth();
            if (!string.IsNullOrEmpty(textBoxLogin.Text))
            {
                string response = c.checkAuth(textBoxLogin.Text, passwordBox.Password);
                if (!response.Equals("OK"))
                {
                    MessageBox.Show(response);
                }
                else
                {
                    try
                    {
                        if (textBoxLogin.Text == "guest")
                        {
                            if (passwordBox.Password == "1234")
                            {
                                MainWindow M = new MainWindow(false);
                                M.Show();
                                this.Close();
                            }
                            //else
                            //{
                            //    MessageBox.Show("Wrong password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            //}
                        }
                        else if (textBoxLogin.Text == "admin")
                        {
                            if (passwordBox.Password == "12345")
                            {
                                MainWindow M = new MainWindow(true);
                                M.Show();
                                this.Close();
                            }
                        }
                        //else
                        //{
                        //    MessageBox.Show("Wrong login");
                        //}

                        //MainWindow M = new MainWindow();
                        // M.Show();
                        //this.Close();
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

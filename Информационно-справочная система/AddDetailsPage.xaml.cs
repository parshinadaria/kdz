﻿using System;
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
    /// Interaction logic for AddDetailsPage.xaml
    /// </summary>
    public partial class AddDetailsPage : Page//страница добавления более детальной информации
    {
        Repository r= MainWindow.r;

        public static string type = AddPage.arr[0];

        public void VisibilityCamera()//метод для скрытия полей, не актуальных данному элементу
        {
            zoom.Visibility = Visibility.Collapsed;
            zoomtext.IsEnabled = false;
            zoomtext.Visibility = Visibility.Collapsed;
            aperture.Visibility = Visibility.Collapsed;
            aperturetext.IsEnabled = false;
            aperturetext.Visibility = Visibility.Collapsed;
            guidenumber.Visibility = Visibility.Collapsed;
            guidenumbertext.IsEnabled = false;
            guidenumbertext.Visibility = Visibility.Collapsed;
            rotationangle.Visibility = Visibility.Collapsed;
            rotationangletext.IsEnabled = false;
            rotationangletext.Visibility = Visibility.Collapsed;
        }

        public void VisibilityLens()//метод для скрытия полей, не актуальных данному элементу
        {
            pixels.Visibility = Visibility.Collapsed;
            pixelstext.IsEnabled = false;
            pixelstext.Visibility = Visibility.Collapsed;
            matrix.Visibility = Visibility.Collapsed;
            matrixtext.IsEnabled = false;
            matrixtext.Visibility = Visibility.Collapsed;
            video.Visibility = Visibility.Collapsed;
            videotext.IsEnabled = false;
            videotext.Visibility = Visibility.Collapsed;
            guidenumber.Visibility = Visibility.Collapsed;
            guidenumbertext.IsEnabled = false;
            guidenumbertext.Visibility = Visibility.Collapsed;
            rotationangle.Visibility = Visibility.Collapsed;
            rotationangletext.IsEnabled = false;
            rotationangletext.Visibility = Visibility.Collapsed;
        }

        public void VisibilityFlash()//метод для скрытия полей, не актуальных данному элементу
        {
            pixels.Visibility = Visibility.Collapsed;
            pixelstext.IsEnabled = false;
            pixelstext.Visibility = Visibility.Collapsed;
            matrix.Visibility = Visibility.Collapsed;
            matrixtext.IsEnabled = false;
            matrixtext.Visibility = Visibility.Collapsed;
            video.Visibility = Visibility.Collapsed;
            videotext.IsEnabled = false;
            videotext.Visibility = Visibility.Collapsed;
            zoom.Visibility = Visibility.Collapsed;
            zoomtext.IsEnabled = false;
            zoomtext.Visibility = Visibility.Collapsed;
            aperture.Visibility = Visibility.Collapsed;
            aperturetext.IsEnabled = false;
            aperturetext.Visibility = Visibility.Collapsed;
        }
        Add add;
        public AddDetailsPage() : this(null) { }
        public AddDetailsPage(Add ad)
        {
            InitializeComponent();
            add = ad;
            if (type == "Camera") VisibilityCamera();
            if (type == "Lens") VisibilityLens();
            if (type == "Flash") VisibilityFlash();
        }

        private void create_Click(object sender, RoutedEventArgs e)//считывание полей 
        {
            if (type == "Camera")
            {
                TextBox[] ind = { pixelstext, matrixtext, videotext };
                for (int i = 0; i < 3; i++)
                    AddPage.arr[i + 7] = ind[i].Text;
            }

            if (type == "Lens")
            {
                TextBox[] ind = { zoomtext, aperturetext };
                for (int i = 0; i < 2; i++)
                    AddPage.arr[i + 7] = ind[i].Text;
            }

            if (type == "Flash")
            {
                TextBox[] ind = { guidenumbertext, rotationangletext };
                for (int i = 0; i < 2; i++)
                    AddPage.arr[i + 7] = ind[i].Text;
            }

            try
            {
                Create();
            }
            catch { MessageBox.Show("The format of one(or more) of the fields is incorrect.\rPlease, try again using the help button to see the example"); }//сообщение при некорректном вводе
           
            
        }


        public FotoEquipment f;

        public void Create()// формирование нового объекта
        {
            if (type == "Camera")
            {
                f = new Camera(double.Parse(AddPage.arr[1]), int.Parse(AddPage.arr[2]), AddPage.arr[3], AddPage.arr[4], AddPage.arr[5], AddPage.arr[6], double.Parse(AddPage.arr[7]), double.Parse(AddPage.arr[8]), AddPage.arr[9]);
            }
            if (type == "Lens")
            {
                f = new Lens(double.Parse(AddPage.arr[1]), int.Parse(AddPage.arr[2]), AddPage.arr[3], AddPage.arr[4], AddPage.arr[5], AddPage.arr[6], AddPage.arr[7], double.Parse(AddPage.arr[8]));
            }
            if (type == "Flash")
            {
                f = new Flash(double.Parse(AddPage.arr[1]), int.Parse(AddPage.arr[2]), AddPage.arr[3], AddPage.arr[4], AddPage.arr[5], AddPage.arr[6], int.Parse(AddPage.arr[7]), int.Parse(AddPage.arr[8]));
            }

            r.ListFotoEquipment.Add(f);
            MainWindow.story+= $"Added: {f.ToString()} {f.Company} {f.Model}\r";
            add.Close();
        }

        private void help1_Click(object sender, RoutedEventArgs e)
        {
            string example = "   CameraSample:\rPixels: 17.2\rCrop factor: 1.6\rVideo format: MOV\r   LensSample:\rZoom: 18-200\rAperture: 3.5\r   FlashSample:\rGuide number: 22\rRotation angle: 90";
            MessageBox.Show(example);
        }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class Camera:FotoEquipment
    {
        private double pixels;

        public double Pixels
        {
            get { return pixels; }
        }

        private string matrix;

        public string Matrix
        {
            get { return matrix; }
        }
        private string  formatphoto;

        public string  Formatphoto
        {
            get { return formatphoto; }
        }

        private string formatvideo;

        public string Formatvideo
        {
            get { return formatvideo; }
        }

        private int speed;

        public int Speed
        {
            get { return speed; }
        }


        public Camera(double Price, double Weight, string Country, string Company, string Model, double Pixels,string Matrix, string Formatphoto, string Formatvideo, int speed):base(Price,Weight,Country,Company,Model)
        {
            pixels = Pixels;
            matrix = Matrix;
            formatphoto = Formatphoto;
            formatvideo = Formatvideo;
            speed = Speed;
        }
    }
}

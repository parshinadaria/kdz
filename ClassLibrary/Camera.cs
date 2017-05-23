using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Camera:FotoEquipment
    {
        private double pixels;

        public double Pixels//mln
        {
            get { return pixels; }
        }

        private double matrix;

        public double Matrix
        {
            get { return matrix; }
        }
 
        private string formatvideo;

        public string Formatvideo
        {
            get { return formatvideo; }
        }

        public Camera(double Price, int Weight, string Country, string Company, string Model, string Photo, double Pixels,double Matrix, string Formatvideo):base(Price,Weight,Country,Company,Model, Photo)
        {
            pixels = Pixels;
            matrix = Matrix;
            formatvideo = Formatvideo;
        }

        public override string Info()
        {
            return base.Info() + $"Pixels: {Pixels} mln\rMatrix: {Matrix} crop factor\rVideo Format: {Formatvideo}";
        }

        public override string ToString()
        {
            return "Camera";
        }
    }
}

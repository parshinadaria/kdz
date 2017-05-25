using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Lens: FotoEquipment//дочерний класс, содержит специфический характеристики объективов
    {
        private string zoom;

        public string Zoom
        {
            get { return zoom; }
        }

        private double aperture;

        public double Aperture
        {
            get { return aperture; }
        }

        public Lens(double Price, int Weight, string Country, string Company, string Model, string Photo, string Zoom, double Aperture) : base(Price, Weight, Country, Company, Model, Photo)
        {
            zoom = Zoom;
            aperture = Aperture;
        }

        public override string Info()//переопределение информации об объекте
        {
            return base.Info() + $"Zoom: x{zoom}\rAperture: {aperture}";
        }

        public override string ToString()
        {
            return "Lens";
        }


    }
}

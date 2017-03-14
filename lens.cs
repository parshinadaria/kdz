using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class lens:FotoEquipment
    {
        private double minFocus;

        public double MinFocus
        {
            get { return minFocus; }
        }

        private double maxZoom;

        public double MaxZoom
        {
            get { return maxZoom; }
        }

        private int diameter;

        public int Diameter
        {
            get { return diameter; }
        }

        private double minAperture;

        public double MinAperture
        {
            get { return minAperture; }
        }

        public lens(double Price, double Weight, string Country, string Company, string Model, double MinFocus, double MaxZoom, int Diameter, double MinAperture):base(Price, Weight, Country, Company, Model)
        {
            minFocus = MinFocus;
            maxZoom = MaxZoom;
            diameter = Diameter;
            minAperture = MinAperture;
        }



    }
}

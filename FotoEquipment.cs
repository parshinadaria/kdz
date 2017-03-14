using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    abstract class FotoEquipment
    {
        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }


        private double weight;

        public double Weight
        {
            get { return weight; }
        }

        private string country;

        public string Country
        {
            get { return country; }
        }

        private string company;

        public string Company
        {
            get { return company; }
        }

        private string model;

        public string Model
        {
            get { return model; }
        }

        public FotoEquipment(double Price, double Weight, string Country, string Company, string Model)
        {
            price = Price;
            weight = Weight;
            country = Country;
            company = Company;
            model = Model;
        }
    }
}

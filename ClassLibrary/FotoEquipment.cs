using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace ClassLibrary
{
    public abstract class FotoEquipment
    {
        private string photo;

        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }

        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }


        private int weight;

        public int Weight
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
        
        public virtual string Info()
        {
            return $"   {ToString()}\r{Company} {Model}\rCountry: {Country}\rPrice: {Price} RUB\rWeight: {Weight} g\r";
        }

        public FotoEquipment(double Price, int Weight, string Country, string Company, string Model, string Photo)
        {
            photo = Photo;
            price = Price;
            weight = Weight;
            country = Country;
            company = Company;
            model = Model;
        }
    }
}

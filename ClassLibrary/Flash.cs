using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Flash: FotoEquipment//дочерний класс, содержит специфический характеристики вспышек
    {
        private int guidenumber;

        public int Guidenumber
        {
            get { return guidenumber; }
        }

        private int rotationangle;

        public int Rotationangle
        {
            get { return rotationangle; }
        }

        public Flash(double Price, int Weight, string Country, string Company, string Model, string Photo, int Guidenumber, int Rotationangle) : base(Price, Weight, Country, Company, Model, Photo)
        {
            guidenumber = Guidenumber;
            rotationangle = Rotationangle;
        }

        public override string Info()//переопределение информации об объекте
        {
            return base.Info() + $"Guide number: {guidenumber} \rRotation angle: {guidenumber}°";
        }

        public override string ToString()
        {
            return "Flash";
        }
    }
}

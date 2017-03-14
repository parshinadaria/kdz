using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class Flash:FotoEquipment
    {
        private char diffuser;

        public char Diffuser
        {
            get { return diffuser; }
        }

        private double rechargeTime;

        public double RechargeTime
        {
            get { return rechargeTime; }
        }

        private int leadingNumber;

        public int LeadingNumber
        {
            get { return leadingNumber; }
        }

        public Flash(double Price, double Weight, string Country, string Company, string Model, char Diffuser, double RechargeTime, int LeadingNumber) : base(Price, Weight, Country, Company, Model)
        {
            diffuser = Diffuser;
            rechargeTime = RechargeTime;
            leadingNumber = LeadingNumber;

        }



    }
}

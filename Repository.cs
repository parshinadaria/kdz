using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary
{
    class Repository
    {
        List<FotoEquipment> ListFotoEquipment;
        public void ReadFromFile(string filename)
        {
            string Line = "";
            StreamReader sr = new StreamReader(filename);
            while ((Line=sr.ReadLine())!= null)
            {
                string[] fileInfo = Line.Split(new char[] { ' ' });
                FotoEquipment f;
                if (fileInfo[0] == "Camera")
                {
                    f = new Camera(double.Parse(fileInfo[1]), double.Parse(fileInfo[2]))
                }
                else
                    ListFotoEquipment.Add(f);    
            }
            sr.Close();

        }
        public Repository()
        {
            ListFotoEquipment = new List<FotoEquipment>();
        }

    }
}

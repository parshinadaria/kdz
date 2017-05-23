using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace ClassLibrary
{
    public class Repository
    {
        public void Serialize(List<FotoEquipment> l, string path)
        {
            string str = JsonConvert.SerializeObject(l);//кнопка в мейн виндоу мб диалоговое окно с выбором файла "сохранить объекты"
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine(str);
            }
        }


        public List<FotoEquipment> Deserialize(string path)
        {

            string json = File.ReadAllText(path);
            if (string.IsNullOrEmpty(json)) { throw new ArgumentException("File is empty"); }
            List<FotoEquipment> l = JsonConvert.DeserializeObject<List<FotoEquipment>>(json);
            ListFotoEquipment.AddRange(l);
            return l;
            //вывести
            //вызвать в кнопках

        }


        public List<FotoEquipment> ListFotoEquipment;
        public void ReadFromFile(string filename)
        {
            string Line = "";
            StreamReader sr = new StreamReader(filename);
            while ((Line = sr.ReadLine()) != null)
            {
                string[] fileInfo = Line.Split(new char[] { ' ' });
                FotoEquipment f = null;
                if (fileInfo[0] == "Camera")
                {
                    double s = double.Parse(fileInfo[1]);
                    f = new Camera(double.Parse(fileInfo[1]), int.Parse(fileInfo[2]), fileInfo[3], fileInfo[4], fileInfo[5], fileInfo[6], double.Parse(fileInfo[7]), double.Parse(fileInfo[8]), fileInfo[9]);
                }
                if (fileInfo[0] == "Lens")
                {
                    f = new Lens(double.Parse(fileInfo[1]), int.Parse(fileInfo[2]), fileInfo[3], fileInfo[4], fileInfo[5], fileInfo[6], fileInfo[7], double.Parse(fileInfo[8]));
                }
                if (fileInfo[0] == "Flash")
                {
                    f = new Flash(double.Parse(fileInfo[1]), int.Parse(fileInfo[2]), fileInfo[3], fileInfo[4], fileInfo[5], fileInfo[6], int.Parse(fileInfo[7]), int.Parse(fileInfo[8]));
                }

                ListFotoEquipment.Add(f);
            }
            sr.Close();



        }
        public Repository()
        {
            string Japan = "Japan";
            string Nikon = "Nikon";
            string MOV = "MOV";
            string Canon = "Canon";

            ListFotoEquipment = new List<FotoEquipment>();
            //ReadFromFile("../../equipment.txt");
            ListFotoEquipment.Add(new Camera(21.105, 485, Japan, Canon, "1300D", "../../Images/canon1300D.jpeg", 18.7, 1.6, MOV));
            ListFotoEquipment.Add(new Camera(65.600, 730, Japan, Canon, "80D", "../../Images/canon80D.jpg", 25.8, 1.6, MOV));
            ListFotoEquipment.Add(new Camera(163.400, 950, Japan, Canon, "5D mark3", "../../Images/canon5D.jpg", 23.4, 1, MOV));
            ListFotoEquipment.Add(new Camera(22.700, 445, Japan, Nikon, "D3400", "../../Images/nikonD3400.jpg", 24, 1.5, MOV));
            ListFotoEquipment.Add(new Camera(124.500, 860, Japan, Nikon, "D500", "../../Images/nikonD500.jpg", 21.51, 1.5, MOV));
        //    ListFotoEquipment.Add(new Camera(200.200, 582, Japan, "Sony", "Alpha ILCE-7RM2 2", "../../Images/sony7RM2.jpg", 42, 1, "MP4"));
        //    ListFotoEquipment.Add(new Camera(70.300, 474, Japan, "Sony", "Alpha A7", "../../Images/sonyA7.jpg", 24.7, 1, "MP4"));
        //    ListFotoEquipment.Add(new Camera(50.000, 496, Japan, "Olympus", "OM-D E-M5 mark2", "../../Images/olympus.jpg", 17.2, 2, MOV));
        //    ListFotoEquipment.Add(new Lens(16.000, 240, Japan, Canon, "EF - S", "../../Images/canon10-18.jpg", "10 - 18", 4.5));
        //    ListFotoEquipment.Add(new Lens(15.000, 105, Japan, Canon, "EF - M", "../../Images/canon22.jpg", "22", 3.5));
        //    ListFotoEquipment.Add(new Lens(131.300, 1310, Japan, Canon, "EF", "../../Images/canon70-200.jpg", "70-200", 2.8));
        //    ListFotoEquipment.Add(new Lens(57.200, 770, Japan, Nikon, "AF-S", "../../Images/nikon105.jpg", "105", 2.8));
        //    ListFotoEquipment.Add(new Lens(50.300, 665, Japan, "Sigma", "AF", "../../Images/sigma35.jpg", "35", 1.4));
        //    ListFotoEquipment.Add(new Lens(27.700, 375, Japan, "Samyang", "E-NEX", "../../Images/samyang50.jpg", "50", 1.2));
        //    ListFotoEquipment.Add(new Lens(8.900, 305, Japan, "Sony", "DT", "../../Images/sony55-200.jpg", "55-200", 4));
        //    ListFotoEquipment.Add(new Lens(14.700, 400, Japan, "Tamron", "AF", "../../Images/tamron18-200.jpg", "18-200", 3.5));
        //    ListFotoEquipment.Add(new Lens(64.300, 825, Japan, "Tamron", "SP AF VC", "../../Images/tamron24-70.jpg", "24-70", 2.8));
        //    ListFotoEquipment.Add(new Flash(41.100, 435, Japan, Canon, "600EX", "../../Images/canon600.jpg", 60, 120));
        //    ListFotoEquipment.Add(new Flash(10.400, 155, Japan, Canon, "270EX", "../../Images/canon270.jpg", 60, 90));
        //    ListFotoEquipment.Add(new Flash(22.900, 450, Japan, "Sony", "HVL-F60M", "../../Images/sony60.jpg", 60, 90));
        //    ListFotoEquipment.Add(new Flash(10.900, 120, Japan, Nikon, "SB-400", "../../Images/nikon400.jpg", 18, 120));
        //    ListFotoEquipment.Add(new Flash(3.200, 200, Japan, "Doerr", "D-AF-34", "../../Images/doerr34.jpg", 34, 90));
        //    ListFotoEquipment.Add(new Flash(12.800, 330, Japan, "Sigma", "EF-610-DG", "../../Images/sigma610.jpg", 61, 90));
        }

    }
}

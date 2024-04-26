using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace HomeProject_SzA_DE6ZVJ
{
    class FileHandler
    {

        public static Admin[] ReadAdmin1(string path)
        {

            StreamReader sr = new StreamReader(path);
            sr.ReadLine();
            

            int Vac = int.Parse(sr.ReadLine());
            Admin[] NumOfVacation1 = new Admin[Vac];

            for (int i = 0; i < NumOfVacation1.Length; i++)
            {

                string[] s = sr.ReadLine().Split(';');
                NumOfVacation1[i] = new Admin(int.Parse(s[0]), int.Parse(s[1]));

            }
            sr.Close();
            return NumOfVacation1;
        }
        public static Admin[] ReadAdmin2(string path)
        {
            StreamReader sr = new StreamReader(path);
            sr.ReadLine();
            
            int Vac = int.Parse(sr.ReadLine());
            Admin[] NumOfVacation1 = new Admin[Vac];

            for (int i = 0; i < NumOfVacation1.Length; i++)
            {

                string[] s = sr.ReadLine().Split(';');
                NumOfVacation1[i] = new Admin(int.Parse(s[0]), int.Parse(s[1]));

            }
            int Vac2 = int.Parse(sr.ReadLine());
            Admin[] NumOfVacation2 = new Admin[Vac2];

            for (int i = 0; i < NumOfVacation2.Length; i++)
            {
                string[] s = sr.ReadLine().Split(';');
                NumOfVacation2[i] = new Admin(int.Parse(s[0]), int.Parse(s[1]));
            }
            sr.Close();
            return NumOfVacation2;
        }




        public static void WriteOut(int[,] OrganisedAll)
        {
            StreamWriter sw = new StreamWriter("holidaysout.txt", true);

            for (int i = 0; i < OrganisedAll.GetLength(0); i++)
            {

                if (OrganisedAll[i, 1] == -1)
                {
                    sw.WriteLine(OrganisedAll[i,0]);
                }
                else
                {
                    sw.WriteLine(OrganisedAll[i, 0] + ";" + OrganisedAll[i, 1]);
                }




            }
            sw.Close();




        }




    }




}

        


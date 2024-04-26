using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace HomeProject_SzA_DE6ZVJ
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = "holidaysin.txt";


            Admin[] numOfVacation1 = FileHandler.ReadAdmin1(path);

            Admin[] numOfVacation2 = FileHandler.ReadAdmin2(path);

            int[] Prediction = SafeUnsafe.PredictDays(path, numOfVacation1, numOfVacation2);

            int[,] OrganisedAll = SafeUnsafe.Organise(Prediction);


            FileHandler.WriteOut(OrganisedAll);




        }

    }
}

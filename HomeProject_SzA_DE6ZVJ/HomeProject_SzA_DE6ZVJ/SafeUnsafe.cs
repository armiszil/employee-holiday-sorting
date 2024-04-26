using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace HomeProject_SzA_DE6ZVJ
{
    class SafeUnsafe
    {

        public static int[] PredictDays(string path,Admin[]NumOfVacation1,Admin[]NumOfVacation2)
        {
            StreamReader sr = new StreamReader(path);
            int days = int.Parse(sr.ReadLine());
            int[] Prediction = new int[days];
            

            for (int i = 0; i < Prediction.Length; i++)
            {      
                Prediction[i] = 0;      
            }
            for (int i = 0; i < NumOfVacation1.Length; i++)
            {
                for (int j = 0; j < Prediction.Length; j++)
                {
                    if (j >= NumOfVacation1[i].Start && j <= NumOfVacation1[i].End)
                    {
                        Prediction[j] += 1;
                    }
                }
            }

            for (int i = 0; i < NumOfVacation2.Length; i++)
            {
                for (int j = 0; j < Prediction.Length; j++)
                {
                    if (j >= NumOfVacation2[i].Start && j <= NumOfVacation2[i].End)
                    {
                        Prediction[j] += 1;
                    }
                }
            }



            sr.Close();
            return Prediction;


        }



        public static int[,] Organise(int[] Prediction)
        {
            
            int start = -1;
            int end = 0;
            int numOfSafe = 0;


            if (Prediction[0] == 0)
            {
                numOfSafe++;
            }

            for (int i = 1; i < Prediction.Length; i++)
            {

                if (Prediction[i] != Prediction[i-1] && Prediction[i] == 0  )
                {
                    numOfSafe++;
                    
                }
                
               
            }

            int[,] OrganisedSafe = new int[numOfSafe, 2];


            for (int i = 0; i < OrganisedSafe.GetLength(0); i++)
            {
                for (int j = 0; j < OrganisedSafe.GetLength(1); j++)
                {
                    OrganisedSafe[i, j] = -1;
                }
            }



            if (Prediction[0] == 0 )
            {
                start = 0;
            }
            for (int i = 1; i < Prediction.Length; i++)
            {


                if (Prediction[i] != Prediction[i - 1] && Prediction[i] == 0)
                {
                    start=i;
                }

                if (Prediction[i] != Prediction[i - 1] && Prediction[i] != 0 && start !=-1 )
                {
                    end = i-1;
                    for (int j = 0; j < OrganisedSafe.GetLength(0); j++)
                    {
                        if (OrganisedSafe[j,0] == -1)
                        {
                            OrganisedSafe[j, 0] = start;
                            OrganisedSafe[j, 1] = end;
                            j = OrganisedSafe.GetLength(0);
                        }

                    }
                    start = -1;
                }
                else if (i==Prediction.Length-1 && start != -1)
                {
                    end = i + 1;
                    for (int j = 0; j < OrganisedSafe.GetLength(0); j++)
                    {
                        if (OrganisedSafe[j, 0] == -1)
                        {
                            OrganisedSafe[j, 0] = start;
                            OrganisedSafe[j, 1] = end;
                           j = OrganisedSafe.GetLength(0);
                        }

                    }
                }
 
            }
          




            Console.WriteLine();



           start = -1;
           end = 0;
            int numOfUnsafe = 0;


            if (Prediction[0] == 2)
            {
                numOfUnsafe++;
            }

            for (int i = 1; i < Prediction.Length; i++)
            {

                if (Prediction[i] != Prediction[i - 1] && Prediction[i] == 2)
                {
                    numOfUnsafe++;
                    
                }


            }

            int[,] OrganisedUnsafe = new int[numOfUnsafe, 2];


            for (int i = 0; i < OrganisedUnsafe.GetLength(0); i++)
            {
                for (int j = 0; j < OrganisedUnsafe.GetLength(1); j++)
                {
                    OrganisedUnsafe[i, j] = -1;
                }
            }



            if (Prediction[0] == 2)
            {
                start = 0;
            }
            for (int i = 1; i < Prediction.Length; i++)
            {


                if (Prediction[i] != Prediction[i - 1] && Prediction[i] == 2)
                {
                    start = i;
                }

                if (Prediction[i] != Prediction[i - 1] && Prediction[i] != 2 && start != -1)
                {
                    end = i - 1;
                    for (int j = 0; j < OrganisedUnsafe.GetLength(0); j++)
                    {
                        if (OrganisedUnsafe[j, 0] == -1)
                        {
                            OrganisedUnsafe[j, 0] = start;
                            OrganisedUnsafe[j, 1] = end;
                            j = OrganisedUnsafe.GetLength(0);
                        }

                    }
                    start = -1;
                }
                else if (i == Prediction.Length - 1 && start != -1)
                {
                    end = i + 1;
                    for (int j = 0; j < OrganisedUnsafe.GetLength(0); j++)
                    {
                        if (OrganisedUnsafe[j, 0] == -1)
                        {
                            OrganisedUnsafe[j, 0] = start;
                            OrganisedUnsafe[j, 1] = end;
                            j = OrganisedUnsafe.GetLength(0);
                        }

                    }
                }

            }
           


            int[,] OrganisedAll = new int[numOfSafe + numOfUnsafe + 2,2];

            OrganisedAll[0, 0] = numOfSafe;
            OrganisedAll[0, 1] = -1 ;
            for (int i = 1; i < OrganisedSafe.GetLength(0) + 1 ; i++)
            {
                OrganisedAll[i,0] = OrganisedSafe[i - 1,0];
                OrganisedAll[i, 1] = OrganisedSafe[i - 1, 1];

            }
            OrganisedAll[OrganisedSafe.GetLength(0) + 1, 0] = numOfUnsafe;
            OrganisedAll[OrganisedSafe.GetLength(0) + 1, 1] = -1;
            for (int i = 0; i < OrganisedUnsafe.GetLength(0); i++)
            {
                OrganisedAll[OrganisedSafe.GetLength(0)+ 2+ i, 0] = OrganisedUnsafe[i , 0];
                OrganisedAll[OrganisedSafe.GetLength(0) + 2 + i,1] = OrganisedUnsafe[i , 1];

            }


           
            return OrganisedAll;
        }


    }
}

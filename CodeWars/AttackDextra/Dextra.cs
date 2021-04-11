using System;
using System.Collections.Generic;

namespace DextraAlgorithm
{
    class Dextra
    {
        public int[] Start(int pointA, int pointB, int[,] distanceMatrix)
        {

            /*int pointA = 1;
            int pointB = 5;*/

            /*int[,] distanceMatrix = new int[,] { { 0 ,7, 9 , 0 ,0,14},
                                                 { 7 , 0 ,10, 15 , 0 , 0},
                                                 { 9 , 10 , 0 ,11, 0 , 2},
                                                 { 0 , 15 , 11 , 0 , 6 , 0},
                                                 { 0 , 0 , 0 , 6 , 0 ,9},
                                                 { 14 , 0 , 2 , 0 , 9 , 0 },
                                                  };*/



            int[] arrayVisits = new int[distanceMatrix.GetLength(0)];
            for (int i = 1; i < arrayVisits.Length; i++)
                arrayVisits[i] = 10000;

            // Пробегаем по массиву расстояний 
            for (int i = 0; i < distanceMatrix.GetLength(0); i++)
            {
                for (int j = 1; j < distanceMatrix.GetLength(0); j++)
                {
                    if (distanceMatrix[i, j] != 0 && arrayVisits[j] > (distanceMatrix[i, j] + arrayVisits[i]))
                        arrayVisits[j] = distanceMatrix[i, j] + arrayVisits[i];

                }
            }

            //debug answer
            for (int j = 0; j < distanceMatrix.GetLength(0); j++)
            {

                Console.Write(arrayVisits[j].ToString() + " ");
            }
            //обработка ответа
            int k = pointA - 1;
            List<int> arrayAsnwer = new List<int>();
            while (k != pointB - 1)
            {
                Console.WriteLine("Исходная точка: {0} ", (k + 1).ToString());
                for (int j = 0; j < distanceMatrix.GetLength(0); j++)
                {
                    if (distanceMatrix[k, j] != 0 && (arrayVisits[k] + distanceMatrix[k, j]) == arrayVisits[j])
                    {
                        Console.WriteLine("Ответ: {0} ", (j + 1).ToString());
                        arrayAsnwer.Add(j);
                        k = j;
                        j = 0;
                    }

                }
                if (k == pointB - 1)
                    break;
                arrayVisits[k] = -1;
                k = pointA - 1;
                arrayAsnwer.Clear();
            }
            int[] answer = new int[arrayAsnwer.Count];
            int l = 0;
            foreach (int i in arrayAsnwer)
            {
                answer[l] = i;
                l++;
            }
            return answer;

        }
    }
}


using System;
using System.Linq;

namespace DextraFuelAlgorithm
{
    class Program
    {


        static void Main(string[] args)
        {
            int numberOfVillage = 8;
            int pointA = 1, pointB = 4, tankСapacity = 1000;
            float coeffFuel = 0.5f;

            int[,] distanceMatrix = new int[,] { { 0 ,150, 0 , 0 ,180,150, 0 , 0 },
                                                 { 0 , 0 ,130, 0 , 0 , 0 , 0 , 0 },
                                                 { 0 , 0 , 0 ,150, 0 , 0 , 0 , 0 },
                                                 { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 },
                                                 { 0 , 0 , 0 , 0 , 0 ,320, 0 , 0 },
                                                 { 0 , 0 , 0 , 0 , 0 , 0 ,160,140},
                                                 { 0 , 0 , 0 , 0 , 0 , 0 , 0 ,100},
                                                 { 0 , 0 , 0 ,180, 0 , 0 , 0 , 0 } };

            /*Console.Write("Введите количество населенных пунктов: ");
            numberOfVillage = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите расположения начального пункта А: ");
            pointA = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите расположение конечного пункта В: ");
            pointB= Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите вместимость баков машин: ");
            tankСapacity = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите коэффициент расхода топлива на единицу расстояния(запятая): ");
            coeffFuel = float.Parse(Console.ReadLine());*/
            int[] refuelingQuantityVillage = new int[] {100,50,50,20,200,50,200,50};
            
            /*for(int j = 0; j < refuelingQuantityVillage.Length; j++)
            {
                Console.Write("Введите количество топлива в пункте {0}: ", j + 1);
                refuelingQuantityVillage[j] = Convert.ToInt32(Console.ReadLine());
                
            }*/
            /*foreach(int vil in refuelingQuantityVillage)
            {
                Console.Write("Запасы : {0} ",vil);
                
            }*/
            //Расчет массы веток
            for(int i = 0; i < refuelingQuantityVillage.Length; i++)
            {
                for (int j = 0; j < refuelingQuantityVillage.Length; j++)
                {
                    if(distanceMatrix[i,j]!=0)
                    distanceMatrix[i, j] = (int)Math.Ceiling(refuelingQuantityVillage[i] / coeffFuel) - distanceMatrix[i, j];
                }
            }
            ////////////////////////////////////////////////////////////////////
            // нахождение максимального значения            
            Array array = distanceMatrix;
            var max = array.Cast<int>().Max();
            ////////////////////////////////////
            //Преоьразования к матрице Дейкстра
            for (int i = 0; i < refuelingQuantityVillage.Length; i++)
            {
                for (int j = 0; j < refuelingQuantityVillage.Length; j++)
                {
                    if(distanceMatrix[i,j]!=0&& distanceMatrix[i, j] != max)
                    distanceMatrix[i, j] = (distanceMatrix[i, j] - max) * -1;
                    if (distanceMatrix[i, j] == max)
                        distanceMatrix[i, j] = 1;
                }
            }
            int[] arrayVisits = new int[refuelingQuantityVillage.Length];
            // Пробегаем по массиву расстояний 
            for (int i = 0; i < refuelingQuantityVillage.Length; i++)
            {
                for (int j = 1; j < refuelingQuantityVillage.Length; j++)
                {
                    if (distanceMatrix[i, j] != 0&& arrayVisits[j]< (distanceMatrix[i, j] + arrayVisits[i]))
                        arrayVisits[j]= distanceMatrix[i, j]+arrayVisits[i];
                    
                }
            }
            //debug answer
            for (int j = 0; j < refuelingQuantityVillage.Length; j++)
            {

                Console.Write(arrayVisits[j].ToString() + " ");
            }
            //обработка ответа
            int k = pointA-1;
            while(k != pointB-1)
            {
                Console.WriteLine("Исходная точка: {0} ", (k+1).ToString());
                for (int j = 0; j < refuelingQuantityVillage.Length; j++)
                {
                    if (distanceMatrix[k, j] != 0 && (arrayVisits[k] + distanceMatrix[k, j]) == arrayVisits[j])
                    {
                        Console.WriteLine("Ответ: {0} ", (j+1).ToString());
                        k = j;
                        j = 0;
                    }

                }
                if (k == pointB - 1)
                    break;
                arrayVisits[k] = -1;
                k = pointA - 1;

            }



            //Debug
            for (int i = 0; i < refuelingQuantityVillage.Length; i++)
            {
                for (int j = 0; j < refuelingQuantityVillage.Length; j++)
                {
                    Console.Write(distanceMatrix[i, j].ToString() + " ");
                }
                Console.Write("\n");
            }
            
            


        }
    }
}

using System;
using DextraAlgorithm;

namespace AttackDextra
{
    class Program
    {
        static void Main(string[] args)
        {

            Dextra dextra = new Dextra();
            int pointA=1;
            int quantityStr = 7;
            int pointB=7;


            int[,] matrix = new int[2,2];
            int[] result = new int[5];
            while{

                result= dextra.Start(pointA,pointB,matrix);

            }

        }
    }
}

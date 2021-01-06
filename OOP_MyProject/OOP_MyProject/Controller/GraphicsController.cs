using System;
using System.Collections;

public class GraphicsController
{
    

    public static void Draw(ArrayList GameObjects)
    {
        Console.WriteLine('\n');
        Console.Clear();
        foreach (Player p in GameObjects)
        for (int i = 1; i <= GameOption.sizeOfMap; i++)
        {

                
                if (i == p.Position)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("*");

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("o");
                }
                
                if (i % Math.Sqrt(GameOption.sizeOfMap) == 0)
                Console.WriteLine('\n');
        }
            
        

    }
}

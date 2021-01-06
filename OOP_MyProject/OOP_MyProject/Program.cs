using System;
using System.Collections;

namespace OOP_MyProject
{
    class Program
    {
        static ArrayList GameObjects = new ArrayList();
        static void Main(string[] args)
        {
            Console.WriteLine("Starting game...");
            InitGame();
            Update();
        }
        static void InitGame()
        {
            Player player = new Player("Canek", 1, 6);
            GameObjects.Add(player);
            NPC npc1 = new NPC("Bob", 1, 1);
            NPC npc2 = new NPC("Den", 1, GameOption.sizeOfMap);
            GameObjects.Add(npc1);
            GameObjects.Add(npc2);
            Console.WindowHeight = GameOption.WindowHeight;
            Console.WindowWidth = GameOption.WindowWidth;
        }
        static void Update()
        {
            
            char command = '0';
            while (command != 'q')
            {
            GraphicsController.Draw(GameObjects);
            command= Console.ReadKey().KeyChar;
                foreach (Player p in GameObjects)
                    p.Position += p.Move(command);

            }
        }
    }
}

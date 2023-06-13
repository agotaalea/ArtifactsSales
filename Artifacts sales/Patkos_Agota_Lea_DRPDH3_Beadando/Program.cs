using System.Collections;
using System.Data;

namespace Patkos_Agota_Lea_DRPDH3_Beadando
{
    internal class Program
    {
        static Random r = new Random();

        static void Main(string[] args)
        {
            // init
            string path = "input.txt";
            string[] input = FileHandler.Read(path);
            string[] wallParams = input[0].Split(';');
            Storage storage = new Storage(input);
            Store store = new Store(storage.Artifacts, int.Parse(wallParams[0]), int.Parse(wallParams[1]));
            DisplayWall(store);
            Console.WriteLine("\n\n\n");

            // auction
            Queue<Artifact> notSoldQueue = Auction(store.Artifacts);
            Artifact[] notSoldArray = new Artifact[notSoldQueue.Count];
            int i = 0;
            while (notSoldQueue.Count > 0)
            {
                notSoldArray[i] = notSoldQueue.Dequeue();
                i++;
            }

            Console.WriteLine($"{notSoldArray.Length}/{store.Artifacts.Length} darabot nem sikerült eladni.");
            store = new Store(notSoldArray, int.Parse(wallParams[0]), int.Parse(wallParams[1]));
            DisplayWall(store);
        }

        public static Queue<Artifact> Auction(Artifact[] artifacts)
        {
            Queue<Artifact> result = new Queue<Artifact>();
            foreach (Artifact artifact in artifacts)
            {
                if (r.Next(1, 101) > 50)
                {
                    result.Enqueue(artifact);
                }
            }

            return result;
        }

        public static void DisplayWall(Store store)
        {
            for (int i = 0; i < store.Wall.GetLength(0); i++)
            {
                for (int j = 0; j < store.Wall.GetLength(1); j++)
                {
                    if (store.Wall[i, j] != string.Empty)
                    {
                        Console.Write(store.Wall[i, j] + "\t");
                    }
                    else
                    {
                        Console.Write(".\t");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
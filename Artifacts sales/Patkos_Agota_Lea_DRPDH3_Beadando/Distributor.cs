using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Patkos_Agota_Lea_DRPDH3_Beadando
{
    internal static class Distributor
    {
        private static int tempCount;
        private static Artifact[] tempArtifacts;

        public static Store ActualStore
        {
            get; set;
        }

        public static void InitStoreWall(Artifact[] items)
        {
            tempArtifacts = new Artifact[items.Length];
            tempCount = 0;

            Array.Sort(items);

            foreach (Artifact item in items)
            {
                string newPosition = GetPosition(item);
                if (newPosition != "-1")
                {
                    int x = int.Parse(newPosition.Split(";")[0]);
                    int y = int.Parse(newPosition.Split(";")[1]);
                    PlaceItem(item, x, y);

                    tempArtifacts[tempCount] = item;
                    tempCount++;
                }
                else if (item.W > ActualStore.Wall.GetLength(1) || item.H > ActualStore.Wall.GetLength(0))
                {
                    FileHandler.Write(item);
                }
            }

            ActualStore.Artifacts = new Artifact[tempCount];
            int i = 0;
            while (i < tempArtifacts.Length && tempArtifacts[i] != null)
            {
                ActualStore.Artifacts[i] = tempArtifacts[i];
                i++;
            }
        }

        private static string GetPosition(Artifact item)
        {
            string position = "-1";
            int y = 0;
            while (y < ActualStore.Wall.GetLength(0) && position == "-1")
            {
                int x = 0;
                while (x < ActualStore.Wall.GetLength(1) && position == "-1")
                {
                    if (item.IsWidthOk(ActualStore.Wall, y, x) && item.IsHeightOk(ActualStore.Wall, y, x))
                    {
                        position = x.ToString() + ";" + y.ToString();
                        return position;
                    }

                    x++;
                }

                y++;
            }

            return position;
        }

        private static void PlaceItem(Artifact item, int x, int y)
        {
            ;
            for (int i = 0; i < item.W; i++)
            {
                for (int j = 0; j < item.H; j++)
                {
                    if (ActualStore.Wall[y + j, x + i] == string.Empty)
                    {
                        ActualStore.Wall[y + j, x + i] = item.ID;
                    }
                    else
                    {
                        ActualStore.Wall[y + j, x + i] += ";" + item.ID;
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patkos_Agota_Lea_DRPDH3_Beadando
{
    internal class Storage
    {
        public Artifact[] Artifacts { get; set; }

        public Storage(string[] data)
        {
            this.Artifacts = Load(data);
        }

        public static Artifact[] Load(string[] data)
        {
            Artifact[] result = new Artifact[data.Length - 1];

            for (int i = 1; i < data.Length; i++)
            {
                string[] row = data[i].Split(";");
                int price = int.Parse(row[1]);
                int width = int.Parse(row[2]);
                int height = int.Parse(row[3]);
                
                if (row[0] == "P")
                {
                    result[i - 1] = new Picture(width, height, price);
                }
                else if (row[0] == "R")
                {
                    result[i - 1] = new Roll(width, height, price);
                }
                else
                {
                    int depth = int.Parse(row[4]);
                    result[i - 1] = new ArtWork(width, height, depth, price);
                }
            }

            return result;
        }
    }
}

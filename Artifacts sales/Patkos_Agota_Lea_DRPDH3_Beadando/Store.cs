
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patkos_Agota_Lea_DRPDH3_Beadando
{
    internal class Store
    { 
        public Artifact[] Artifacts { get; set; }
        public string[,]? Wall
        {
            get; set;
        }

        public Store(Artifact[] storage, int wallWidth, int wallHeight)
        {
            this.Wall = new string[wallHeight, wallWidth];
            for (int i = 0; i < this.Wall.GetLength(0); i++)
            {
                for (int j = 0; j < this.Wall.GetLength(1); j++)
                {
                    this.Wall[i, j] = string.Empty;
                }
            }

            Distributor.ActualStore = this;
            try
            {
                Distributor.InitStoreWall(storage);
            }
            catch (BiggerThanTheWallException e)
            {
                FileHandler.Write(e.BigItem);
            }
        }
    }
}

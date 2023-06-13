using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patkos_Agota_Lea_DRPDH3_Beadando
{
    internal class Roll : Artifact
    {
        public Roll(int width, int height, int price) : base(width, height, price, "R")
        {
        }

        public override bool IsHeightOk(string[,] wall, int startY, int x)
        {
            int y = 0;
            while (startY < wall.GetLength(0) && (wall[startY, x] == string.Empty || wall[startY, x] == "P") && y < this.H)
            {
                startY++;
                y++;
            }

            return y == this.H;
        }

        public override bool IsWidthOk(string[,] wall, int y, int startX)
        {
            int x = 0;
            while (startX < wall.GetLength(1) && (wall[y, startX] == string.Empty || wall[y, startX] == "P") && x < this.W)
            {
                startX++;
                x++;
            }

            return x == this.W;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patkos_Agota_Lea_DRPDH3_Beadando
{
    public abstract class Artifact : IComparable<Artifact>
    {
        public int W { get; set; }
        public int H { get; set; }
        public int Price { get; set; }
        public string ID { get; set; }
        public int AvgPrice { get; set; }

        public Artifact(int width, int height, int price, string id)
        {
            this.W = width;
            this.H = height;
            this.Price = price;
            this.ID = id;
            this.AvgPrice = this.Price / (this.H * this.W);
        }

        public int CompareTo(Artifact? other)
        {
            return this.AvgPrice.CompareTo(other?.AvgPrice) * -1;
        }

        public virtual bool IsHeightOk(string[,] wall, int startY, int x)
        {
            int y = 0;
            while (startY < wall.GetLength(0) && wall[startY, x] == string.Empty && y < this.H)
            {
                startY++;
                y++;
            }

            return y == this.H;
        }

        public virtual bool IsWidthOk(string[,] wall, int y, int startX)
        {
            int x = 0;
            while (startX < wall.GetLength(1) && wall[y, startX] == string.Empty && x < this.W)
            {
                startX++;
                x++;
            }

            return x == this.W;
        }

        public override string ToString()
        {
            return $"The artifact's type: {this.ID}, height: {this.H}, width: {this.W}, price: {this.Price}";
        }
    }
}

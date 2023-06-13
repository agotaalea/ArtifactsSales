using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patkos_Agota_Lea_DRPDH3_Beadando
{
    internal class ArtWork : Artifact
    {
        public int D { get; set; }

        public ArtWork(int width, int height, int depth, int price) : base(width, height, price, "A")
        {
            this.D = depth;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patkos_Agota_Lea_DRPDH3_Beadando
{
    internal class BiggerThanTheWallException : Exception
    {
        public Artifact BigItem { get; set; }

        public BiggerThanTheWallException(Artifact item) : base($"{item} is bigger than the wall, sell immediately!")
        {
            BigItem = item;
        }
    }
}

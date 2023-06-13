using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patkos_Agota_Lea_DRPDH3_Beadando
{
    internal static class FileHandler
    {
        public static string[] Read(string path)
        {
            StreamReader streamReader = new StreamReader(path);
            string[] lines = streamReader.ReadToEnd().Split('\n');
            streamReader.Dispose();
            streamReader.Close();
            return lines;
        }

        public static void Write(Artifact item)
        {
            StreamWriter sw = new StreamWriter($"toBeSold_{DateTime.Now.ToString("yyyyMMddHHmmss")}.txt", true);
            sw.WriteLine(item.ToString());
            sw.Flush();
            sw.Close();
        }
    }
}

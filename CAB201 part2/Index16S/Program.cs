using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Index16S
{
    class program
    {
        static void Main(string[] args)
        {
            StreamReader file = new StreamReader(args[1]);
            FileStream indexFile = new FileStream(args[2], FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(indexFile);//Create a result file 
            var arr = new List<string>();
            string line;
            int counter = 0;
            int position = 0;

            while ((line = file.ReadLine()) != null)
            {
                counter++;
                if (counter % 2 == 1)
                {
                    arr.Add(line.Split(' ')[0] + " " + position);
                }
                position = position + line.Length + 1;

            }
            foreach (var ele in arr)
            {
                writer.WriteLine(ele);
            }
        }
    }
}
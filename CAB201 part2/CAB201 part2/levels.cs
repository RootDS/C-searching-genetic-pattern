using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace CAB201_part2
{
    class levels
    {
        Readfile DNA = new Readfile();
        public void level1(string filename, string startline, string endline)
        {
            DNA.GetFasta(filename);//Read the file
            DNA.filename = filename;
            int start = Convert.ToInt32(startline);
            int end = Convert.ToInt32(endline);
            end = (start + end * 2) - 1;//Conver the end in order to use the method
            if (start > DNA.counter || end > DNA.counter)
            {
                throw new ArgumentException($"Search out of bound, file has total {DNA.counter} lines.");
            }
            else if (start % 2 != 1)
            {
                throw new ArgumentException($"The start line should be an odd number.");
            }
            //Write the results string in console
            WriteLine(DNA.FindFromLine(start, end));
            DNA.CloseReader();
        }

        public void level2(string filename, string sequence)
        {
            
            DNA.GetFasta(filename);
            DNA.filename = filename;
            //Find the specific sequence in that line and use 'begin' to save it
            List<int> result = DNA.DNASearcher(filename, sequence);

            if (result.Count() == 0)//If nothing match the method returns 0
            {
                WriteLine("The sequence {0} is not in this file.", sequence);
            }
            //Write the results string in console
           
            WriteLine(DNA.FindFromLine(result[0], result[0] + 1));
        }

        public void level3(string filename, string queryfile, string resultfile)
        {
            DNA.GetFasta(filename);
            DNA.filename = filename;
            List<string> querries = DNA.GetQuerry(queryfile);
            DNA.create_writer(resultfile);
            //List<int> result1 = new List<int>();
            //Check each query, if it matches, write the result to result file
            for (int i = 0; i < querries.Count(); i++)
            {

                List<int> result = DNA.DNASearcher(filename, querries[i]);
                if (result.Count() == 0)
                {
                    WriteLine("The sequence {0} is not in this file.", querries[i]);
                }
                else
                {
                    DNA.file_writer(DNA.FindFromLine(result[0], result[0] + 1));
                }
            }
            DNA.close_writer();
        }

        public void level4(string filename, string indexfile, string querryfile, string resultfile)
        {
            DNA.GetFasta(filename);
            DNA.filename = filename;
            List<string> querriess = DNA.GetQuerry(querryfile);
            DNA.create_writer(resultfile);
            //List<int> result1 = new List<int>();
            //Check each query, if it matches, write the result to result file
            for (int i = 0; i < querriess.Count(); i++)
            {

                List<int> result = DNA.DNASearcher(indexfile, querriess[i]);
                if (result.Count() == 0)
                {
                    WriteLine("The sequence {0} is not in this file.", querriess[i]);
                }
                else
                {
                    DNA.file_writer(DNA.FindFromLine(result[0] * 2 - 1, result[0] * 2));
                }
            }
            DNA.close_writer();
        }

        public void level5(string filename, string DNApattern)
        {
            DNA.GetFasta(filename);
            DNA.filename = filename;
            //Find the specific sequence in that line and use 'begin' to save it
            List<int> result = DNA.DNASearcher(filename, DNApattern);

            if (result.Count() == 0)//If nothing match the method returns 0
            {
                WriteLine("The sequence {0} is not in this file.", DNApattern);
            }
                      
            //Write the results string in console
            for (int i = 0; i < result.Count(); i++)
            {
                WriteLine(DNA.FindFromLine(result[i] - 1, result[i] - 1).Split(' ')[0]);
            }
        }

        public void level6(string filename, string DNApattern)
        {
            DNA.GetFasta(filename);
            DNA.filename = filename;
            //Find the specific sequence in that line and use 'begin' to save it
            List<int> result = DNA.DNASearcher(filename, DNApattern);

            if (result.Count() == 0)//If nothing match the method returns 0
            {
                WriteLine("The sequence {0} is not in this file.", DNApattern);
            }

            //Write the results string in console
            for (int i = 0; i < result.Count(); i++)
            {
                WriteLine(DNA.FindFromLine(result[i], result[i]).Split(' ')[0]);
            }
        }
        
    }
    
}

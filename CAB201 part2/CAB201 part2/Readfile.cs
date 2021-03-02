using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;
using System.Text.RegularExpressions;

namespace CAB201_part2
{
    class Readfile
    {
        private List<int> pos = new List<int>();//A list to keep positions
        private List<int> size = new List<int>();//A list to keep sizes 
        private int position = 0;
        public string filename;
        public int counter;//Line counter

        private StreamReader file_reader;
        private FileStream file_stream;
        private FileStream resultFile;
        private StreamWriter writer;

        public void GetFasta(string filename)
        {
            // Try to set reader
            try
            {
                file_reader = new StreamReader(filename);
                file_stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            }
            // Handle exception
            catch (IOException e)
            {
                throw new ArgumentException("bad file path, can not set file reader:\n-> " + filename);
            }
            string line;
            counter = 0;
            while ((line = file_reader.ReadLine()) != null)
            {
                pos.Insert(counter, position);
                size.Insert(counter, line.Length + 1);
                counter++;
                position = position + line.Length + 1;
            }

        }

        public void CloseReader()
        {
            file_reader.Close();
        }

        public List<string> GetQuerry(string querryname)
        {
            List<string> query = new List<string>();//A list to store queries from query.txt
            FileStream querryFile = new FileStream(querryname, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(querryFile);//Read query file
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                query.Add(line);
            }
            reader.Close();
            querryFile.Close();
            return query;
        }

        public void create_writer(string writername)
        {
            resultFile = new FileStream(writername, FileMode.Create, FileAccess.Write);
            writer = new StreamWriter(resultFile);//Create a result file 

        }
        public void file_writer(string content)
        {
            writer.WriteLine(content);
            
        }
        public void close_writer()
        {
            writer.Close();
        }

        //Method to store contents between start and end lines in a string 'result'
        public string FindFromLine(int start, int end)
        {
            string result = string.Empty;
            using (file_stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                for (int n = start - 1; n < end; n++)
                {
                    byte[] bytes = new byte[size[n]];
                    file_stream.Seek(pos[n], SeekOrigin.Begin);
                    file_stream.Read(bytes, 0, size[n]);
                    string l = Encoding.Default.GetString(bytes);
                    result += l;
                }
                return result;
            }
        }

        //Method to find in which line the sequence appeared

        public List<int> DNASearcher(string file,string sequence)
        {
            string line;
            int counter = 0;
            List<int> DNAfound = new List<int>();
            file_reader = new StreamReader(file);

            while ((line = file_reader.ReadLine()) != null)
            {

                counter++;

                if (line.Contains(sequence))
                {
                    DNAfound.Add(counter);
                }
            }
            return DNAfound;

        }

        public void DNAmatcher(string file, string value)
        {
            file_reader = new StreamReader(file);
            string line;
            string pattern = value.Replace("*", "[A-Z]*");
            
            while ((line = file_reader.ReadLine()) != null)
            {
                Match match = Regex.Match(line, pattern);
                if (match.Success)
                {
                    WriteLine(match.Value);
                }
            }
            file_reader.Close();
        }
    }

}

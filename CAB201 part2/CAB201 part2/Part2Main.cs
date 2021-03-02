using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace CAB201_part2
{
    class Part2Main
    {
        static void Main(string[] args)
        {
            if (args[0] == "Search16s")//Check first argument
            {
                //Each case for each level
                levels search16S = new levels();
                Readfile DNA = new Readfile();
                switch (args[1])
                {
                    case "-level1":
                        if (args.Length != 5)
                        {
                            throw new ArgumentException($"Level 1 needs 5 arguments.");
                        }
                        
                        search16S.level1(args[2], args[3], args[4]);

                       
                        break;

                    case "-level2":
                        if (args.Length != 4)
                        {
                            throw new ArgumentException("level 2 needs 4 arguments.");
                        }
                        try
                        {
                            if (!args[3].Contains("NR"))
                            {
                                WriteLine("This is not a sequence ID, please recheck.");
                                break;
                            }
                            search16S.level2(args[2], args[3]);
                            

                        }
                        catch (FormatException e)
                        {
                            throw new ArgumentException("There is something wrong with this arguments.");
                        }

                        break;
                    case "-level3":
                        if (args.Length != 5)
                        {
                            throw new ArgumentException($"Level 3 needs 5 arguments.");
                        }
                        try
                        {
                            search16S.level3(args[2],args[3],args[4]);
                            
                        }
                        catch (FormatException e)
                        {
                            throw new ArgumentException("There is something wrong with this arguments.");
                        }

                        break;

                    case "-level4"://Check second argument
                        if (args.Length != 6)//Check argument length
                        {
                            throw new ArgumentException($"Level 3 needs 5 arguments.");
                        }
                        if (!File.Exists(args[3]))//If index file does not exsist
                        {
                            WriteLine("The index file dose not exist.");
                            break;
                        }
                        else if (!File.Exists(args[4]))//If query file does not exsist
                        {
                            WriteLine("The query file dose not exist.");
                            break;
                        }
                        //level4 method from levels class
                        search16S.level4(args[2], args[3], args[4], args[5]);
                        
                        break;

                    case "-level5"://Check the second argument
                        if (args.Length != 4)
                        {
                            throw new ArgumentException("level 5 needs 4 arguments.");
                        }
                        //Check if the searched key is in the right format
                        char[] chars = { 'A', 'C', 'G', 'T', 'N' };
                        if(args[3].IndexOfAny(chars) == -1)//If it does not contains any of the "chars"
                        {
                            WriteLine("Wrong type of argument, level 5 only search DNA query string.");
                            break;
                        }
                        //level5 method from levels class
                        search16S.level5(args[2], args[3]);
                        break;

                    case "-level6":
                        if (args.Length != 4)
                        {
                            throw new ArgumentException("level 6 needs 4 arguments.");
                        }
                        if (args[3] is string)//Check if the searched key is a string
                        {
                            //level6 method from levels class
                            search16S.level6(args[2], args[3]);
                        }
                        else
                        {
                            WriteLine("Wrong type of argument, level 6 only search certain words.");
                        }
                        break;

                    case "-level7":
                        if (args.Length != 4)
                        {
                            throw new ArgumentException("level 7 needs 4 arguments.");
                        }

                        if (!args[3].Contains("*"))//Check if the searched key contains wildcards
                        {
                            WriteLine("Wrong type of argument, level 7 only search sequence containing wild cards.");
                        }
                        //level7 method from Readfile class
                        DNA.DNAmatcher(args[2], args[3]);

                        break;

                }
            }
            WriteLine("Hit Enter to quit.");
            ReadLine();
        }
    }
}

/************************************************************
    PROGRAMME	: ASSN01: Class Average Competition	

    OUTLINE		:	This is the program class. It declares two
                    school objects and one output object which
                    display the averages per school, per course 
                    and school average. The resulting data is
                    organised in numberical form and displayed
                    in a bar graph for easy compairson. The data
                    is outputted to the console and to a text file

    PROGRAMMER	:	Saikrishna Tadepalli

    DATE		:	October 10th 2019
************************************************************/

using System;
using System.IO;

namespace TadepalliS_ASSN01
{
    class Program
    {
        public static StreamWriter file = new StreamWriter("Result.txt");
        static void Main(string[] args)
        {
            School satec = new School("Satec.txt");

            if (School.abort)
            {
                Console.WriteLine();
            }
            else
            {
                School rhking = new School("RHKing.txt");

                if (School.abort)
                {
                    Console.WriteLine();
                }
                else { 

                    satec.CompileData();
                    rhking.CompileData();

                    Display output = new Display(satec, rhking, "Satec", "RHKing");

                    output.DisplayData();

                    Console.CursorVisible = false;
                }
            }

            Console.ReadKey();
        }
    }
}
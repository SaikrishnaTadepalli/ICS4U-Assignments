/************************************************************
    PROGRAMME	: ASSN01: Class Average Competition	

    OUTLINE		:	This class is for the two schools. It 
                    reads the class averages from the text
                    files for each school declared on initialization
                    of objects. It then computes the class averages
                    and the total average per declared school.

    PROGRAMMER	:	Saikrishna Tadepalli

    DATE		:	October 10th 2019
************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TadepalliS_ASSN01
{
    class School
    {
        public string[] lines;
        public static Boolean abort = false;
        public double[] classAverages = {0,0,0,0,0};
        public double totalAverage = 0;

        // this method initializes the school objects
        public School(string fileName)
        {
            if (File.Exists(fileName))
            {
                lines = System.IO.File.ReadAllLines(fileName);
            }
            else 
            {
                Console.WriteLine("File \"" + fileName + "\" does not exist!");
                abort = true;
            };

        }

        // this method compiles class averages for all the different courses
        public void CompileData()
        {
            for (int i = 0; i <= 4; i ++)
                CalculateAverage(lines[i].Split(" "), i);

            foreach (double d in classAverages)
                totalAverage += d;

            totalAverage /= 5;
        }

        // this method compiles class averages of a single course
        private void CalculateAverage(string[] arrIn,int indx)
        {
            double total = 0;
            double numItems = 0;

            for (int i = 0; i <= arrIn.Length - 1; i++)
            {
                if (i == 0 || i == arrIn.Length - 1)
                {
                    continue;
                }
                    total += int.Parse(arrIn[i]);
                    numItems += 1;                
            }

            classAverages[indx] = total / numItems;
        }
    }
}
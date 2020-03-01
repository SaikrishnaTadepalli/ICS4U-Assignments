/************************************************************
    PROGRAMME	: ASSN01: Class Average Competition	

    OUTLINE		:	This class is for outputs of the program. 
                    It handels the displayed data to the console
                    as well as the "Result.txt" text file.

    PROGRAMMER	:	Saikrishna Tadepalli

    DATE		:	October 10th 2019
************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TadepalliS_ASSN01
{
    class Display
    {
        public static School schoolOne;
        public static School schoolTwo;
        public static string nameOne;
        public static string nameTwo;
        private static string output = "";

        // this method initializes the display object
        public Display(School schOne, School schTwo, string schoolOneName, string schoolTwoName)
        {
            schoolOne = schOne;
            schoolTwo = schTwo;
            nameOne = schoolOneName;
            nameTwo = schoolTwoName;
        }

        // this method displays data to the console and the output "Results.txt" file
        public void DisplayData()
        {
            Console.Title = ("ASSN01: Class Average Competition");
            Console.ForegroundColor = ConsoleColor.Gray;

            string[] subject = { "CSE", "ENG", "HIS", "MTH", "PHY" };

            Display.output += ("Course No.\tSchool\tCourse Average");
            Display.output += "\n";

            for (int i = 0; i <= 4; i++)
                DisplayAverages(subject[i], schoolOne, schoolTwo, i);

            Display.output += ("\nAverage for " + nameOne + ": " + String.Format("{0:F2}", schoolOne.totalAverage));
            Display.output += ("\nAverage for " + nameTwo + ": " + String.Format("{0:F2}", schoolOne.totalAverage));

            if (schoolOne.totalAverage > schoolTwo.totalAverage)
            {
                Display.output += ("\n\nCongratulations to " + nameOne);
            }
            else if (schoolTwo.totalAverage > schoolOne.totalAverage)
            {
                Display.output += ("\n\nCongratulations to " + nameTwo);
            }
            else
            {
                Display.output += ("\n\nTied Averages!");
            }

            Display.output += ("\nID\t0   10   20   30   40   50   60   70   80   90   100");
            Display.output += ("\n\t|....|....|....|....|....|....|....|....|....|....|");

            for (int i = 0; i <= 4; i++)
                DisplayGraph(subject[i], schoolOne, schoolTwo, i);

            StreamWriter sr = new StreamWriter("Result.txt");
            sr.WriteLine(Display.output);
            sr.Close();

            Console.WriteLine(Display.output);
        }

        // this method displays the averages of a single subject
        static void DisplayAverages(string subject, School one, School two, int indx)
        {
            Display.output +=("\n" + subject + "\t\tSatec\t" + String.Format("{0:F2}", one.classAverages[indx]) + "\n" +
                 "\t\tRHKing\t" + String.Format("{0:F2}", two.classAverages[indx]));
            Display.output += "\n";
        }

        // this method displays the graph of each course
        static void DisplayGraph(string subject, School one, School two, int indx)
        {
            string oneBar = "";
            string twoBar = "";

            oneBar = GenerateBar(one.classAverages[indx], "*");
            twoBar = GenerateBar(two.classAverages[indx], "#");

            Display.output += ( "\n" + subject + "\t" + oneBar + "\n" +
                "\t" + twoBar + "\n");
        }

        // this method generates the bar per course for the graph
        static string GenerateBar(double avg, string barChar)
        {
            int barCount = (((int)(avg))-(((int)(avg))%2))/2;
            string output = "";
            for (int i = 0; i <= barCount; i++)
                output += barChar;
            return output;
        }
    }
}
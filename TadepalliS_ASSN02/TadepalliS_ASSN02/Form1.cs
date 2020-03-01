/*************************************************************************************
    PROGRAMME	:	ASSN02 Lucky Numbers

    OUTLINE		:	This programme asks the user to input 7 numbers between 1 and 49 
                    inclusive. It then generates 1 years worth of lucky numbers
                    (for every friday), and compairs the entered numbers with the random 
                    numbers generated. The program lists the matched numbers, if there
                    are any, for every friday until next years date.

    PROGRAMMER	:	Saikrishna Tadepalli

    DATE		:	October 31, 2019
 *************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TadepalliS_ASSN02
{
    public partial class Form1 : Form
    {       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EnableObj(false);
            btnClear.Enabled = false;
            btnClear.Visible = false;
        }

        // This method makes the title, textbox to input numbers, and the button to check numbers enable and visible state to the entered boolean parameter
        private void EnableObj(bool state)
        {
            Control[] ctrls = { lblTitle as Control, txtInput as Control, btnChkNumbers as Control };
            foreach (Control c in ctrls)
                c.Visible = state;
            foreach (Control c in ctrls)
                c.Enabled = state;
        }

        private void btnGenHistory_Click(object sender, EventArgs e)
        {
            StreamWriter SW = new StreamWriter("lotto.txt");
            MessageBox.Show("File lotto.txt created.","ASSN02",MessageBoxButtons.OK, MessageBoxIcon.Information);
            generateLottoNumbers(SW);
            EnableObj(true);
            txtInput.Focus();
            btnGenHistory.Enabled = false;
        }
        
        private void btnChkNumbers_Click(object sender, EventArgs e)
        {
            if (ErrorChecking())
                foreach (String s in System.IO.File.ReadAllLines("lotto.txt"))
                    checkNumbers(s);
            else
                MessageBox.Show("Lotto Numbers not in Correct Format!", "ASSN02", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            txtInput.Focus();
        }

        // This function checks if the user entered 7 unique integers between 1 and 49 inclusive. If so, it returns true, else it retruns false
        private Boolean ErrorChecking()
        {
            string[] entString = txtInput.Text.Trim().Split(Convert.ToChar(" "));

            if (entString.Length == 7)
            {
                int[] entNumbers = new int[7];

                for (int i = 0; i < entNumbers.Length; i++)              
                    if (!(int.TryParse(entString[i], out entNumbers[i])))
                        return false;

                foreach (int i in entNumbers)
                    if (i <= 0 || i > 49)
                        return false;
                
                btnClear.Enabled = true;
                btnClear.Visible = true;
                
                return true;
            }
            return false;
        }

        // This function generates lotto numbers for 1 year and writes them to the file "lotto.txt"
        private void generateLottoNumbers(StreamWriter writer)
        {
            DateTime startDate = DateTime.Today;
            Random rand = new Random();

            while (startDate.DayOfWeek != DayOfWeek.Friday)
                startDate = startDate.AddDays(1);

            for (int i = 0; i < 52; i++)
            {
                string randomNum = "";

                for (int j = 0; j < 7; j++)
                    randomNum += rand.Next(1, 50).ToString("D2") + " ";

                writer.WriteLine((startDate.AddDays(7 * (i)).ToString("MM-dd-yy")) + " " + randomNum.Trim());
            }
            writer.Close();
        }

        // This method checks each line of the string parameter lottoLine with the entered numbers and outputs the matches
        private void checkNumbers(string lottoLine)
        {
            string date = lottoLine.Substring(0, 8);
            string numbers = lottoLine.Substring(9, 20);
            string matches = "";

            string[] inputs = txtInput.Text.Trim().Split(Convert.ToChar(" "));

            for (int i = 0; i < inputs.Length; i++)
                if (numbers.Split(Convert.ToChar(" "))[i] == (int.Parse(inputs[i])).ToString("D2"))
                    matches += (int.Parse(inputs[i])).ToString("D2") + " ";

            string[] row1 = { numbers, matches.Trim() };
            lsvOut.Items.Add(date).SubItems.AddRange(row1);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            EnableObj(false);
            btnGenHistory.Enabled = true;
            btnClear.Enabled = false;
            btnClear.Visible = false;
            lsvOut.Items.Clear();
            txtInput.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}

// This program allows the users to enter repeating numbers and it generates repeating numbers (because the document dosnt specify to disable repeating numbers ). 
// The comments below detail how to prevent or enable repeated inputs and repeated numbers generated. 

/*this following code preverts the users from entering repeating numbers, enter the following at line 83 to implement:
  
                for (int i = 0; i < entNumbers.Length; i++)
                    for (int j = i + 1; j < entNumbers.Length; j++)
                        if (entNumbers[i] == entNumbers[j]) 
                            return false;

 * To enable users to enter repeating numbers, remove the code snippet above from the source code. 

 */

/* this following code preverts repeating numbers from being generated, replace lines (106-107) with the following to implement:
 
            for (int j = 0; j < 7; j++)
            {
                    bool repeat = true;
                    int num = 0;

                    do
                    {
                         num = rand.Next(1, 50);

                        for (int k = 0; k < randomNum.Length; k++)
                            for (int l = k + 1; l < randomNum.Length; l++)
                                if (!(randomNum[k] == randomNum[l]))
                                    repeat = false;
                    } while (repeat);

                    randomNum += num.ToString("D2") + " ";
             }

* Alternativly, to enable repeated numbers to be generated, enter the following at line 106 to impliment:

                    for (int j = 0; j < 7; j++)
                        randomNum += rand.Next(1, 50).ToString("D2") + " ";
 */
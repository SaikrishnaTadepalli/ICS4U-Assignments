/*****************************************************************
    PROGRAMME	:	ASSN03 Card Shuffle

    OUTLINE		:	This class is for each card. It stores each
                    card's face and suit value. It allows for 
                    an instance's name to be recieved by any call, 
                    and an instance's corresponding image to be
                    recieved by any call.

    PROGRAMMER	:	Saikrishna Tadepalli

    DATE		:   January 6th 2020
*****************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TadepalliS_ASSN03
{
    class Card
    {
        private string face;
        private string suit;

        public Card(string faceVal, string suitVal)
        {
            face = faceVal;
            suit = suitVal;
        }

        public override string ToString()
        {
            string output = face + " Of " + suit;
            //output = output.PadRight(17, Convert.ToChar(" "));
            return output;
        }

        public Image CardImage()
        {
            Image img = (Image)Properties.Resources.ResourceManager.GetObject(face + "Of" + suit);
            return img;
        }
    }
}

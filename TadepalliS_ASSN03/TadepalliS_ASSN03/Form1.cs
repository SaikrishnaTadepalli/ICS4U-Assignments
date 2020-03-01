/*****************************************************************
    PROGRAMME	:	ASSN03 Card Shuffle

    OUTLINE		:	This program simulates a deck of cards and shuffles
                    them into a random order. The shuffled deck is
                    displayed in a listbox. The user can click a 
                    button named cards to display the shuffled
                    card's images. This program has 1 DeckOfCards
                    object.

    PROGRAMMER	:	Saikrishna Tadepalli

    DATE		:   January 6th 2020
*****************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TadepalliS_ASSN03
{
    public partial class frmMain : Form
    {
        PictureBox[,] picCol = new PictureBox[13, 4];
        DeckOfCards cardDeck = new DeckOfCards();
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            CreateListBox();
            CreatePicBoxes();
        }

        private void CreateListBox()
        {
            lstOut = new ListBox();

            this.Controls.Add(lstOut);

            lstOut.Font = new Font("Verdana", 12, FontStyle.Bold);
            lstOut.Size = new Size(765, 238);
            lstOut.Location = new Point(14, 50);
            lstOut.BackColor = Color.LightCoral;
            lstOut.Visible = false;

            this.Refresh();
        }

        private void CreatePicBoxes()
        {
            Point picLoc = new Point(15, 14);
            Size picSize = new Size(55,90);
            int gap = 4;

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    picCol[i,j] = new PictureBox();

                    this.Controls.Add(picCol[i, j]);

                    picCol[i, j].BorderStyle = BorderStyle.FixedSingle;
                    picCol[i, j].Location = picLoc;
                    picCol[i, j].Size = picSize;
                    picCol[i, j].BackColor = Color.LightCoral;
                    picCol[i, j].Visible = false;
                    picLoc.Y += picSize.Height + gap;
                    picCol[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    
                    this.Refresh();
                }
                picLoc.Y = 14;
                picLoc.X += picSize.Width + gap;
            }
        }

        private void ShowList()
        {
            for (int i = 0; i < 13; i++)
                for (int j = 0; j < 4; j++)
                    picCol[i, j].Visible = false;;

            lstOut.Visible = true;
            btnShow.Text = "Cards";
            btnShuffle.Enabled = true;
        }

        private void ShowCards()
        {
            lstOut.Visible = false;

            for (int i = 0; i < 13; i++)
                for (int j = 0; j < 4; j++)
                    picCol[i, j].Visible = true;

            btnShow.Text = "List";
            btnShuffle.Enabled = false;
        }

        private void AssignShuffle()
        {
            lstOut.Items.Clear();
            string output = "";

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    output += cardDeck.deck[j + 4 * i].ToString() + "\t";
                }
                lstOut.Items.Add(output);
                output = "";
            }
            this.Refresh();

            for (int i = 0; i < 13; i++)
                for (int j = 0; j < 4; j++)
                    picCol[i, j].Image = cardDeck.deck[j + 4 * i].CardImage();

        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            cardDeck.Shuffle();
            AssignShuffle();

            ShowList();

            btnShow.Enabled = true;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (btnShow.Text == "Cards")
                ShowCards();
            else if (btnShow.Text == "List")
                ShowList();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

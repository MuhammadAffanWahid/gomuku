using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomuko
{
    enum Player { Blue,Red}
    public partial class Gomuku : Form
    {
        Cell[,] Cs;
        int dimension,win, wincount;
        Player Turn = Player.Blue;
        Color C;
        public Gomuku()
        {
            InitializeComponent();
        }

        void LoadCells()
        {
            Cs = new Cell[dimension, dimension];
            CellsPanel.Controls.Clear();
            Cell B;
            for(int ri=0;ri<dimension;ri++)
            {
                for (int ci = 0; ci < dimension; ci++)
                {
                    B = new Cell(CellsPanel.Width / dimension-10,CellsPanel.Height / dimension-10);
                    B.Click += new System.EventHandler(this.Cell_Click);
                    CellsPanel.Controls.Add(B);
                    Cs[ri,ci] = B;
                }
            }
        }

       
 
             bool IsWinHorizontal(int ri,int ci,Color C)
        {
           // int Count = 0;
            if (ci + win > dimension)
                return false;
            for(int i=0;i<win;i++)
            {
                if(  Cs[ri,ci+i].BackColor!= C)
                {
                    return false;
                }
            }
            return true;
        }
        bool IsWinVertical(int ri, int ci, Color C)
        {
            if (ri + win > dimension)
                return false;
            for (int i = 0; i < win; i++)
            {
                if (Cs[ri+i, ci ].BackColor != C)
                {
                    return false;
                }
            }
            return true;
        }


        bool IsWinDL2R(int ri, int ci, Color C)
        {
            if (ri - win +1< 0 || ci + win > dimension)
                return false;
           // MessageBox.Show(ri.ToString() + ci.ToString());
            for (int i = 0; i < win; i++)
            {
                if (Cs[ri - i, ci + i].BackColor != C)
                {
                    return false;
                }
            }
            return true;
        }
        
        bool IsWinDR2L(int ri, int ci, Color C)
        {
            if (ci + win > dimension || ri + win > dimension)
                return false;
            for (int i = 0; i < win; i++)
            {
                if (Cs[ri+i, ci + i].BackColor != C)
                {
                    return false;
                }
            }
            return true;
        }
            
        bool IsWin(Player Turn)
        {
            if (Turn == Player.Blue)
            {
                C = Color.Blue;
            }
            else
            {
                C = Color.Red;
            }
            for(int ri=0;ri<dimension;ri++)
            {
                for(int ci=0; ci<dimension;ci++)
                {
                    if(IsWinPoint(ri, ci, C))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        bool IsWinPoint(int ri, int ci, Color C)
        {
            return (IsWinHorizontal(ri, ci, C) || IsWinVertical(ri, ci, C) || IsWinDR2L(ri, ci, C) || IsWinDL2R(ri, ci, C));
        } 
              
              
              
   

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        void TurnChange()
        {
            if(Turn==Player.Blue)
            {
                Turn=Player.Red;
            }
            else
            {
                Turn=Player.Blue;
            }
        }
        private void Cell_Click(object sender, EventArgs e)
        {
            Cell B = (Cell)sender;
            if (B.occupy == true)
            {
                MessageBox.Show("Bhai Ghalat Harkat Na Karo");
                return;
            }
                if(Turn==Player.Blue)
            {
                B.BackColor = Color.Blue;
            }
            else if(Turn == Player.Red)
            {
                B.BackColor = Color.Red;
            }
                B.occupy = true;
            if(IsWin(Turn))
            {
                MessageBox.Show(Turn.ToString()+" has won the match");
                CellsPanel.Controls.Clear();
               Box1.Text = "Replay.....!!!";
              //  MessageBox.Show(" Do you want to replay?");
                 button2_Click(sender,e);
            }
            TurnChange();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
                dimension = 3;
            else if (radioButton2.Checked)
                dimension = 5;
            else if(radioButton3.Checked)
                dimension = 10;
            else if (radioButton4.Checked)
                dimension = 15;

            if (dimension == 0)
            {
                MessageBox.Show("Please Select an option!!!");
            }
            else
            {
                if (Box1.Text != "Replay.....!!!")
                {
                    win = Int32.Parse(Box1.Text);

                    if (win <= 0 || win > dimension)
                    {
                        MessageBox.Show("Please Select Valid WinCount!!!");
                        Box1.Text = "";
                        return;
                    }
                    else
                    {
                        wincount = win;
                    }
                }
                else
                {
                    Box1.Text = win.ToString();
                }
                LoadCells();
            }

        }

        private void Gomuku_Load(object sender, EventArgs e)
        {

        }
    }
}

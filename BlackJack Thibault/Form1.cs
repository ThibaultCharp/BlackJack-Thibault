using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack_Thibault
{
    public partial class Form1 : Form
    {
        Random cardGenerator = new Random();
        int sumPlayerCards = 0;
        int sumPCCards = 0;
        int[] PlayerCards = new int[6];
        int[] PCCards = new int[6];
        
        int countPlayer = 0;
        int i = 0;
        int j = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            i = 0;
            sumPlayerCards = 0;

            PlayerCards[0] = cardGenerator.Next(1, 11);
            i++;
            PlayerCards[1] = cardGenerator.Next(1, 11);
            PCCards[0] = cardGenerator.Next(1, 11);

            for (i = 0; i < PlayerCards.Length; i++)
            {
                sumPlayerCards += PlayerCards[i];
            }

            TotalYou.Text = (sumPlayerCards.ToString());

            labelPC1.Text = PCCards[0].ToString();
            labelYou1.Text = PlayerCards[0].ToString();
            labelPC2.Text = ("Hidden");
            labelYou2.Text = PlayerCards[1].ToString();
        }

        private void Hit_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            countPlayer++;
            sumPlayerCards = 0;

            if (countPlayer == 1)
            {
                PlayerCards[2] = cardGenerator.Next(1, 11);
                labelYou3.Text = PlayerCards[2].ToString();
            }

            if (countPlayer == 2)
            {
                PlayerCards[3] = cardGenerator.Next(1, 11);
                labelYou4.Text = PlayerCards[3].ToString();
            }

            if (countPlayer == 3)
            {
                PlayerCards[4] = cardGenerator.Next(1, 11);
                labelYou5.Text = PlayerCards[4].ToString();
            }

            if (countPlayer == 4)
            {
                PlayerCards[5] = cardGenerator.Next(1, 11);
                labelYou6.Text = PlayerCards[5].ToString();
            }

            if (countPlayer == 5)
            {
                PlayerCards[6] = cardGenerator.Next(1, 11);
                labelYou7.Text = PlayerCards[6].ToString();
            }

            for (int i = 0; i < PlayerCards.Length; i++)
            {
                sumPlayerCards += PlayerCards[i];
            }

            TotalYou.Text = (sumPlayerCards.ToString());

            if (sumPlayerCards > 21)
            {
                labelResult.Text = ("Busted");
            }
        }
        private void Stand_Click(object sender, EventArgs e)
        {
            Hit.Enabled = false;
            PCCards[1] = cardGenerator.Next(1, 11);
            for (j = 0; j < PCCards.Length; j++)
            {
                sumPCCards += PCCards[j];
            }

            if(sumPCCards < 17)
            {
                PCCards[2] = cardGenerator.Next(1, 11);
                sumPCCards = sumPCCards + PCCards[2];
                if (sumPCCards < 17)
                {
                    PCCards[3] = cardGenerator.Next(1, 11);
                    sumPCCards = sumPCCards + PCCards[3];
                    if (sumPCCards < 17)
                    {
                        PCCards[4] = cardGenerator.Next(1, 11);
                        sumPCCards = sumPCCards + PCCards[4];
                        if (sumPCCards < 17)
                        {
                            PCCards[5] = cardGenerator.Next(1, 11);
                            sumPCCards = sumPCCards + PCCards[5];
                            if (sumPCCards < 17)
                            {
                                PCCards[6] = cardGenerator.Next(1, 11);
                                sumPCCards = sumPCCards + PCCards[6];
                                if (sumPCCards < 17)
                                {
                                    PCCards[7] = cardGenerator.Next(1, 11);
                                    sumPCCards = sumPCCards + PCCards[7];
                                }
                                else if (sumPCCards <= 21)
                                {
                                    labelPC2.Text = PCCards[1].ToString();
                                    labelPC3.Text = PCCards[2].ToString();
                                    labelPC4.Text = PCCards[3].ToString();
                                    labelPC5.Text = PCCards[4].ToString();
                                    labelPC6.Text = PCCards[5].ToString();
                                    labelPC7.Text = PCCards[6].ToString();
                                    TotalPC.Text = (sumPCCards.ToString());
                                    Result(sumPCCards, sumPlayerCards);
                                }
                            }
                            else if (sumPCCards <= 21)
                            {
                                labelPC2.Text = PCCards[1].ToString();
                                labelPC3.Text = PCCards[2].ToString();
                                labelPC4.Text = PCCards[3].ToString();
                                labelPC5.Text = PCCards[4].ToString();
                                labelPC6.Text = PCCards[5].ToString();
                                TotalPC.Text = (sumPCCards.ToString());
                                Result(sumPCCards, sumPlayerCards);
                            }
                        }
                        else if (sumPCCards <= 21)
                        {
                            labelPC2.Text = PCCards[1].ToString();
                            labelPC3.Text = PCCards[2].ToString();
                            labelPC4.Text = PCCards[3].ToString();
                            labelPC5.Text = PCCards[4].ToString();
                            TotalPC.Text = (sumPCCards.ToString());
                            Result(sumPCCards, sumPlayerCards);
                        }
                    }
                    else if (sumPCCards <= 21)
                    {
                        labelPC2.Text = PCCards[1].ToString();
                        labelPC3.Text = PCCards[2].ToString();
                        labelPC4.Text = PCCards[3].ToString();
                        TotalPC.Text = (sumPCCards.ToString());
                        Result(sumPCCards, sumPlayerCards);
                    }
                }
                else if (sumPCCards <= 21)
                {
                    labelPC2.Text = PCCards[1].ToString();
                    labelPC3.Text = PCCards[2].ToString();
                    TotalPC.Text = (sumPCCards.ToString());
                    Result(sumPCCards, sumPlayerCards);
                }
            }
            else if (sumPCCards <= 21)
            {
                labelPC2.Text = PCCards[1].ToString();
                TotalPC.Text = (sumPCCards.ToString());
                Result(sumPCCards, sumPlayerCards);
            }
            if (sumPCCards > 21)
            {
                labelResult.Text = ("Dealer Busted, You Win");
                labelPC2.Text = PCCards[1].ToString();
                labelPC3.Text = PCCards[2].ToString();
                labelPC4.Text = PCCards[3].ToString();
                labelPC5.Text = PCCards[4].ToString();
                labelPC6.Text = PCCards[5].ToString();
                if (PCCards.Length > 6)
                {
                    labelPC7.Text = PCCards[6].ToString();
                }
            }
        }
        private void Result(int sumPCCards, int sumPlayerCards)
        {
            if (sumPCCards > sumPlayerCards)
            {
                labelResult.Text = ("You Lose");
            }
            else if (sumPCCards < sumPlayerCards)
            {
                labelResult.Text = ("You Win");
            }
            else
            {
                labelResult.Text = ("Draw");
            }
        }
        private void reset_Click_1(object sender, EventArgs e)
        {
            labelPC1.Text = ("");
            labelPC2.Text = ("");
            labelPC3.Text = ("");
            labelPC4.Text = ("");
            labelPC5.Text = ("");
            labelPC6.Text = ("");
            labelPC7.Text = ("");
            labelYou1.Text = ("");
            labelYou2.Text = ("");
            labelYou3.Text = ("");
            labelYou4.Text = ("");
            labelYou5.Text = ("");
            labelYou6.Text = ("");
            labelYou7.Text = ("");
            TotalPC.Text = ("");
            TotalYou.Text = ("");
            PlayerCards = new int[6];
            PCCards = new int[6];
            countPlayer = 0;
            sumPCCards = 0;
            sumPlayerCards = 0;
            Hit.Enabled = true;
            button1.Enabled = true;
            labelResult.Text = ("");
        }
    }
}
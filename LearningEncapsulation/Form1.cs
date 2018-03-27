using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningEncapsulation
{
    public partial class Form1 : Form
    {
        DinnerParty dinnerParty;
        //there is a bug, because our field CostOfDecorations from time to time got old values and i know that. That was purpose of the task to find why my calculator sometimes show bad values.
        //not going to fix it here, because im gonna learn about it in next task.
        public Form1()
        {
            InitializeComponent();
            dinnerParty = new DinnerParty() { NumberOfPeople = 5 };           
            dinnerParty.SetHealthyOption(false);
            dinnerParty.CalculateCostOfDecorations(true);
            DisplayDinnerPartyCost();

        }
        private void DisplayDinnerPartyCost()
        {
            decimal Cost = dinnerParty.CalculateCost(healthyBox.Checked);
            totalCostLabel.Text = Cost.ToString("c");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dinnerParty.NumberOfPeople = (int)numericUpDown1.Value;
            DisplayDinnerPartyCost();
        }

        private void healthyBox_CheckedChanged(object sender, EventArgs e)
        {

            if (healthyBox.Checked == true)
            {
                dinnerParty.SetHealthyOption(true);
            }
            else
            {
                dinnerParty.SetHealthyOption(false);
            }

            DisplayDinnerPartyCost();
        }

        private void fancyBox_CheckedChanged(object sender, EventArgs e)
        {

            if (fancyBox.Checked == true)
            {
                dinnerParty.CalculateCostOfDecorations(true);
            }
            else
            {
                dinnerParty.CalculateCostOfDecorations(false);
            }

            DisplayDinnerPartyCost();
        }
    }
}

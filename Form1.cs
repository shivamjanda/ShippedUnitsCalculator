// HEADER
// Author: Shivam Janda
// Date: January 26th, 2022
// Description: This is a win form application to calculate the Average Unit Shipped by taking in 7 ( 7 days) whole number entries of units with proper validation and displayed by clicking
//              enter. Once 7 entires are made, the application will calculate the average units shipped and display it (rounded to 2 decimal places). The form also gives you a reset and exit 
//              button.          
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShippedUnitsCalculator
{
    public partial class formUnitsShipped : Form
    {
        int dayCounter = 1;
        int units;
        double sumOfUnits = 0;
        public formUnitsShipped()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Closes the form
        /// </summary>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Resets all controls to its deafult values, set the day counter to 1 and focuses on the UnitInput textbox.
        /// </summary>
        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxUnitEntries.Clear();
            textBoxUnitInput.Clear();
            labelAverageOutput.Text = string.Empty;
            dayCounter = 1;
            labelDays.Text = "Day 1";
            textBoxUnitInput.ReadOnly = false;
            textBoxUnitInput.Focus();
            buttonEnter.Enabled = true;
            labelAverageOutput.Text = "";
        }
        /// <summary>
        /// Checks for proper validation of the unites entered and displays it accordingly. Once 7 entries are entered, display the average output in the label output.
        /// </summary>
       
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxUnitInput.Text, out units)) // check if the entry is a integer (whole number)
            {
                if (units > 0 && units < 5000) // check if the entries are between 0 and  5000
                {
                    sumOfUnits = sumOfUnits + units;
                    textBoxUnitEntries.Text = textBoxUnitEntries.Text + textBoxUnitInput.Text + "\r\n"; // display in the multiline textbox
                    textBoxUnitInput.Clear();
                    dayCounter++; // increment and update the counter for days
                    labelDays.Text = "Day " + dayCounter;

                    if (dayCounter == 8) // once the counter is equal to zero then disable the enter button and the unit input textbox.
                    {
                        labelDays.Text = "Day 7";
                        textBoxUnitInput.Clear();
                        textBoxUnitInput.ReadOnly = true;
                        buttonEnter.Enabled = false;
                        labelAverageOutput.Focus();
                        labelAverageOutput.Text = "Average per day: " + Math.Round((sumOfUnits / 7), 2); // Display the average units shipped rounded to two decimal places

                    }

                }
                else
                {
                    textBoxUnitInput.Focus();
                }
            }
            else
            {
                textBoxUnitInput.Focus();
            }

          
        }
        private void labelAverageOutput_Click(object sender, EventArgs e)
        {
        }
    }
}

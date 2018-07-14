using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace luckynumber
{
    public partial class Form1 : Form
    {
        Form1 form1;
        const int LIMIT = 6;
        int[] lotNums = new int[LIMIT];

        Random randomNum = new Random();

        public Form1()
        {
            InitializeComponent();
            buttonShowNum.Focus();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.DialogResult result;
            result = MessageBox.Show("Sei sicuro?", "Uscita",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
                this.Close();
            else
                this.buttonShowNum.Focus();
        }

        private void buttonShowNum_Click(object sender, EventArgs e)
        {
            toStringNums();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toStringNums();

            form1 = new Form1();
            form1.KeyDown += new KeyEventHandler(form_KeyDown);
        }

        private void ramdomGen()
        {
            List<int> numbers = new List<int>();

            int temp;
            for (int value = 0; value < lotNums.Length; value++)
            {
                do //creates the #s
                {
                    temp = randomNum.Next(1, 90);
                } while (numbers.Contains(temp)); 
                numbers.Add(temp);
            }

            for (int index = 0; index < lotNums.Length; index++)
            {
                lotNums[index] = numbers[index];
            }

        }

        private void form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.S)
            {
                toStringNums();

                e.SuppressKeyPress = true;
            }
        }

        private void toStringNums()
        {
            string displayNum = null;
            ramdomGen();

            Array.Sort(lotNums);
            for (int index = 0; index < lotNums.Length; index++)
                displayNum += lotNums[index] + "   ";

            textBoxNumbersDisplay.Text = displayNum;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
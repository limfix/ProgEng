using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = DateTime.Now.ToShortDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int currentYear = DateTime.Now.Year;
                int enteredYear = Convert.ToInt32(textBox1.Text);
                if (enteredYear < 0)
                {
                    errorProvider1.SetError(textBox1, "Введите целочисленное значение больше 0.");
                }
                else
                {
                    int countMsg = Convert.ToInt32(numericUpDown2.Value);
                    for (int i = 0; i < countMsg; i++)
                    {
                        string yearMessage = System.String.Format("Вам будет 100 лет в {0} году", Convert.ToString(100 - enteredYear + currentYear));
                        MessageBox.Show(yearMessage);
                    }
                    // Clear the error.  
                    errorProvider1.SetError(textBox1, "");
                }
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox1, "Введите целочисленное значение больше 0.");
                // additionally, if you wantto prevent user leaving textbox 
                // until he satisfies condition. uncomment below.
                // e.handled = true; 
            }
            
            
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int boxNumber = Convert.ToInt32(textBox3.Text);
                if (boxNumber % 4 == 0)
                {
                    label6.Text = "Делится на 4";
                }
                else
                {
                    label6.Text = "-";
                }
                if (boxNumber % 2 == 0)
                {
                    label5.Text = "Четное";
                }
                else
                {
                    label5.Text = "Нечётное";
                }
            }
            catch
            {
                errorProvider1.SetError(textBox3, "Введите целочисленное значение больше 0.");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int divNumber = Convert.ToInt32(textBox4.Text);
                for (int i = 1; i <= divNumber; i++)
                {
                    if (divNumber % i == 0)
                    {
                        listBox1.Items.Add(i);
                    }
                }
            }
            catch
            {
                errorProvider1.SetError(textBox4, "Введите целочисленное значение больше 0.");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string password = "";
            int passwordLength = Convert.ToInt32(numericUpDown1.Value);
            Random rand = new Random();

            string cLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lLetters = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";
            string underscore = "_";
            string specialChar = "!@#$%^&*()=_";

            password += cLetters[rand.Next(cLetters.Length)];
            password += lLetters[rand.Next(lLetters.Length)];
            password += numbers[rand.Next(numbers.Length)];
            password += underscore;
            password += specialChar[rand.Next(specialChar.Length)];

            for (byte i = 0; i < passwordLength - 5; i++)
            {
                int randomChoise = rand.Next(1,4);
                switch (randomChoise)
                {
                    case 1:
                        password += cLetters[rand.Next(cLetters.Length)];
                        break;
                    case 2:
                        password += lLetters[rand.Next(lLetters.Length)];
                        break;
                    case 3:
                        password += numbers[rand.Next(numbers.Length)];
                        break;
                    case 4:
                        password += specialChar[rand.Next(specialChar.Length)];
                        break;
                }
            }

            char[] aPassword = password.ToCharArray();
            for (int i = 0; i < password.Length; i++)
            {
                char temp = aPassword[i];
                int randomIndex = rand.Next(i, password.Length);
                aPassword[i] = aPassword[randomIndex];
                aPassword[randomIndex] = temp;
            }
            password = new string(aPassword);
            textBox5.Text = password;
            // Как узнать какое из условий истинно если их несколько при одном операторе if
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class form1 : Form
    {
        
        Random randomizer = new Random();

         
        int addend1;
        int addend2;

         
        int minuend;
        int subtrahend;

      
        int multiplicand;
        int multiplier;

         
        int dividend;
        int divisor;

        
        int timeLeft;

    
        public void StartTheQuiz()
        {
            
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            
            sum.Value = 0;

           
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

         
            divisor = randomizer.Next(2, 11);                   /* В делитель задаётсяс случайное число от 1 до 10 */
            int temporaryQuotient = randomizer.Next(2, 11);     /* Временная переменная, случайное число от 1 до 10 */
            dividend = divisor * temporaryQuotient;             /* Делимому присваевается произведение делителя на временную переменную */
            dividedLeftLabel.Text = dividend.ToString();        /* В левый лэйбэл записывается делимое */
            dividedRightLabel.Text = divisor.ToString();        /* В правый лэйбэл записывается делитель */
            quotient.Value = 0; 

            
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();

         

        }
 
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        public form1()
        {
            InitializeComponent();
        }
            private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timeLable_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void form1_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
            
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
               
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
            if (timeLeft <= 5)
                timeLabel.BackColor = Color.Red;
            else
                timeLabel.BackColor = Color.White;
        }

        private void lable9_Click(object sender, EventArgs e)
        {

        }

        private void answer_Enter(object sender, EventArgs e)
        {
            
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
        private void новаяИграToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

    }
}

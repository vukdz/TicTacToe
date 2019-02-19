using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int i = 1;
        int p1s = 0;
        int p2s = 0;
        public int[,] btnValue = new int[3, 3];

        public void btnClick(object sender, EventArgs e)
        {
            Button button = (Button) sender;
            button.Font = new Font(button.Font.FontFamily, 40);
            if (i == 1)
            {
                button.Text = "X";
                button.Enabled = false;
                i--;
            }
            else
            {
                button.Text = "O";
                button.Enabled = false;
                i++;
            }
            checkDiagonal();
            checkHorizontal();
            checkVertical();
        }

        private void checkDiagonal()
        {
            if (button1.Text == "X" && button5.Text == "X" && button9.Text == "X" ||
                button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                p1s++;
                textBox1.Text = p1s.ToString();
                MessageBox.Show(label1.Text + " wins!", "Congratulations!");
                newGame();
            }

            if (button1.Text == "O" && button5.Text == "O" && button9.Text == "O" ||
                button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {
                p2s++;
                textBox2.Text = p2s.ToString();
                MessageBox.Show(label2.Text + " wins", "Congratulations!");
                newGame();
            }
        }

        private void checkHorizontal()
        {
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X" ||
                button4.Text == "X" && button5.Text == "X" && button6.Text == "X" ||
                button7.Text == "X" && button8.Text == "X" && button9.Text == "X")
            {
                p1s++;
                textBox1.Text = p1s.ToString();
                MessageBox.Show(label1.Text + " wins", "Congratulations!");
                newGame();
            }

            if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O" ||
                button4.Text == "O" && button5.Text == "O" && button6.Text == "O" ||
                button7.Text == "O" && button8.Text == "O" && button9.Text == "O")
            {
                p2s++;
                textBox2.Text = p2s.ToString();
                MessageBox.Show(label2.Text + " wins", "Congratulations!");
                newGame();
            }
        }

        private void checkVertical()
        {
            if (button1.Text == "X" && button4.Text == "X" && button7.Text == "X" ||
                button2.Text == "X" && button5.Text == "X" && button8.Text == "X" ||
                button3.Text == "X" && button6.Text == "X" && button9.Text == "X")
            {
                p1s++;
                textBox1.Text = p1s.ToString();
                MessageBox.Show(label1.Text + " wins", "Congratulations!");
                newGame();
            }

            if (button1.Text == "O" && button4.Text == "O" && button7.Text == "O" ||
                button2.Text == "O" && button5.Text == "O" && button8.Text == "O" ||
                button3.Text == "O" && button6.Text == "O" && button9.Text == "O")
            {
                p2s++;
                textBox2.Text = p2s.ToString();
                MessageBox.Show(label2.Text + " wins", "Congratulations!");
                newGame();
            }
        }

        private void newGame()
        {
            i = 1;
            
            foreach (var btn in GetAll(this, typeof(Button)))
            {               
                btn.Text = "";
                btn.Enabled = true;
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    btnValue[i, j] = 0;
                }
            }
        }       

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newGame();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        private void resetScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p1s = 0;
            p2s = 0;
            textBox1.Text = p1s.ToString();
            textBox2.Text = p2s.ToString();
        }

        private void player1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = (string)label1.Text;
            P1chName F = new P1chName(name);
            F.ShowDialog(this);
            label1.Text = F.name;
        }

        private void player2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = (string)label1.Text;
            P2chName F = new P2chName(name);
            F.ShowDialog(this);
            label2.Text = F.name;
        }
    }
}

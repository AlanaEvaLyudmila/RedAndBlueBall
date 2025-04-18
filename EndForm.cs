using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedAndBlueBall
{
    public partial class EndForm : Form
    {
        int score;
        public EndForm(int finalscore)
        {
            InitializeComponent();
            labelScore.Text = $"Вы получили {finalscore} очков";
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            score = 0;
            Form1 gameForm = new Form1();
            gameForm.Show();
            this.Close();
        }

        private void EndForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

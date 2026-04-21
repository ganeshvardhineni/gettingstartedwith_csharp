using System;
using System.Windows.Forms;

namespace StopWatchApp
{
    public partial class Form1 : Form
    {
        int hours = 0;
        int minutes = 0;
        int seconds = 0;

        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();

            // Timer setup
            timer1.Interval = 1000; // 1 second
            timer1.Tick += timer1_Tick;

            // Initial UI setup
            label1.Text = "00:00:00";

            button1.Text = "Start";
            button2.Text = "Stop";
            button3.Text = "Reset";
            button4.Text = "Save";
        }

        // TIMER LOGIC
        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds++;

            if (seconds == 60)
            {
                seconds = 0;
                minutes++;
            }

            if (minutes == 60)
            {
                minutes = 0;
                hours++;
            }

            label1.Text = hours.ToString("00") + ":" +
                          minutes.ToString("00") + ":" +
                          seconds.ToString("00");
        }

        // START BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        // STOP BUTTON
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        // RESET BUTTON
        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            hours = 0;
            minutes = 0;
            seconds = 0;

            label1.Text = "00:00:00";
        }

        // SAVE / LAP BUTTON
        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(label1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
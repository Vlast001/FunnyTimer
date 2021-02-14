using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunnyTimer
{
    public partial class Form1 : Form
    {
        private TimeSpan totalTime;
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            totalTime = new TimeSpan(0, 0, 0, 20);

            label1.Text = $"Время до самоуничтожени: {totalTime}";
            string soundPath = Path.GetFullPath(@"..\..\Sounds\Sound.mp3");
            player.URL = soundPath;
            player.Ctlcontrols.play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            totalTime = totalTime.Subtract(new TimeSpan(0, 0, 0, 1));

            label1.Text = $"Время до самоуничтожения: {totalTime}";

            if (totalTime.Seconds == 0)
            {
                player.Ctlcontrols.stop();
                timer1.Stop();
                Application.Exit();
            }
        }
    }
}

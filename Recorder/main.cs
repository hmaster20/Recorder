using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recorder
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();

            btnPlay.Enabled = true;
            btnRec.Enabled = true;
            btnStop.Enabled = false;

            timer.Tick += Timer_Tick;
            info.Text = "00:00:00.0";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = sWatch.Elapsed;
            info.Text = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

        }

        Stopwatch sWatch = new Stopwatch();

        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int record(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);


        public void Button1_Click(System.Object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FileName.Text))
            {
                record("open new Type waveaudio Alias recsound", "", 0, 0);
                record("record recsound", "", 0, 0);

                btnPlay.Enabled = false;
                btnRec.Enabled = false;
                btnStop.Enabled = true;

                FileName.Enabled = false;

                sWatch.Restart();
                timer.Start();
            }
            else
            {
                return;
            }
        }

        public void Button2_Click(System.Object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FileName.Text))
            {
                //record("save recsound c:\\mic.wav", "", 0, 0);
                record("save recsound " + FileName.Text, "", 0, 0);
                record("close recsound", "", 0, 0);

                sWatch.Stop();
                timer.Stop();
            }
            else
            {
                return;
            }

            FileName.Enabled = true;

            btnPlay.Enabled = true;
            btnRec.Enabled = true;
            btnStop.Enabled = false;
        }

        public void Button3_Click(System.Object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FileName.Text))
            {
                (new Microsoft.VisualBasic.Devices.Audio()).Play(FileName.Text);
            }
        }

        private void browse_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = @"wav files|*.wav",
                Title = @"Сохранить файл как",
                DefaultExt = "wav",
                OverwritePrompt = false
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileName.Text = saveFileDialog.FileName;
            }
        }


        //#region Default Instance
        //private static Form1 defaultInstance;
        //public static Form1 Default
        //{
        //    get
        //    {
        //        if (defaultInstance == null)
        //        {
        //            defaultInstance = new Form1();
        //            defaultInstance.FormClosed += new FormClosedEventHandler(defaultInstance_FormClosed);
        //        }
        //        return defaultInstance;
        //    }
        //}

        //static void defaultInstance_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    defaultInstance = null;
        //}
        //#endregion
    }
}

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WindowsApplication2;

namespace Recorder
{
    public partial class main : Form
    {
        private Stopwatch sWatch = new Stopwatch();

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

        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int record(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

        [DllImport("winmm.DLL", EntryPoint = "PlaySound", SetLastError = true, CharSet = CharSet.Unicode, ThrowOnUnmappableChar = true)]
        private static extern bool PlaySound(string szSound, IntPtr hMod, PlaySoundFlags flags);

        [Flags]
        public enum PlaySoundFlags : int
        {
            SND_SYNC = 0x0000,
            SND_ASYNC = 0x0001,
            SND_NODEFAULT = 0x0002,
            SND_LOOP = 0x0008,
            SND_NOSTOP = 0x0010,
            SND_NOWAIT = 0x00002000,
            SND_FILENAME = 0x00020000,
            SND_RESOURCE = 0x00040004
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

        public void btnRec_Click(System.Object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FileName.Text))
            {
                record("open new Type waveaudio Alias recsound", "", 0, 0);
                record("set capture time format ms bitspersample 16 channels 2 samplespersec 44000 bytespersec 128000 alignment 4", "", 0, 0);
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

        public void BbtnStop_Click(System.Object sender, System.EventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            clsRecDevices recDev = new clsRecDevices();
            for (int i = 0; i < recDev.Count; i++)
            {
                MessageBox.Show(recDev[i]);
            }
        }

        private void btnPlay2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FileName.Text))
            {
                PlaySound(FileName.Text, new System.IntPtr(), PlaySoundFlags.SND_SYNC);
            }

            //OpenFileDialog dialog1 = new OpenFileDialog();

            //dialog1.Title = "Browse to find sound file to play";
            //dialog1.InitialDirectory = @"c:\";
            //dialog1.Filter = "Wav Files (*.wav)|*.wav";
            //dialog1.FilterIndex = 2;
            //dialog1.RestoreDirectory = true;

            //if (dialog1.ShowDialog() == DialogResult.OK)
            //{
            //    textBox1.Text = dialog1.FileName;
            //    PlaySound(dialog1.FileName, new System.IntPtr(), PlaySoundFlags.SND_SYNC);
            //}
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
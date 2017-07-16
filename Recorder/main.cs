using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int record(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);


        public void Button1_Click(System.Object sender, System.EventArgs e)
        {
            record("open new Type waveaudio Alias recsound", "", 0, 0);

            record("record recsound", "", 0, 0);
        }

        public void Button2_Click(System.Object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FileName.Text))
            {
                //record("save recsound c:\\mic.wav", "", 0, 0);
                record("save recsound c:\\mic.wav", "", 0, 0);
                record("close recsound", "", 0, 0);
            }
            else
            {
                return;
            }


        }

        public void Button3_Click(System.Object sender, System.EventArgs e)
        {
            (new Microsoft.VisualBasic.Devices.Audio()).Play("c:\\mic.wav");
        }

        private void browse_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = @"wav files|*.wav",
                Title = @"Сохранить файл как",
                DefaultExt = "wav",
                OverwritePrompt = false


                //Filter = @"mp3 files|*.mp3",
                //Title = @"Save File As",
                //DefaultExt = "mp3",
                //OverwritePrompt = false
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

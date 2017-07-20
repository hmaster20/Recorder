using NAudio.Lame;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecNAudio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public WaveIn waveSource = null;
        public WaveFileWriter waveFile = null;

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FileName.Text))
            {
                StartBtn.Enabled = false;
                StopBtn.Enabled = true;

                waveSource = new WaveIn();

                int sampleRate = 8000; // 8 kHz
                int channels = 1; // mono

                //waveSource.WaveFormat = new WaveFormat(44100, 1);
                waveSource.WaveFormat = new WaveFormat(sampleRate, channels);

                waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);
                waveSource.RecordingStopped += new EventHandler<StoppedEventArgs>(waveSource_RecordingStopped);

                //waveFile = new WaveFileWriter(@"C:\Temp\Test0001.wav", waveSource.WaveFormat);
                waveFile = new WaveFileWriter(FileName.Text, waveSource.WaveFormat);

                waveSource.StartRecording();
            }
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            StopBtn.Enabled = false;

            waveSource.StopRecording();
        }

        void waveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveFile != null)
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }
        }

        void waveSource_RecordingStopped(object sender, StoppedEventArgs e)
        {
            if (waveSource != null)
            {
                waveSource.Dispose();
                waveSource = null;
            }

            if (waveFile != null)
            {
                waveFile.Dispose();
                waveFile = null;
            }

            StartBtn.Enabled = true;
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




        private static void FromStreamToWav()
        {
            string url = "";
            MemoryStream mp3Buffered = new MemoryStream();
            using (var responseStream = WebRequest.Create(url).GetResponse().GetResponseStream())
            {
                byte[] buffer = new byte[65536];
                int bytesRead = responseStream.Read(buffer, 0, buffer.Length);
                while (bytesRead > 0)
                {
                    mp3Buffered.Write(buffer, 0, bytesRead);
                    bytesRead = responseStream.Read(buffer, 0, buffer.Length);
                }
            }

            mp3Buffered.Position = 0;
            using (var mp3Stream = new Mp3FileReader(mp3Buffered))
            {
                WaveFileWriter.CreateWaveFile("file.wav", mp3Stream);
            }
        }

        public static byte[] ConvertWavToMp3(byte[] wavFile)
        {

            using (var retMs = new MemoryStream())
            using (var ms = new MemoryStream(wavFile))
            using (var rdr = new WaveFileReader(ms))
            using (var wtr = new LameMP3FileWriter(retMs, rdr.WaveFormat, 128))
            {
                rdr.CopyTo(wtr);
                return retMs.ToArray();
            }
        }


    }
}

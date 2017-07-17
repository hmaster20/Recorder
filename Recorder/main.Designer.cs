namespace Recorder
{
    partial class main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FileName = new System.Windows.Forms.TextBox();
            this.browse = new System.Windows.Forms.Button();
            this.info = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRec = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.btnPlay2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FileName
            // 
            this.FileName.Location = new System.Drawing.Point(52, 86);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(237, 20);
            this.FileName.TabIndex = 0;
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(295, 85);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(27, 23);
            this.browse.TabIndex = 1;
            this.browse.Text = "...";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // info
            // 
            this.info.Location = new System.Drawing.Point(52, 30);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(270, 18);
            this.info.TabIndex = 2;
            // 
            // btnPlay
            // 
            this.btnPlay.Image = global::Recorder.Properties.Resources.play;
            this.btnPlay.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPlay.Location = new System.Drawing.Point(214, 57);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 3;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.Button3_Click);
            // 
            // btnStop
            // 
            this.btnStop.Image = global::Recorder.Properties.Resources.stop;
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStop.Location = new System.Drawing.Point(133, 57);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BbtnStop_Click);
            // 
            // btnRec
            // 
            this.btnRec.Image = global::Recorder.Properties.Resources.rec;
            this.btnRec.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRec.Location = new System.Drawing.Point(52, 57);
            this.btnRec.Name = "btnRec";
            this.btnRec.Size = new System.Drawing.Size(75, 23);
            this.btnRec.TabIndex = 3;
            this.btnRec.Text = "Rec";
            this.btnRec.UseVisualStyleBackColor = true;
            this.btnRec.Click += new System.EventHandler(this.btnRec_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(52, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Записывающие устройства";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnPlay2
            // 
            this.btnPlay2.Image = global::Recorder.Properties.Resources.play;
            this.btnPlay2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPlay2.Location = new System.Drawing.Point(214, 112);
            this.btnPlay2.Name = "btnPlay2";
            this.btnPlay2.Size = new System.Drawing.Size(75, 23);
            this.btnPlay2.TabIndex = 3;
            this.btnPlay2.Text = "Play 2";
            this.btnPlay2.UseVisualStyleBackColor = true;
            this.btnPlay2.Click += new System.EventHandler(this.btnPlay2_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 139);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPlay2);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnRec);
            this.Controls.Add(this.info);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.FileName);
            this.Name = "main";
            this.Text = "Запись с микрофона..";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FileName;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Button btnRec;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPlay2;
    }
}


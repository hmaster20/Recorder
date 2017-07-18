namespace RecNAudio
{
    partial class Form1
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
            this.StartBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.browse = new System.Windows.Forms.Button();
            this.FileName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(98, 59);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 23);
            this.StartBtn.TabIndex = 0;
            this.StartBtn.Text = "Record";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.Location = new System.Drawing.Point(179, 59);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(75, 23);
            this.StopBtn.TabIndex = 0;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(299, 99);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(27, 23);
            this.browse.TabIndex = 3;
            this.browse.Text = "...";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // FileName
            // 
            this.FileName.Location = new System.Drawing.Point(56, 100);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(237, 20);
            this.FileName.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 183);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.FileName);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.StartBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.TextBox FileName;
    }
}


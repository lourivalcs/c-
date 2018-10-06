namespace ModeloServico.ConfiguracaoServico
{
    partial class ModeloServicoStub
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnThread01 = new System.Windows.Forms.Button();
            this.btnThread02 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 13);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(103, 47);
            this.btnStart.TabIndex = 0;
            this.btnStart.Tag = "Start";
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(122, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(103, 47);
            this.btnStop.TabIndex = 1;
            this.btnStop.Tag = "Stop";
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnThread01
            // 
            this.btnThread01.Location = new System.Drawing.Point(13, 91);
            this.btnThread01.Name = "btnThread01";
            this.btnThread01.Size = new System.Drawing.Size(103, 32);
            this.btnThread01.TabIndex = 2;
            this.btnThread01.Tag = "Thread01";
            this.btnThread01.Text = "Thread 01";
            this.btnThread01.UseVisualStyleBackColor = true;
            this.btnThread01.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnThread02
            // 
            this.btnThread02.Location = new System.Drawing.Point(122, 91);
            this.btnThread02.Name = "btnThread02";
            this.btnThread02.Size = new System.Drawing.Size(103, 32);
            this.btnThread02.TabIndex = 3;
            this.btnThread02.Tag = "Thread02";
            this.btnThread02.Text = "Thread 02";
            this.btnThread02.UseVisualStyleBackColor = true;
            this.btnThread02.Click += new System.EventHandler(this.btn_Click);
            // 
            // ModeloServicoStub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 157);
            this.Controls.Add(this.btnThread02);
            this.Controls.Add(this.btnThread01);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "ModeloServicoStub";
            this.Text = "ModeloServicoStub";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnThread01;
        private System.Windows.Forms.Button btnThread02;
    }
}
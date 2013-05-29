namespace TestHarness.newsfeed
{
    partial class NewsFeedTestForm
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
            this.btnStartHttpListener = new System.Windows.Forms.Button();
            this.tbxUri = new System.Windows.Forms.TextBox();
            this.tbxPort = new System.Windows.Forms.TextBox();
            this.lblUri = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStartHttpListener
            // 
            this.btnStartHttpListener.Location = new System.Drawing.Point(50, 34);
            this.btnStartHttpListener.Name = "btnStartHttpListener";
            this.btnStartHttpListener.Size = new System.Drawing.Size(108, 66);
            this.btnStartHttpListener.TabIndex = 0;
            this.btnStartHttpListener.Text = "Start Http Listener";
            this.btnStartHttpListener.UseVisualStyleBackColor = true;
            this.btnStartHttpListener.Click += new System.EventHandler(this.btnStartHttpListener_Click);
            // 
            // tbxUri
            // 
            this.tbxUri.Location = new System.Drawing.Point(82, 151);
            this.tbxUri.Name = "tbxUri";
            this.tbxUri.Size = new System.Drawing.Size(218, 22);
            this.tbxUri.TabIndex = 1;
            this.tbxUri.Text = "http://dev.cetrea.dk/proxy/";
            // 
            // tbxPort
            // 
            this.tbxPort.Location = new System.Drawing.Point(82, 189);
            this.tbxPort.Name = "tbxPort";
            this.tbxPort.Size = new System.Drawing.Size(218, 22);
            this.tbxPort.TabIndex = 1;
            this.tbxPort.Text = "80";
            // 
            // lblUri
            // 
            this.lblUri.AutoSize = true;
            this.lblUri.Location = new System.Drawing.Point(50, 151);
            this.lblUri.Name = "lblUri";
            this.lblUri.Size = new System.Drawing.Size(26, 17);
            this.lblUri.TabIndex = 2;
            this.lblUri.Text = "Uri";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(47, 189);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(34, 17);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Port";
            // 
            // lblWarning
            // 
            this.lblWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Location = new System.Drawing.Point(208, 34);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(287, 89);
            this.lblWarning.TabIndex = 3;
            this.lblWarning.Text = "Pressing start will simulate the forever loop - so just use task manager to stop!" +
                "!!";
            // 
            // NewsFeedTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 273);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblUri);
            this.Controls.Add(this.tbxPort);
            this.Controls.Add(this.tbxUri);
            this.Controls.Add(this.btnStartHttpListener);
            this.Name = "NewsFeedTestForm";
            this.Text = "NewsFeed Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartHttpListener;
        private System.Windows.Forms.TextBox tbxUri;
        private System.Windows.Forms.TextBox tbxPort;
        private System.Windows.Forms.Label lblUri;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblWarning;
    }
}


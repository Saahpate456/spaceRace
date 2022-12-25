namespace spaceRace
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.gameLoop = new System.Windows.Forms.Timer(this.components);
            this.timeLabel = new System.Windows.Forms.Label();
            this.p1Score = new System.Windows.Forms.Label();
            this.p2Score = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.winLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameLoop
            // 
            this.gameLoop.Interval = 20;
            this.gameLoop.Tick += new System.EventHandler(this.gameLoop_Tick);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.timeLabel.Location = new System.Drawing.Point(386, 9);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(118, 24);
            this.timeLabel.TabIndex = 0;
            this.timeLabel.Text = "timeLabel";
            // 
            // p1Score
            // 
            this.p1Score.AutoSize = true;
            this.p1Score.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1Score.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.p1Score.Location = new System.Drawing.Point(365, 43);
            this.p1Score.Name = "p1Score";
            this.p1Score.Size = new System.Drawing.Size(0, 24);
            this.p1Score.TabIndex = 1;
            // 
            // p2Score
            // 
            this.p2Score.AutoSize = true;
            this.p2Score.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2Score.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.p2Score.Location = new System.Drawing.Point(423, 43);
            this.p2Score.Name = "p2Score";
            this.p2Score.Size = new System.Drawing.Size(0, 24);
            this.p2Score.TabIndex = 2;
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.subtitleLabel.Location = new System.Drawing.Point(189, 247);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(106, 24);
            this.subtitleLabel.TabIndex = 4;
            this.subtitleLabel.Text = "subtitle";
            this.subtitleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.titleLabel.Location = new System.Drawing.Point(353, 195);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(70, 24);
            this.titleLabel.TabIndex = 5;
            this.titleLabel.Text = "title";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // winLabel
            // 
            this.winLabel.AutoSize = true;
            this.winLabel.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.winLabel.Location = new System.Drawing.Point(317, 287);
            this.winLabel.Name = "winLabel";
            this.winLabel.Size = new System.Drawing.Size(106, 24);
            this.winLabel.TabIndex = 6;
            this.winLabel.Text = "winLabel";
            this.winLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.winLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.subtitleLabel);
            this.Controls.Add(this.p2Score);
            this.Controls.Add(this.p1Score);
            this.Controls.Add(this.timeLabel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameLoop;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label p1Score;
        private System.Windows.Forms.Label p2Score;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label winLabel;
    }
}


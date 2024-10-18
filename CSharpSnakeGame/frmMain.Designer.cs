namespace CSharpSnakeGame
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlTop = new Panel();
            lblScore = new Label();
            btnExit = new Button();
            pnlCanvas = new Panel();
            tmrUpdater = new System.Windows.Forms.Timer(components);
            pnlTop.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTop.BackColor = Color.CadetBlue;
            pnlTop.Controls.Add(lblScore);
            pnlTop.Controls.Add(btnExit);
            pnlTop.Location = new Point(5, 5);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1200, 30);
            pnlTop.TabIndex = 0;
            pnlTop.MouseDown += pnlTop_MouseDown;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.BackColor = Color.Transparent;
            lblScore.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblScore.ForeColor = Color.Gainsboro;
            lblScore.Location = new Point(7, 6);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(54, 19);
            lblScore.TabIndex = 1;
            lblScore.Text = "Score:";
            // 
            // btnExit
            // 
            btnExit.Dock = DockStyle.Right;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.ForeColor = Color.Gainsboro;
            btnExit.Location = new Point(1174, 0);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(26, 30);
            btnExit.TabIndex = 0;
            btnExit.Text = "X";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // pnlCanvas
            // 
            pnlCanvas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlCanvas.BackColor = Color.DarkSeaGreen;
            pnlCanvas.Location = new Point(5, 40);
            pnlCanvas.Name = "pnlCanvas";
            pnlCanvas.Size = new Size(1200, 800);
            pnlCanvas.TabIndex = 1;
            // 
            // tmrUpdater
            // 
            tmrUpdater.Tick += tmrUpdater_Tick;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(1210, 845);
            Controls.Add(pnlCanvas);
            Controls.Add(pnlTop);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Snake Game";
            Load += frmMain_Load;
            KeyDown += frmMain_KeyDown;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Panel pnlCanvas;
        private Button btnExit;
        private System.Windows.Forms.Timer tmrUpdater;
        private Label lblScore;
    }
}

namespace PokemonCardScraper.Forms
{
    partial class LoadingBar
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
            Caption = new Label();
            panel1 = new Panel();
            ProgressLabel = new Label();
            progressBar1 = new ProgressBar();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // Caption
            // 
            Caption.AutoSize = true;
            Caption.Dock = DockStyle.Top;
            Caption.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Caption.Location = new Point(0, 0);
            Caption.Name = "Caption";
            Caption.Size = new Size(110, 21);
            Caption.TabIndex = 3;
            Caption.Text = "Body Message";
            // 
            // panel1
            // 
            panel1.Controls.Add(ProgressLabel);
            panel1.Controls.Add(progressBar1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 21);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 33);
            panel1.TabIndex = 6;
            // 
            // ProgressLabel
            // 
            ProgressLabel.AutoSize = true;
            ProgressLabel.Dock = DockStyle.Right;
            ProgressLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ProgressLabel.Location = new Point(777, 0);
            ProgressLabel.Name = "ProgressLabel";
            ProgressLabel.Size = new Size(23, 21);
            ProgressLabel.TabIndex = 7;
            ProgressLabel.Text = "%";
            // 
            // progressBar1
            // 
            progressBar1.Dock = DockStyle.Left;
            progressBar1.Location = new Point(0, 0);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(771, 33);
            progressBar1.TabIndex = 6;
            // 
            // LoadingBar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 79);
            ControlBox = false;
            Controls.Add(panel1);
            Controls.Add(Caption);
            Name = "LoadingBar";
            ShowIcon = false;
            Text = "LoadingBar";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public Label Caption;
        private Panel panel1;
        public Label ProgressLabel;
        public ProgressBar progressBar1;
    }
}
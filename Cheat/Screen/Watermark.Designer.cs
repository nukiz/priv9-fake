namespace Priv9.Cheat.Screen
{
    partial class Watermark
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            LogoPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
            WatermarkText = new Label();
            LogoPanel.SuspendLayout();
            SuspendLayout();
            // 
            // LogoPanel
            // 
            LogoPanel.BackColor = Color.FromArgb(20, 20, 20);
            LogoPanel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            LogoPanel.BorderThickness = 5;
            LogoPanel.Controls.Add(WatermarkText);
            LogoPanel.CustomBorderColor = Color.FromArgb(50, 255, 255, 255);
            LogoPanel.CustomBorderThickness = new Padding(2);
            LogoPanel.CustomizableEdges = customizableEdges1;
            LogoPanel.FillColor = Color.FromArgb(9, 69, 96);
            LogoPanel.FillColor2 = Color.FromArgb(2, 62, 50);
            LogoPanel.Location = new Point(0, 0);
            LogoPanel.Name = "LogoPanel";
            LogoPanel.ShadowDecoration.CustomizableEdges = customizableEdges2;
            LogoPanel.Size = new Size(271, 27);
            LogoPanel.TabIndex = 8;
            // 
            // WatermarkText
            // 
            WatermarkText.AutoSize = true;
            WatermarkText.BackColor = Color.Transparent;
            WatermarkText.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            WatermarkText.ForeColor = Color.White;
            WatermarkText.Location = new Point(5, 5);
            WatermarkText.Name = "WatermarkText";
            WatermarkText.Size = new Size(260, 14);
            WatermarkText.TabIndex = 5;
            WatermarkText.Text = "grow9.net alpha | Feb 18 2024 | fps: 59\r\n";
            WatermarkText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Watermark
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Green;
            ClientSize = new Size(271, 27);
            Controls.Add(LogoPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Watermark";
            Text = "Watermark";
            TransparencyKey = Color.Green;
            Load += WatermarkLoaded;
            LogoPanel.ResumeLayout(false);
            LogoPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel LogoPanel;
        internal Label WatermarkText;
    }
}
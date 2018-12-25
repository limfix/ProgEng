namespace lab05
{
    partial class DrawWindow
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.DrawBox = new System.Windows.Forms.PictureBox();
            this.copyButton = new System.Windows.Forms.Button();
            this.pasteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DrawBox)).BeginInit();
            this.SuspendLayout();
            // 
            // DrawBox
            // 
            this.DrawBox.BackColor = System.Drawing.SystemColors.Window;
            this.DrawBox.Location = new System.Drawing.Point(13, 13);
            this.DrawBox.Name = "DrawBox";
            this.DrawBox.Size = new System.Drawing.Size(231, 231);
            this.DrawBox.TabIndex = 0;
            this.DrawBox.TabStop = false;
            this.DrawBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawBox_MouseDown);
            this.DrawBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawBox_MouseMove);
            this.DrawBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawBox_MouseUp);
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(13, 267);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(75, 23);
            this.copyButton.TabIndex = 1;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click_1);
            // 
            // pasteButton
            // 
            this.pasteButton.Location = new System.Drawing.Point(169, 267);
            this.pasteButton.Name = "pasteButton";
            this.pasteButton.Size = new System.Drawing.Size(75, 23);
            this.pasteButton.TabIndex = 2;
            this.pasteButton.Text = "Paste";
            this.pasteButton.UseVisualStyleBackColor = true;
            this.pasteButton.Click += new System.EventHandler(this.pasteButton_Click);
            // 
            // DrawWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(260, 304);
            this.Controls.Add(this.pasteButton);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.DrawBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DrawWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RectangleCanvas";
            this.Load += new System.EventHandler(this.DrawWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DrawBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        public System.Windows.Forms.PictureBox DrawBox;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button pasteButton;
    }
}
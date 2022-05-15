
namespace Cold_War_Class_Storage_V2
{
    partial class ClassTitleControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.NameLabel);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 38);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.ClickEvent);
            this.panel1.MouseEnter += new System.EventHandler(this.MouseEnterEvent);
            this.panel1.MouseLeave += new System.EventHandler(this.MouseLeaveEvent);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Location = new System.Drawing.Point(10, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(330, 1);
            this.panel2.TabIndex = 5;
            this.panel2.Click += new System.EventHandler(this.ClickEvent);
            this.panel2.MouseEnter += new System.EventHandler(this.MouseEnterEvent);
            this.panel2.MouseLeave += new System.EventHandler(this.MouseLeaveEvent);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(321, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.ClickEvent);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.MouseEnterEvent);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.MouseLeaveEvent);
            // 
            // NameLabel
            // 
            this.NameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameLabel.Font = new System.Drawing.Font("Stencil", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.NameLabel.Location = new System.Drawing.Point(3, 3);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(304, 25);
            this.NameLabel.TabIndex = 3;
            this.NameLabel.Text = "text";
            this.NameLabel.Click += new System.EventHandler(this.ClickEvent);
            this.NameLabel.MouseEnter += new System.EventHandler(this.MouseEnterEvent);
            this.NameLabel.MouseLeave += new System.EventHandler(this.MouseLeaveEvent);
            // 
            // ClassTitleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Name = "ClassTitleControl";
            this.Size = new System.Drawing.Size(358, 46);
            this.Click += new System.EventHandler(this.ClickEvent);
            this.MouseEnter += new System.EventHandler(this.MouseEnterEvent);
            this.MouseLeave += new System.EventHandler(this.MouseLeaveEvent);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label NameLabel;
    }
}

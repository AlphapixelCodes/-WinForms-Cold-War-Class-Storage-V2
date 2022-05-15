
namespace Cold_War_Class_Storage_V2
{
    partial class SelectControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.SelectedBoxImage = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedBoxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "Perk Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.DoubleClick += new System.EventHandler(this.DoubleClickEvent);
            this.label1.MouseEnter += new System.EventHandler(this.PerkControl_MouseHover);
            this.label1.MouseLeave += new System.EventHandler(this.PerkControl_MouseLeave);
            // 
            // SelectedBoxImage
            // 
            this.SelectedBoxImage.BackColor = System.Drawing.Color.Transparent;
            this.SelectedBoxImage.Image = global::Cold_War_Class_Storage_V2.Properties.Resources.blank_image;
            this.SelectedBoxImage.Location = new System.Drawing.Point(195, 4);
            this.SelectedBoxImage.Name = "SelectedBoxImage";
            this.SelectedBoxImage.Size = new System.Drawing.Size(28, 17);
            this.SelectedBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SelectedBoxImage.TabIndex = 2;
            this.SelectedBoxImage.TabStop = false;
            this.SelectedBoxImage.Click += new System.EventHandler(this.label1_Click);
            this.SelectedBoxImage.DoubleClick += new System.EventHandler(this.DoubleClickEvent);
            this.SelectedBoxImage.MouseEnter += new System.EventHandler(this.PerkControl_MouseHover);
            this.SelectedBoxImage.MouseLeave += new System.EventHandler(this.PerkControl_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cold_War_Class_Storage_V2.Properties.Resources.Flak_Jacket;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.label1_Click);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.DoubleClickEvent);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.PerkControl_MouseHover);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.PerkControl_MouseLeave);
            // 
            // SelectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SelectedBoxImage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "SelectControl";
            this.Size = new System.Drawing.Size(226, 56);
            this.MouseLeave += new System.EventHandler(this.PerkControl_MouseLeave);
            this.MouseHover += new System.EventHandler(this.PerkControl_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.SelectedBoxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox SelectedBoxImage;
    }
}

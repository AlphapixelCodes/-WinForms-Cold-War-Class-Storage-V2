
namespace Cold_War_Class_Storage_V2
{
    partial class Perk_GUI
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Type3Panel = new System.Windows.Forms.FlowLayoutPanel();
            this.Type2Panel = new System.Windows.Forms.FlowLayoutPanel();
            this.Type1Panel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(8, 353);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(346, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Perk_GUI_KeyDown);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Stencil", 14.25F);
            this.button2.Location = new System.Drawing.Point(362, 353);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(346, 28);
            this.button2.TabIndex = 4;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Perk_GUI_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 16.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Perks";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Stencil", 10.25F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(86, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select 3";
            // 
            // Type3Panel
            // 
            this.Type3Panel.Location = new System.Drawing.Point(478, 40);
            this.Type3Panel.Name = "Type3Panel";
            this.Type3Panel.Size = new System.Drawing.Size(230, 307);
            this.Type3Panel.TabIndex = 7;
            // 
            // Type2Panel
            // 
            this.Type2Panel.Location = new System.Drawing.Point(244, 40);
            this.Type2Panel.Name = "Type2Panel";
            this.Type2Panel.Size = new System.Drawing.Size(230, 307);
            this.Type2Panel.TabIndex = 8;
            // 
            // Type1Panel
            // 
            this.Type1Panel.Location = new System.Drawing.Point(8, 40);
            this.Type1Panel.Name = "Type1Panel";
            this.Type1Panel.Size = new System.Drawing.Size(230, 307);
            this.Type1Panel.TabIndex = 9;
            // 
            // Perk_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(718, 386);
            this.Controls.Add(this.Type1Panel);
            this.Controls.Add(this.Type2Panel);
            this.Controls.Add(this.Type3Panel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Perk_GUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Perks";
            this.Load += new System.EventHandler(this.Perk_GUI_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Perk_GUI_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel Type3Panel;
        private System.Windows.Forms.FlowLayoutPanel Type2Panel;
        private System.Windows.Forms.FlowLayoutPanel Type1Panel;
    }
}
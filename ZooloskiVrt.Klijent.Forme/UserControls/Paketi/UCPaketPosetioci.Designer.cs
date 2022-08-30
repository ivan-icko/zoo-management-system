
using System.Windows.Forms;

namespace ZooloskiVrt.Klijent.Forme.UserControls.Paketi
{
    partial class UCPaketPosetioci
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
            this.dgvPP = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPP)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPP
            // 
            this.dgvPP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPP.Location = new System.Drawing.Point(127, 156);
            this.dgvPP.Name = "dgvPP";
            this.dgvPP.RowHeadersWidth = 51;
            this.dgvPP.RowTemplate.Height = 24;
            this.dgvPP.Size = new System.Drawing.Size(583, 190);
            this.dgvPP.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(127, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Posetioci na paketu:";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbl2.Location = new System.Drawing.Point(456, 97);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(26, 38);
            this.lbl2.TabIndex = 2;
            this.lbl2.Text = ".";
            // 
            // UCPaketPosetioci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPP);
            this.Name = "UCPaketPosetioci";
            this.Size = new System.Drawing.Size(844, 499);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPP;
        private Label label1;
        private Label lbl2;

        public DataGridView DgvPP { get => dgvPP; set => dgvPP = value; }
        public Label Lbl2 { get => lbl2; set => lbl2 = value; }


    }
}

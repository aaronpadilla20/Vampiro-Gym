
namespace Vampiro_Gym.Forms
{
    partial class generalReportWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(generalReportWindow));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fromDate = new Vampiro_Gym.Utilidades.customizedSelectDate();
            this.toDate = new Vampiro_Gym.Utilidades.customizedSelectDate();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pictureBoxIpl1 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.26923F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.73077F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.fromDate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.toDate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxIpl1, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(520, 255);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desde: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 63);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hasta: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 63);
            this.label3.TabIndex = 2;
            this.label3.Text = "Comentarios:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fromDate
            // 
            this.fromDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fromDate.BorderColor = System.Drawing.Color.DarkViolet;
            this.fromDate.BorderSize = 5;
            this.fromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.fromDate.Location = new System.Drawing.Point(149, 14);
            this.fromDate.MinimumSize = new System.Drawing.Size(4, 35);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(368, 35);
            this.fromDate.SkinColor = System.Drawing.Color.White;
            this.fromDate.TabIndex = 3;
            this.fromDate.TextColor = System.Drawing.Color.Black;
            // 
            // toDate
            // 
            this.toDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toDate.BorderColor = System.Drawing.Color.DarkViolet;
            this.toDate.BorderSize = 5;
            this.toDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.toDate.Location = new System.Drawing.Point(149, 77);
            this.toDate.MinimumSize = new System.Drawing.Size(0, 35);
            this.toDate.Name = "toDate";
            this.toDate.Size = new System.Drawing.Size(368, 35);
            this.toDate.SkinColor = System.Drawing.Color.White;
            this.toDate.TabIndex = 4;
            this.toDate.TextColor = System.Drawing.Color.Black;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(149, 129);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(368, 57);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // pictureBoxIpl1
            // 
            this.pictureBoxIpl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxIpl1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxIpl1.Image")));
            this.pictureBoxIpl1.Location = new System.Drawing.Point(149, 192);
            this.pictureBoxIpl1.Name = "pictureBoxIpl1";
            this.pictureBoxIpl1.Size = new System.Drawing.Size(368, 60);
            this.pictureBoxIpl1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIpl1.TabIndex = 6;
            this.pictureBoxIpl1.TabStop = false;
            // 
            // generalReportWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 255);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "generalReportWindow";
            this.Text = "generalReportWindow";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Utilidades.customizedSelectDate fromDate;
        private Utilidades.customizedSelectDate toDate;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIpl1;
    }
}
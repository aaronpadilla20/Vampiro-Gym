
namespace Vampiro_Gym.Forms
{
    partial class customerReportWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(customerReportWindow));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.generateButton = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.fromDate = new Vampiro_Gym.Utilidades.customizedSelectDate();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.toDate = new Vampiro_Gym.Utilidades.customizedSelectDate();
            this.customerName = new Vampiro_Gym.Utilities.comboBoxCustomized();
            this.label4 = new System.Windows.Forms.Label();
            this.commentTextBox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.generateButton)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.49419F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.50581F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.customerName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.generateButton, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.commentTextBox, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(595, 297);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del cliente: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 59);
            this.label2.TabIndex = 1;
            this.label2.Text = "Desde: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 118);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 59);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hasta:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // generateButton
            // 
            this.generateButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generateButton.Image = ((System.Drawing.Image)(resources.GetObject("generateButton.Image")));
            this.generateButton.Location = new System.Drawing.Point(205, 236);
            this.generateButton.Margin = new System.Windows.Forms.Padding(0);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(390, 61);
            this.generateButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.generateButton.TabIndex = 3;
            this.generateButton.TabStop = false;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.82051F));
            this.tableLayoutPanel2.Controls.Add(this.fromDate, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(208, 62);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(384, 53);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // fromDate
            // 
            this.fromDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fromDate.BorderColor = System.Drawing.Color.Salmon;
            this.fromDate.BorderSize = 5;
            this.fromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.fromDate.Location = new System.Drawing.Point(3, 9);
            this.fromDate.MinimumSize = new System.Drawing.Size(4, 35);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(378, 35);
            this.fromDate.SkinColor = System.Drawing.Color.White;
            this.fromDate.TabIndex = 0;
            this.fromDate.TextColor = System.Drawing.Color.Black;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.63513F));
            this.tableLayoutPanel3.Controls.Add(this.toDate, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(208, 121);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(384, 53);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // toDate
            // 
            this.toDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toDate.BorderColor = System.Drawing.Color.Salmon;
            this.toDate.BorderSize = 5;
            this.toDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.toDate.Location = new System.Drawing.Point(3, 9);
            this.toDate.MinimumSize = new System.Drawing.Size(4, 35);
            this.toDate.Name = "toDate";
            this.toDate.Size = new System.Drawing.Size(378, 35);
            this.toDate.SkinColor = System.Drawing.Color.White;
            this.toDate.TabIndex = 0;
            this.toDate.TextColor = System.Drawing.Color.Black;
            // 
            // customerName
            // 
            this.customerName.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.customerName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.customerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.customerName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.customerName.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.customerName.BorderSize = 1;
            this.customerName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.customerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.customerName.ForeColor = System.Drawing.Color.Black;
            this.customerName.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.customerName.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.customerName.ListTextColor = System.Drawing.Color.DimGray;
            this.customerName.Location = new System.Drawing.Point(208, 14);
            this.customerName.MinimumSize = new System.Drawing.Size(200, 30);
            this.customerName.Name = "customerName";
            this.customerName.Padding = new System.Windows.Forms.Padding(1);
            this.customerName.Size = new System.Drawing.Size(384, 30);
            this.customerName.TabIndex = 7;
            this.customerName.Texts = "-- Selecciona Cliente --";
            this.customerName.Click += new System.EventHandler(this.customerName_Click);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 59);
            this.label4.TabIndex = 8;
            this.label4.Text = "Comentarios: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // commentTextBox
            // 
            this.commentTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commentTextBox.Location = new System.Drawing.Point(208, 180);
            this.commentTextBox.Name = "commentTextBox";
            this.commentTextBox.Size = new System.Drawing.Size(384, 53);
            this.commentTextBox.TabIndex = 9;
            this.commentTextBox.Text = "";
            // 
            // customerReportWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 297);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "customerReportWindow";
            this.Text = "customerReportWindow";
            this.Load += new System.EventHandler(this.customerReportWindow_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.generateButton)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private OpenCvSharp.UserInterface.PictureBoxIpl generateButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Utilities.comboBoxCustomized comboBoxCustomized1;
        private Utilities.comboBoxCustomized customerName;
        private Utilidades.customizedSelectDate fromDate;
        private Utilidades.customizedSelectDate toDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox commentTextBox;
    }
}

namespace Vampiro_Gym.Forms
{
    partial class CustomerWIndow
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.customerImage = new System.Windows.Forms.PictureBox();
            this.statusCustomerImage = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.membershipTypeLabel = new System.Windows.Forms.Label();
            this.startDate = new System.Windows.Forms.Label();
            this.updateUserButton = new System.Windows.Forms.Button();
            this.deleteUserButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusCustomerImage)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(498, 292);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.customerImage, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.statusCustomerImage, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(252, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(243, 286);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // customerImage
            // 
            this.customerImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerImage.Location = new System.Drawing.Point(0, 0);
            this.customerImage.Margin = new System.Windows.Forms.Padding(0);
            this.customerImage.Name = "customerImage";
            this.customerImage.Size = new System.Drawing.Size(243, 228);
            this.customerImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.customerImage.TabIndex = 0;
            this.customerImage.TabStop = false;
            // 
            // statusCustomerImage
            // 
            this.statusCustomerImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusCustomerImage.Location = new System.Drawing.Point(0, 228);
            this.statusCustomerImage.Margin = new System.Windows.Forms.Padding(0);
            this.statusCustomerImage.Name = "statusCustomerImage";
            this.statusCustomerImage.Size = new System.Drawing.Size(243, 58);
            this.statusCustomerImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.statusCustomerImage.TabIndex = 1;
            this.statusCustomerImage.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.nameLabel, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.membershipTypeLabel, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.startDate, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.updateUserButton, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.deleteUserButton, 1, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(243, 286);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 71);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del cliente:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 71);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo de membresia:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 71);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha de inicio:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameLabel
            // 
            this.nameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameLabel.Location = new System.Drawing.Point(124, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(116, 71);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "label4";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // membershipTypeLabel
            // 
            this.membershipTypeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.membershipTypeLabel.Location = new System.Drawing.Point(124, 71);
            this.membershipTypeLabel.Name = "membershipTypeLabel";
            this.membershipTypeLabel.Size = new System.Drawing.Size(116, 71);
            this.membershipTypeLabel.TabIndex = 4;
            this.membershipTypeLabel.Text = "label4";
            this.membershipTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startDate
            // 
            this.startDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startDate.Location = new System.Drawing.Point(124, 142);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(116, 71);
            this.startDate.TabIndex = 5;
            this.startDate.Text = "label4";
            this.startDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // updateUserButton
            // 
            this.updateUserButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateUserButton.Location = new System.Drawing.Point(3, 216);
            this.updateUserButton.Name = "updateUserButton";
            this.updateUserButton.Size = new System.Drawing.Size(115, 67);
            this.updateUserButton.TabIndex = 6;
            this.updateUserButton.Text = "Actualiza Membresia";
            this.updateUserButton.UseVisualStyleBackColor = true;
            // 
            // deleteUserButton
            // 
            this.deleteUserButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteUserButton.Location = new System.Drawing.Point(124, 216);
            this.deleteUserButton.Name = "deleteUserButton";
            this.deleteUserButton.Size = new System.Drawing.Size(116, 67);
            this.deleteUserButton.TabIndex = 7;
            this.deleteUserButton.Text = "Elimina Usuario";
            this.deleteUserButton.UseVisualStyleBackColor = true;
            // 
            // CustomerWIndow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 292);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CustomerWIndow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomerWIndow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CustomerWIndow_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customerImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusCustomerImage)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox customerImage;
        private System.Windows.Forms.PictureBox statusCustomerImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label membershipTypeLabel;
        private System.Windows.Forms.Label startDate;
        private System.Windows.Forms.Button updateUserButton;
        private System.Windows.Forms.Button deleteUserButton;
    }
}
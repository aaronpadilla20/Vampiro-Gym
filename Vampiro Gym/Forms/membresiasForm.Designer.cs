
namespace Vampiro_Gym
{
    partial class membresiasForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(membresiasForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.headerTable = new System.Windows.Forms.TableLayoutPanel();
            this.contenedorBotonCerrar = new System.Windows.Forms.Panel();
            this.botonCerrar = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.agregarMembresiaButton = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtgvMembresias = new System.Windows.Forms.DataGridView();
            this.edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Membresias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.headerTable.SuspendLayout();
            this.contenedorBotonCerrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.botonCerrar)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agregarMembresiaButton)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvMembresias)).BeginInit();
            this.SuspendLayout();
            // 
            // headerTable
            // 
            this.headerTable.ColumnCount = 2;
            this.headerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.headerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.headerTable.Controls.Add(this.contenedorBotonCerrar, 1, 0);
            this.headerTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerTable.Location = new System.Drawing.Point(0, 0);
            this.headerTable.Margin = new System.Windows.Forms.Padding(0);
            this.headerTable.Name = "headerTable";
            this.headerTable.RowCount = 1;
            this.headerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.headerTable.Size = new System.Drawing.Size(633, 43);
            this.headerTable.TabIndex = 1;
            // 
            // contenedorBotonCerrar
            // 
            this.contenedorBotonCerrar.Controls.Add(this.botonCerrar);
            this.contenedorBotonCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.contenedorBotonCerrar.Location = new System.Drawing.Point(522, 3);
            this.contenedorBotonCerrar.Name = "contenedorBotonCerrar";
            this.contenedorBotonCerrar.Size = new System.Drawing.Size(108, 37);
            this.contenedorBotonCerrar.TabIndex = 0;
            // 
            // botonCerrar
            // 
            this.botonCerrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonCerrar.Image = ((System.Drawing.Image)(resources.GetObject("botonCerrar.Image")));
            this.botonCerrar.Location = new System.Drawing.Point(40, 12);
            this.botonCerrar.Name = "botonCerrar";
            this.botonCerrar.Size = new System.Drawing.Size(36, 17);
            this.botonCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.botonCerrar.TabIndex = 0;
            this.botonCerrar.TabStop = false;
            this.botonCerrar.Click += new System.EventHandler(this.botonCerrar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(633, 56);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.agregarMembresiaButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(433, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 56);
            this.panel2.TabIndex = 0;
            // 
            // agregarMembresiaButton
            // 
            this.agregarMembresiaButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.agregarMembresiaButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.agregarMembresiaButton.Image = ((System.Drawing.Image)(resources.GetObject("agregarMembresiaButton.Image")));
            this.agregarMembresiaButton.Location = new System.Drawing.Point(0, 0);
            this.agregarMembresiaButton.Margin = new System.Windows.Forms.Padding(0);
            this.agregarMembresiaButton.Name = "agregarMembresiaButton";
            this.agregarMembresiaButton.Size = new System.Drawing.Size(200, 56);
            this.agregarMembresiaButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.agregarMembresiaButton.TabIndex = 0;
            this.agregarMembresiaButton.TabStop = false;
            this.agregarMembresiaButton.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtgvMembresias);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 99);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel3.Size = new System.Drawing.Size(633, 400);
            this.panel3.TabIndex = 3;
            // 
            // dtgvMembresias
            // 
            this.dtgvMembresias.AllowUserToAddRows = false;
            this.dtgvMembresias.AllowUserToDeleteRows = false;
            this.dtgvMembresias.AllowUserToResizeColumns = false;
            this.dtgvMembresias.AllowUserToResizeRows = false;
            this.dtgvMembresias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvMembresias.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(59)))), ((int)(((byte)(87)))));
            this.dtgvMembresias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvMembresias.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgvMembresias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(59)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(59)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvMembresias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvMembresias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvMembresias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.edit,
            this.delete,
            this.Membresias,
            this.Duracion,
            this.Precio});
            this.dtgvMembresias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvMembresias.EnableHeadersVisualStyles = false;
            this.dtgvMembresias.GridColor = System.Drawing.Color.LightSteelBlue;
            this.dtgvMembresias.Location = new System.Drawing.Point(0, 10);
            this.dtgvMembresias.Name = "dtgvMembresias";
            this.dtgvMembresias.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgvMembresias.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgvMembresias.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvMembresias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvMembresias.Size = new System.Drawing.Size(633, 390);
            this.dtgvMembresias.TabIndex = 0;
            this.dtgvMembresias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvMembresias_CellClick);
            this.dtgvMembresias.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dtgvMembresias_CellPainting);
            // 
            // edit
            // 
            this.edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edit.HeaderText = "";
            this.edit.Name = "edit";
            // 
            // delete
            // 
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete.HeaderText = "";
            this.delete.Name = "delete";
            // 
            // Membresias
            // 
            this.Membresias.HeaderText = "Membresias";
            this.Membresias.Name = "Membresias";
            // 
            // Duracion
            // 
            this.Duracion.HeaderText = "Duracion";
            this.Duracion.Name = "Duracion";
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            // 
            // membresiasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(59)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(633, 499);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.headerTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "membresiasForm";
            this.Text = "membresiasForm";
            this.Load += new System.EventHandler(this.membresiasForm_Load);
            this.headerTable.ResumeLayout(false);
            this.contenedorBotonCerrar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.botonCerrar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.agregarMembresiaButton)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvMembresias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel headerTable;
        private System.Windows.Forms.Panel contenedorBotonCerrar;
        private System.Windows.Forms.PictureBox botonCerrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox agregarMembresiaButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dtgvMembresias;
        private System.Windows.Forms.DataGridViewButtonColumn edit;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Membresias;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duracion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
    }
}
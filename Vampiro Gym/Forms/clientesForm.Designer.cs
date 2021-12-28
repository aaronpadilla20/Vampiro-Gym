
namespace Vampiro_Gym
{
    partial class clientesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(clientesForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.headerTable = new System.Windows.Forms.TableLayoutPanel();
            this.contenedorBotonCerrar = new System.Windows.Forms.Panel();
            this.botonCerrar = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.altaClienteButton = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dtgvClientes = new System.Windows.Forms.DataGridView();
            this.edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.image = new System.Windows.Forms.DataGridViewImageColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.restante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.headerTable.SuspendLayout();
            this.contenedorBotonCerrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.botonCerrar)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.altaClienteButton)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvClientes)).BeginInit();
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
            this.headerTable.Size = new System.Drawing.Size(649, 43);
            this.headerTable.TabIndex = 2;
            // 
            // contenedorBotonCerrar
            // 
            this.contenedorBotonCerrar.Controls.Add(this.botonCerrar);
            this.contenedorBotonCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.contenedorBotonCerrar.Location = new System.Drawing.Point(538, 3);
            this.contenedorBotonCerrar.Name = "contenedorBotonCerrar";
            this.contenedorBotonCerrar.Size = new System.Drawing.Size(108, 37);
            this.contenedorBotonCerrar.TabIndex = 0;
            // 
            // botonCerrar
            // 
            this.botonCerrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonCerrar.Image = ((System.Drawing.Image)(resources.GetObject("botonCerrar.Image")));
            this.botonCerrar.Location = new System.Drawing.Point(48, 4);
            this.botonCerrar.Name = "botonCerrar";
            this.botonCerrar.Size = new System.Drawing.Size(36, 17);
            this.botonCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.botonCerrar.TabIndex = 0;
            this.botonCerrar.TabStop = false;
            this.botonCerrar.Click += new System.EventHandler(this.botonCerrar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 67);
            this.panel1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.53153F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.46847F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(649, 67);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10, 20, 0, 0);
            this.panel2.Size = new System.Drawing.Size(397, 67);
            this.panel2.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(10, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(387, 20);
            this.textBox1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(397, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(158, 67);
            this.panel3.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.altaClienteButton);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(555, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(94, 67);
            this.panel4.TabIndex = 2;
            // 
            // altaClienteButton
            // 
            this.altaClienteButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.altaClienteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.altaClienteButton.Image = ((System.Drawing.Image)(resources.GetObject("altaClienteButton.Image")));
            this.altaClienteButton.Location = new System.Drawing.Point(16, 8);
            this.altaClienteButton.Name = "altaClienteButton";
            this.altaClienteButton.Size = new System.Drawing.Size(56, 49);
            this.altaClienteButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.altaClienteButton.TabIndex = 0;
            this.altaClienteButton.TabStop = false;
            this.altaClienteButton.Click += new System.EventHandler(this.altaClienteButton_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dtgvClientes);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 110);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(649, 428);
            this.panel5.TabIndex = 4;
            // 
            // dtgvClientes
            // 
            this.dtgvClientes.AllowUserToAddRows = false;
            this.dtgvClientes.AllowUserToDeleteRows = false;
            this.dtgvClientes.AllowUserToResizeColumns = false;
            this.dtgvClientes.AllowUserToResizeRows = false;
            this.dtgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvClientes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(59)))), ((int)(((byte)(87)))));
            this.dtgvClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvClientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgvClientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(59)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(59)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.edit,
            this.delete,
            this.image,
            this.name,
            this.Duracion,
            this.Precio,
            this.startDay,
            this.restante});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvClientes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvClientes.EnableHeadersVisualStyles = false;
            this.dtgvClientes.GridColor = System.Drawing.Color.LightSteelBlue;
            this.dtgvClientes.Location = new System.Drawing.Point(0, 0);
            this.dtgvClientes.Name = "dtgvClientes";
            this.dtgvClientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgvClientes.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgvClientes.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvClientes.Size = new System.Drawing.Size(649, 428);
            this.dtgvClientes.TabIndex = 1;
            this.dtgvClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvClientes_CellClick);
            this.dtgvClientes.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dtgvClientes_CellPainting_1);
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
            // image
            // 
            this.image.HeaderText = "Fotografia";
            this.image.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.image.Name = "image";
            // 
            // name
            // 
            this.name.HeaderText = "Nombre";
            this.name.Name = "name";
            // 
            // Duracion
            // 
            this.Duracion.HeaderText = "Apellidos";
            this.Duracion.Name = "Duracion";
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Tipo de membresia";
            this.Precio.Name = "Precio";
            // 
            // startDay
            // 
            this.startDay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.startDay.HeaderText = "Miembro desde";
            this.startDay.Name = "startDay";
            this.startDay.Width = 95;
            // 
            // restante
            // 
            this.restante.HeaderText = "Dias restantes";
            this.restante.Name = "restante";
            // 
            // clientesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(59)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(649, 538);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.headerTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "clientesForm";
            this.Text = "clientesForm";
            this.Load += new System.EventHandler(this.clientesForm_Load);
            this.headerTable.ResumeLayout(false);
            this.contenedorBotonCerrar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.botonCerrar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.altaClienteButton)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel headerTable;
        private System.Windows.Forms.Panel contenedorBotonCerrar;
        private System.Windows.Forms.PictureBox botonCerrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox altaClienteButton;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dtgvClientes;
        private System.Windows.Forms.DataGridViewButtonColumn edit;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
        private System.Windows.Forms.DataGridViewImageColumn image;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duracion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn restante;
    }
}
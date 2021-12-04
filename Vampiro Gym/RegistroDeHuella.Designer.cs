
namespace Vampiro_Gym
{
    partial class RegistroDeHuella
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
            this.tableLayOutControles = new System.Windows.Forms.TableLayoutPanel();
            this.contenedorImagenHuella = new System.Windows.Forms.Panel();
            this.huellaImage = new System.Windows.Forms.PictureBox();
            this.tableLayOutBotones = new System.Windows.Forms.TableLayoutPanel();
            this.contenedorBotonDetenCaptura = new System.Windows.Forms.Panel();
            this.stopCapture = new System.Windows.Forms.Button();
            this.contenedorBotonCaptura = new System.Windows.Forms.Panel();
            this.capturarHuella = new System.Windows.Forms.Button();
            this.contenedorEstadoConexion = new System.Windows.Forms.Panel();
            this.EstadoConexion = new System.Windows.Forms.Label();
            this.tableLayOutControles.SuspendLayout();
            this.contenedorImagenHuella.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.huellaImage)).BeginInit();
            this.tableLayOutBotones.SuspendLayout();
            this.contenedorBotonDetenCaptura.SuspendLayout();
            this.contenedorBotonCaptura.SuspendLayout();
            this.contenedorEstadoConexion.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayOutControles
            // 
            this.tableLayOutControles.ColumnCount = 2;
            this.tableLayOutControles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayOutControles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayOutControles.Controls.Add(this.contenedorImagenHuella, 0, 0);
            this.tableLayOutControles.Controls.Add(this.tableLayOutBotones, 1, 0);
            this.tableLayOutControles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayOutControles.Location = new System.Drawing.Point(0, 0);
            this.tableLayOutControles.Name = "tableLayOutControles";
            this.tableLayOutControles.RowCount = 1;
            this.tableLayOutControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayOutControles.Size = new System.Drawing.Size(529, 288);
            this.tableLayOutControles.TabIndex = 0;
            // 
            // contenedorImagenHuella
            // 
            this.contenedorImagenHuella.Controls.Add(this.huellaImage);
            this.contenedorImagenHuella.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedorImagenHuella.Location = new System.Drawing.Point(0, 0);
            this.contenedorImagenHuella.Margin = new System.Windows.Forms.Padding(0);
            this.contenedorImagenHuella.Name = "contenedorImagenHuella";
            this.contenedorImagenHuella.Size = new System.Drawing.Size(264, 288);
            this.contenedorImagenHuella.TabIndex = 0;
            // 
            // huellaImage
            // 
            this.huellaImage.BackColor = System.Drawing.Color.White;
            this.huellaImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.huellaImage.Location = new System.Drawing.Point(0, 0);
            this.huellaImage.Name = "huellaImage";
            this.huellaImage.Size = new System.Drawing.Size(264, 288);
            this.huellaImage.TabIndex = 0;
            this.huellaImage.TabStop = false;
            // 
            // tableLayOutBotones
            // 
            this.tableLayOutBotones.ColumnCount = 1;
            this.tableLayOutBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayOutBotones.Controls.Add(this.contenedorBotonDetenCaptura, 0, 1);
            this.tableLayOutBotones.Controls.Add(this.contenedorBotonCaptura, 0, 0);
            this.tableLayOutBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayOutBotones.Location = new System.Drawing.Point(264, 0);
            this.tableLayOutBotones.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayOutBotones.Name = "tableLayOutBotones";
            this.tableLayOutBotones.RowCount = 2;
            this.tableLayOutBotones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayOutBotones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayOutBotones.Size = new System.Drawing.Size(265, 288);
            this.tableLayOutBotones.TabIndex = 1;
            // 
            // contenedorBotonDetenCaptura
            // 
            this.contenedorBotonDetenCaptura.Controls.Add(this.stopCapture);
            this.contenedorBotonDetenCaptura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedorBotonDetenCaptura.Location = new System.Drawing.Point(0, 144);
            this.contenedorBotonDetenCaptura.Margin = new System.Windows.Forms.Padding(0);
            this.contenedorBotonDetenCaptura.Name = "contenedorBotonDetenCaptura";
            this.contenedorBotonDetenCaptura.Size = new System.Drawing.Size(265, 144);
            this.contenedorBotonDetenCaptura.TabIndex = 1;
            // 
            // stopCapture
            // 
            this.stopCapture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.stopCapture.Enabled = false;
            this.stopCapture.Location = new System.Drawing.Point(60, 44);
            this.stopCapture.Name = "stopCapture";
            this.stopCapture.Size = new System.Drawing.Size(144, 34);
            this.stopCapture.TabIndex = 1;
            this.stopCapture.Text = "Detener Captura";
            this.stopCapture.UseVisualStyleBackColor = true;
            this.stopCapture.Click += new System.EventHandler(this.stopCapture_Click);
            // 
            // contenedorBotonCaptura
            // 
            this.contenedorBotonCaptura.Controls.Add(this.capturarHuella);
            this.contenedorBotonCaptura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedorBotonCaptura.Location = new System.Drawing.Point(0, 0);
            this.contenedorBotonCaptura.Margin = new System.Windows.Forms.Padding(0);
            this.contenedorBotonCaptura.Name = "contenedorBotonCaptura";
            this.contenedorBotonCaptura.Size = new System.Drawing.Size(265, 144);
            this.contenedorBotonCaptura.TabIndex = 0;
            // 
            // capturarHuella
            // 
            this.capturarHuella.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.capturarHuella.Location = new System.Drawing.Point(62, 53);
            this.capturarHuella.Name = "capturarHuella";
            this.capturarHuella.Size = new System.Drawing.Size(144, 34);
            this.capturarHuella.TabIndex = 0;
            this.capturarHuella.Text = "Capturar huella";
            this.capturarHuella.UseVisualStyleBackColor = true;
            this.capturarHuella.Click += new System.EventHandler(this.capturarHuella_Click);
            // 
            // contenedorEstadoConexion
            // 
            this.contenedorEstadoConexion.Controls.Add(this.EstadoConexion);
            this.contenedorEstadoConexion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.contenedorEstadoConexion.Location = new System.Drawing.Point(0, 258);
            this.contenedorEstadoConexion.Name = "contenedorEstadoConexion";
            this.contenedorEstadoConexion.Size = new System.Drawing.Size(529, 30);
            this.contenedorEstadoConexion.TabIndex = 1;
            // 
            // EstadoConexion
            // 
            this.EstadoConexion.BackColor = System.Drawing.Color.Red;
            this.EstadoConexion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EstadoConexion.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EstadoConexion.ForeColor = System.Drawing.Color.White;
            this.EstadoConexion.Location = new System.Drawing.Point(0, 0);
            this.EstadoConexion.Name = "EstadoConexion";
            this.EstadoConexion.Size = new System.Drawing.Size(529, 30);
            this.EstadoConexion.TabIndex = 0;
            this.EstadoConexion.Text = "Dispositivo desconectado";
            this.EstadoConexion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RegistroDeHuella
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(529, 288);
            this.Controls.Add(this.contenedorEstadoConexion);
            this.Controls.Add(this.tableLayOutControles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RegistroDeHuella";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegistroDeHuella";
            this.tableLayOutControles.ResumeLayout(false);
            this.contenedorImagenHuella.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.huellaImage)).EndInit();
            this.tableLayOutBotones.ResumeLayout(false);
            this.contenedorBotonDetenCaptura.ResumeLayout(false);
            this.contenedorBotonCaptura.ResumeLayout(false);
            this.contenedorEstadoConexion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayOutControles;
        private System.Windows.Forms.Panel contenedorImagenHuella;
        private System.Windows.Forms.PictureBox huellaImage;
        private System.Windows.Forms.TableLayoutPanel tableLayOutBotones;
        private System.Windows.Forms.Panel contenedorBotonDetenCaptura;
        private System.Windows.Forms.Button stopCapture;
        private System.Windows.Forms.Panel contenedorBotonCaptura;
        private System.Windows.Forms.Button capturarHuella;
        private System.Windows.Forms.Panel contenedorEstadoConexion;
        private System.Windows.Forms.Label EstadoConexion;
    }
}
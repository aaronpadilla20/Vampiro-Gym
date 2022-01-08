using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vampiro_Gym
{
    public partial class formMain : Form
    {
        public static bool mainConnection;
        private Form activeform = null;
        public formMain()
        {
            InitializeComponent();
        }

        public void openChild(Form childForm)
        {
            if (activeform != null)
            {
                activeform.Close();
            }
            activeform = childForm;
            activeform.TopLevel = false;
            activeform.FormBorderStyle = FormBorderStyle.None;
            activeform.Dock = DockStyle.Fill;
            panelContenedorForm.Controls.Add(activeform);
            panelContenedorForm.Tag = activeform;
            activeform.BringToFront();
            activeform.Show();
        }

        private void botonClose_Click(object sender, EventArgs e)
        {
            OptionWindow ventanaCierre = new OptionWindow();
            ventanaCierre.ShowDialog();
            if (ventanaCierre.getOpcion == "sesion")
            {
                this.Close();
                loginWindow loginwindow = new loginWindow();
                loginwindow.Show();
                LectorZKTecok30 lectorClientes = new LectorZKTecok30();
                lectorClientes.Disconnect();
            }
            else
            {
                Application.Exit();
            }
        }

        private void membresias_Click(object sender, EventArgs e)
        {
            openChild(new membresiasForm());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openChild(new UsuariosWIndow());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            openChild(new clientesForm());
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            Thread hiloLector = new Thread(new ThreadStart(verificaHuella));
            hiloLector.IsBackground = true;
            hiloLector.Start();
            System.Drawing.Rectangle rect = Screen.GetWorkingArea(this);
            this.MaximizedBounds = Screen.GetWorkingArea(this);
            this.WindowState = FormWindowState.Maximized;
        }

        private async void verificaHuella()
        {
            int ret = 0;
            LectorZKTecok30 lector = new LectorZKTecok30();
            ret = lector.ConnectDevice();
            if (ret==1)
            {
                mainConnection = true;
                ret = lector.OverwriteAction();
                if (ret ==1)
                {
                    while (true)
                    {
                        if (lector.getVerifiedCustomerID() != "")
                        {
                            await showCustomer();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Se presento un problema al suscribir el evento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Se ha presentado un problema al inicializar el lector de huellas K30", "Error de inicializacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task showCustomer()
        {
            Image imagen = null;
            string name = "";
            string lastName = "";
            string membershipType = "";
            string startDate = "";
            string query = "SELECT Fotografia,Nombre,Apellido,Tipo_de_membresia,Fecha_de_alta_membresia FROM Customers WHERE NoCliente=" + LectorZKTecok30.verifiedCustomerID;
            try
            {
                SqlCommand command = new SqlCommand(query, dataBaseControl.connection);
                SqlDataReader filas = command.ExecuteReader();
                while(filas.Read())
                {
                    imagen = (Bitmap)((new ImageConverter()).ConvertFrom(filas.GetValue(0)));
                    name = filas.GetValue(1).ToString();
                    lastName = filas.GetValue(2).ToString();
                    membershipType = filas.GetValue(3).ToString();
                    startDate = filas.GetValue(4).ToString();
                }
                if (imagen!=null && name!="" && lastName!="" && membershipType!="" && startDate != "")
                {
                    await Task.Run(()=>showWindow(imagen, name, lastName, membershipType, startDate));
                    LectorZKTecok30.verifiedCustomerID = "";
                }
            }
            catch(Exception err)
            {
                MessageBox.Show("Se ha presentado el siguiente error al consultar la base de datos: " + err.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void showWindow(Image imagen, string name, string lastName, string membershipType,string startDate)
        {
            string now = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            dataBaseControl insertNewRegister = new dataBaseControl();
            string query = "INSERT INTO Historico_Visitas (Fecha_de_visita,Nombre,Apellido,Tipo_de_membresia) VALUES ('" + now + "','" + name + "','" + lastName + "','" + membershipType + "')";
            bool resQuery = insertNewRegister.Insert(query);
            if (!resQuery)
            {
                MessageBox.Show("Se ha presentado un problema al crear el nuevo registro de visita", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Vampiro_Gym.Forms.CustomerWIndow showCustomer = new Forms.CustomerWIndow(imagen,name,lastName,membershipType,startDate);
            showCustomer.ShowDialog();
        
        
        }

        private void reportesButton_Click(object sender, EventArgs e)
        {
            openChild(new Vampiro_Gym.Forms.ReportsWindow());
        }
    }
}

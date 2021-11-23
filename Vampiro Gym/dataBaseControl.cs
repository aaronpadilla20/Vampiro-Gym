using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Vampiro_Gym
{
    class dataBaseControl
    {
        private static SqlConnection connection;

        public void abrir()
        {
            try
            {
                string cadenaConexion = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename =|DataDirectory|vampiroGym.mdf; Integrated Security = True; Connect Timeout = 30";
                connection = new SqlConnection(cadenaConexion);
                connection.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("Se ha producido un error con la conexion a la base de datos contacte al administrador del sistema");
            }
        }

        public void consulta(string[] campos)
        {
            string fieldToObtain = "";
            foreach(string dato in campos)
            {
                fieldToObtain += dato + ",";
            }
           string consulta = "SELECT Tipo_de_usuario,Contrasena FROM Usuarios WHERE Nombre LIKE 'Aaron%'"; //Consulta a ejecutar 
           SqlCommand sql = new SqlCommand(consulta,connection); //Aplicar consulta en base de datos 
           SqlDataReader filas = sql.ExecuteReader(); // Leer consulta

           string texto = "Los datos son \n";
           while(filas.Read())
           {
                MessageBox.Show(filas.GetValue(0).ToString() + filas.GetValue(1).ToString());
           }
           MessageBox.Show(texto);
        }
    }
}

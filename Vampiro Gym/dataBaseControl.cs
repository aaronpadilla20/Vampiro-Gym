using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Vampiro_Gym
{
    class dataBaseControl
    {
        public static SqlConnection connection;
        private int actualizado;

        public void abrir()
        {
            try
            {
                string cadenaConexion = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|vampiroGym.mdf;Integrated Security=True;Connect Timeout=30";
                connection = new SqlConnection(cadenaConexion);
                connection.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("Se ha producido el siguiente error al intentar conectar con la base de datos: " + e.Message);
                Application.Exit();
            }
        }

        public string Select(string query, string tabla, int camposAObtener)
        {
           SqlCommand sql = new SqlCommand(query,connection); //Aplicar consulta en base de datos 
           SqlDataReader filas = sql.ExecuteReader(); // Leer consulta
           string valorDevuelto = "";
           switch (camposAObtener)
            {
                case 1:
                    while (filas.Read())
                    {
                        valorDevuelto += filas.GetValue(0).ToString() + ",";
                    }
                    break;
                case 2:
                    while (filas.Read())
                    {
                        valorDevuelto += filas.GetValue(0).ToString() + "," + filas.GetValue(1).ToString() + ",";
                    }
                    break;
                case 3:
                    while (filas.Read())
                    {
                        valorDevuelto += filas.GetValue(0).ToString() + "," + filas.GetValue(1).ToString() + "," + filas.GetValue(2).ToString() + ",";
                    }
                    break;
                case 4:
                    while (filas.Read())
                    {
                        valorDevuelto += filas.GetValue(0).ToString() + "," + filas.GetValue(1).ToString() + "," + filas.GetValue(2).ToString() + "," + filas.GetValue(3).ToString() + ",";
                    }
                    break;
                case 5:
                    while (filas.Read())
                    {
                        valorDevuelto += filas.GetValue(0).ToString() + "," + filas.GetValue(1).ToString() + "," + filas.GetValue(2).ToString() + "," + filas.GetValue(3).ToString() + "," + filas.GetValue(4).ToString() + ",";
                    }
                    break;
                default:
                    MessageBox.Show("La tabla mas larga tiene una longitud de 6 campos si usted requiere leer la tabla completa utilice '*' para la consulta en lugar de los campos de tabla");
                    break;
            }
           filas.Close();
           string resultadoConsulta = valorDevuelto != "" ? valorDevuelto : "No existe el usuario favor de verificarlo";
           return resultadoConsulta; 
        }

        public bool Update(string query)
        {
            SqlCommand command = new SqlCommand(query, connection);
            this.actualizado = command.ExecuteNonQuery();
            if (actualizado == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Insert(string query)
        {
            SqlCommand commando = new SqlCommand(query, connection);
            this.actualizado = commando.ExecuteNonQuery();
            if (actualizado == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(string query)
        {
            SqlCommand command = new SqlCommand(query, connection);
            this.actualizado = command.ExecuteNonQuery();
            if (actualizado == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

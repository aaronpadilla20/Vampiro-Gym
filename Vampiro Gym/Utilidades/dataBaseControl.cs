using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace Vampiro_Gym
{
    class dataBaseControl
    {
        public static SqlConnection connection;
        private int actualizado;

        public string abrir()
        {
            try
            {
                string cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Program Files\\Microsoft SQL Server\\MSSQL15.SQLEXPRESS\\MSSQL\\DATA\\vampiroGym.mdf; Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30";
                connection = new SqlConnection(cadenaConexion);
                connection.Open();
                return "Conexion exitosa";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public bool BackUp()
        {
            var dbName = connection.Database;
            string nombre_copia = (System.DateTime.Today.Day.ToString() + "-" + System.DateTime.Today.Month.ToString() + "-" + System.DateTime.Today.Year.ToString() + "-" + System.DateTime.Now.Hour.ToString() + "-" + System.DateTime.Now.Minute.ToString() + "-" + System.DateTime.Now.Second.ToString() + "-VampiroGymDataBaseBackup.bak");
            string query = "BACKUP DATABASE [" + dbName + "] TO DISK = N'C:\\Program Files\\Microsoft SQL Server\\MSSQL15.SQLEXPRESS\\MSSQL\\Backup\\" + nombre_copia + "' WITH NOFORMAT, NOINIT, NAME = N'vampiroGym-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
            SqlCommand cmd = new SqlCommand(query, connection);
            try
            {
                this.actualizado = cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }

        public SqlDataReader getDataTable(string query)
        {
            SqlCommand comand = new SqlCommand(query, connection);
            SqlDataReader filas = comand.ExecuteReader();
            return filas;
        }

        public string Select(string query, int camposAObtener)
        {
           SqlCommand sql = new SqlCommand(query,connection); //Aplicar consulta en base de datos 
           SqlDataReader rows = sql.ExecuteReader(); // Leer consulta
           string valorDevuelto = "";
           switch (camposAObtener)
            {
                case 1:
                    while (rows.Read())
                    {
                        valorDevuelto += rows.GetValue(0).ToString() + ",";
                    }
                    break;
                case 2:
                    while (rows.Read())
                    {
                        valorDevuelto += rows.GetValue(0).ToString() + "," + rows.GetValue(1).ToString() + ",";
                    }
                    break;
                case 3:
                    while (rows.Read())
                    {
                        valorDevuelto += rows.GetValue(0).ToString() + "," + rows.GetValue(1).ToString() + "," + rows.GetValue(2).ToString() + ",";
                    }
                    break;
                case 4:
                    while (rows.Read())
                    {
                        valorDevuelto += rows.GetValue(0).ToString() + "," + rows.GetValue(1).ToString() + "," + rows.GetValue(2).ToString() + "," + rows.GetValue(3).ToString() + ",";
                    }
                    break;
                case 5:
                    while (rows.Read())
                    {
                        valorDevuelto += rows.GetValue(0).ToString() + "," + rows.GetValue(1).ToString() + "," + rows.GetValue(2).ToString() + "," + rows.GetValue(3).ToString() + "," + rows.GetValue(4).ToString() + ",";
                    }
                    break;
                default:
                    MessageBox.Show("La tabla mas larga tiene una longitud de 6 campos si usted requiere leer la tabla completa utilice '*' para la consulta en lugar de los campos de tabla");
                    break;
           }
           rows.Close();
           string resultadoConsulta = valorDevuelto != "" ? valorDevuelto : "La consulta no genero resultados";
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

        public bool InsertNewHistoricalData(string query,string fechaAlta, string tipoMembresia,string fechaVencimiento,string nombre,string apellido)
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@fechaAlta", fechaAlta);
            command.Parameters.AddWithValue("@tipoMembresia", tipoMembresia);
            command.Parameters.AddWithValue("@fechaVencimiento", fechaVencimiento);
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@apellido", apellido);
            this.actualizado = command.ExecuteNonQuery();
            if (actualizado ==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool InsertCliente(String query, byte[] imagen,string nombre, string apellido,string huellaDactilar, string tipoMembresia, string fechaAlta,string dadoDeAltaPor)
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@imagen", imagen);
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@apellido", apellido);
            command.Parameters.AddWithValue("@huellaDactilar", huellaDactilar);
            command.Parameters.AddWithValue("@tipoMembresia", tipoMembresia);
            command.Parameters.AddWithValue("@fechaAltaMembresia", fechaAlta);
            command.Parameters.AddWithValue("@fechaAltaCliente", fechaAlta);
            command.Parameters.AddWithValue("@dadoDeAltaPor", dadoDeAltaPor);
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

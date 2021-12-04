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

        public string abrir()
        {
            try
            {
                string cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|vampiroGym.mdf;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30";
                connection = new SqlConnection(cadenaConexion);
                connection.Open();
                return "Conexion exitosa";
            }
            catch (Exception e)
            {
                return e.Message;
            }
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

        public bool InsertCliente(String query, byte[] imagen,string nombre, string apellido,byte[] huellaDactilar, string tipoMembresia, string fechAlta)
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@imagen", imagen);
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@apellido", apellido);
            command.Parameters.AddWithValue("@huellaDactilar", huellaDactilar);
            command.Parameters.AddWithValue("@tipoMembresia", tipoMembresia);
            command.Parameters.AddWithValue("@fechaAlta", fechAlta);
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

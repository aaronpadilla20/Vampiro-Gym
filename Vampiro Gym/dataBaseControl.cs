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
        private string fieldToObtain;
        private string nombre;
        private string apellido;
        private string query;

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
                MessageBox.Show("Se ha producido el siguiente error al intentar conectar con la base de datos: " + e.Message);
                Application.Exit();
            }
        }

        public string consulta(string[] campos,string tabla, string campo, string datoABuscar,bool filtrar)
        {
            bool todos = false;
            if (Array.Exists(campos,x=>x=="*"))
            {
                todos = true;
            }
            foreach(string dato in campos)
            {
                this.fieldToObtain += dato + ",";
            }
           this.fieldToObtain = this.fieldToObtain.TrimEnd(',');
           this.query = filtrar ? "SELECT " + this.fieldToObtain + " FROM " + tabla + " WHERE " + campo + " LIKE '" + datoABuscar + "%'" : "SELECT " + this.fieldToObtain + " FROM " + tabla + " WHERE " + campo + "='" + datoABuscar + "'";
           SqlCommand sql = new SqlCommand(this.query,connection); //Aplicar consulta en base de datos 
           SqlDataReader filas = sql.ExecuteReader(); // Leer consulta

           string valorDevuelto = "";
           if (todos)
           {
             switch(tabla)
             {
                    case "Clientes":
                        while (filas.Read())
                        {
                            valorDevuelto += filas.GetValue(0).ToString() + "," + filas.GetValue(1).ToString() + "," + filas.GetValue(2).ToString() + "," + filas.GetValue(3).ToString() + "," + filas.GetValue(4).ToString() + "," + filas.GetValue(5).ToString() + "," + filas.GetValue(6).ToString();
                        }
                        break;
                    case "Historico Membresias":
                        while (filas.Read())
                        {
                            valorDevuelto += filas.GetValue(0).ToString() + "," + filas.GetValue(1).ToString() + "," + filas.GetValue(2).ToString() + "," + filas.GetValue(3).ToString();
                        }
                        break;
                    case "Membresias":
                        while (filas.Read())
                        {
                            valorDevuelto += filas.GetValue(0).ToString() + "," + filas.GetValue(1).ToString() + "," +  filas.GetValue(2).ToString();
                        }
                        break;
                    case "Usuarios":
                        while (filas.Read())
                        {
                            valorDevuelto += filas.GetValue(0).ToString() + "," + filas.GetValue(1).ToString() + "," + filas.GetValue(2).ToString() + "," + filas.GetValue(3).ToString() + "," + filas.GetValue(4).ToString() + "," + filas.GetValue(5).ToString() + "," + filas.GetValue(6).ToString();
                        }
                        break;
                    case "Visitas":
                        while (filas.Read())
                        {
                            valorDevuelto += filas.GetValue(0).ToString() + "," + filas.GetValue(1).ToString();
                        }
                        break;
                    default:
                        MessageBox.Show("La base de datos que intento consultar no existe");
                        break;
                }
           }
           else
           {
                switch(campos.Length)
                {
                    case 1:
                        while (filas.Read())
                        {
                            valorDevuelto += filas.GetValue(0).ToString();
                        }
                        break;
                    case 2:
                        while (filas.Read())
                        {
                            valorDevuelto += filas.GetValue(0).ToString() + "," + filas.GetValue(1).ToString();
                        }
                        break;
                    case 3:
                        while (filas.Read())
                        {
                            valorDevuelto += filas.GetValue(0).ToString() + "," + filas.GetValue(1).ToString() + "," + filas.GetValue(2).ToString();
                        }
                        break;
                    case 4:
                        while (filas.Read())
                        {
                            valorDevuelto += filas.GetValue(0).ToString() + "," + filas.GetValue(1).ToString() + "," + filas.GetValue(2).ToString() + "," + filas.GetValue(3).ToString();
                        }
                        break;
                    case 5:
                        while (filas.Read())
                        {
                            valorDevuelto += filas.GetValue(0).ToString() + "," +  filas.GetValue(1).ToString() + "," + filas.GetValue(2).ToString() + "," + filas.GetValue(3).ToString() + "," + filas.GetValue(4).ToString();
                        }
                        break;
                    default:
                        MessageBox.Show("La tabla mas larga tiene una longitud de 6 campos si usted requiere leer la tabla completa utilice '*' para la consulta en lugar de los campos de tabla");
                        break;
                }
           }
           filas.Close();
           string resultadoConsulta = valorDevuelto != "" ? valorDevuelto : "No existe el usuario favor de verificarlo";
           return resultadoConsulta; 
        }

        public bool Actualizaregistro(string tabla, string[] datos, string[] valorReferencia)
        {
            /*
            foreach (string dato in datos)
            {
                this.fieldToObtain += dato + ",";
            }
            this.fieldToObtain = this.fieldToObtain.TrimEnd(',');

            if (tabla == "Membresias")
            {
                MessageBox.Show("ok");
            }
            else
            {
                this.nombre = valorReferencia[0];
                this.apellido = valorReferencia[1];
            }
            return true;*/
            return true;
        }

        public bool ActualizaUsuariosClientes(string tabla, string[] datos, string[] valorReferencia)
        {
            foreach (string dato in datos)
            {
                this.fieldToObtain += dato + ",";
            }
            this.fieldToObtain = this.fieldToObtain.TrimEnd(',');
            this.nombre = valorReferencia[0];
            this.apellido = valorReferencia[1];
            this.query = "UPDATE " + tabla + " SET " + this.fieldToObtain + " WHERE (Nombre='" + nombre + "') AND (Apellido='" + apellido + "')";
            SqlCommand command = new SqlCommand(this.query, connection);

            return true;
        }
    }
}

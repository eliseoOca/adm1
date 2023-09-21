using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adm1
{
    public partial class altausuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Obtener la cadena de conexión desde web.config
            string connectionString = ConfigurationManager.ConnectionStrings["administaccion"].ConnectionString;

            // Crear una nueva conexión SQL
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    conexion.Open();

                    // Crear un comando SQL para insertar un nuevo usuario en la tabla "usuarios"
                    string nombre = TextBox1.Text;
                    string clave = TextBox2.Text;
                    string mail = TextBox3.Text;

                    // Comando SQL para la inserción
                    string consultaSQL = "INSERT INTO usuarios (nombre, clave, mail) VALUES (@nombre, @clave, @mail)";

                    using (SqlCommand comando = new SqlCommand(consultaSQL, conexion))
                    {
                        // Agregar parámetros para el nombre, clave y mail
                        comando.Parameters.AddWithValue("@nombre", nombre);
                        comando.Parameters.AddWithValue("@clave", clave);
                        comando.Parameters.AddWithValue("@mail", mail);

                        // Ejecutar la consulta SQL
                        int filasAfectadas = comando.ExecuteNonQuery();

                        // Mostrar un mensaje de éxito o error
                        if (filasAfectadas > 0)
                        {
                            Label1.Text = "Se ha registrado el usuario correctamente.";
                        }
                        else
                        {
                            Label1.Text = "No se pudo registrar el usuario. Inténtalo de nuevo.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Capturar y mostrar cualquier excepción que ocurra durante la operación
                    Label1.Text = "Error: " + ex.Message;
                }
            }
        }
    }
}